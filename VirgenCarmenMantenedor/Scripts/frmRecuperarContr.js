addEventListener('load', () => { 

const D = document;
const TXT_USER = D.getElementById("exampleInputEmail1");
const CONTAINER_MENSAJES = D.getElementById("mensajes");

let btn = D.getElementById('ingresar');

D.getElementById('form').addEventListener('submit', (e) => {
    e.preventDefault();
});



function validacionUser() {
    mostrarMensaje('DEBE COMPLETAR EL NOMBRE DE USUARIO');
    ocultarMensaje();
    TXT_USER.focus();
}



function mostrarMensaje(mensaje) {
    CONTAINER_MENSAJES.classList.replace("mensajes", "mensajes-visible");
    let p = D.createElement('p');
    let text = D.createTextNode(mensaje);
    p.appendChild(text);
    CONTAINER_MENSAJES.appendChild(p);

}

function ocultarMensaje() {
    setTimeout(function () {
        CONTAINER_MENSAJES.classList.replace("mensajes-visible", "mensajes")
        while (CONTAINER_MENSAJES.firstChild) {
            CONTAINER_MENSAJES.removeChild(CONTAINER_MENSAJES.lastChild);
        }
    }, 2000);
}

function init() {
    btn.classList.replace("btn-success", "btn-default")
}

function restore() {
    btn.classList.replace("btn-default", "btn-success")

}


TXT_USER.addEventListener('change', function (e) {
    if (e.target.value.trim().length > 0) {
        btn.removeAttribute('disabled')
        restore();
    } else {
        btn.setAttribute('disabled', false)
        init();
        validacionUser()

    }
});

function validaciones() {
    if (TXT_USER.value == "" || TXT_USER.value == null) {
        console.log('clic')
        validacionUser()
        btn.setAttribute('disabled', true),
            init()
    } else {
        btn.removeAttribute('disabled'),
            restore()
        enviarCorreo(TXT_USER.value)
    }

}



function enviarCorreo(usuario) {

    fetch('recuperarContraseña.aspx/enviarCorreo', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json; charset=utf-8'
        },
        body: "{'usuario':'" + usuario + "'}"

    })
        .then(res => {
            try {
                if (res.ok) {
                    return res.json()
                } else {
                    throw new Error(res)
                }
            }
            catch (err) {
                console.log(err.message)
                return WHATEVER_YOU_WANT_TO_RETURN
            } })
        .then(data => {
            
            if (data.d == null) {
                                   
                alertify.success('<strong> Se envio el corre de manera exitosa</strong> ');
                setTimeout(function () { location.href = 'login.aspx' }, 3000);

            } else {
                if (!alertify.errorAlert) {
                    //define a new errorAlert base on alert
                    alertify.dialog('errorAlert', function factory() {
                        return {
                            build: function () {
                                var errorHeader = '<span class="fa fa-times-circle fa-2x" '
                                    + 'style="vertical-align:middle;color:red;">'
                                    + '</span> Error a la hora de recuperar correo';
                                this.setHeader(errorHeader);
                            }
                        };
                    }, true, 'alert');
                }
                alertify.errorAlert('No se puede enviar el correo por el siguiente motivo  </br></br> <strong>' + data.d +'</strong>');
            }
        })
        .catch(e => console.log(e));

}




    btn.addEventListener('click', validaciones);

});