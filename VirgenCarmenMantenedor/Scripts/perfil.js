addEventListener('load',()=> {


let txt_nombres = document.getElementById('nombres');
let txt_app = document.getElementById('app');
let txt_apm = document.getElementById('apm');
let txt_telefono = document.getElementById('tlfn');
let txt_email = document.getElementById('email');
let txt_usuario = document.getElementById('usuario');
let txt_contraseñaAnterior = document.getElementById('contraseñaAnterior');
let txt_nuevaContraseña = document.getElementById('nuevaContraseña');
let txt_contraseñaConfirmacion = document.getElementById('confirmarContraseña');

const LETRAS = /^[a-zA-Z]*$/;
const TELEFONO = /^[\(]?[\+]?(\d{2}|\d{3})[\)]?[\s]?((\d{6}|\d{8})|(\d{3}[\*\.\-\s]){2}\d{3}|(\d{2}[\*\.\-\s]){3}\d{2}|(\d{4}[\*\.\-\s]){1}\d{4})|\d{8}|\d{10}|\d{6}$/
// Debe tener 1 letra minúscula, 1 letra mayúscula, 1 número, 1 carácter especial y tener al menos 8 caracteres de longitud
const passwordRegex = /(?=(.*[0-9]))(?=.*[\!@#$%^&*()\\[\]{}\-_+=~`|:"'<>,./?])(?=.*[a-z])(?=(.*[A-Z]))(?=(.*)).{8,}/
const emailRegex = /^(([^<>()\[\]\\.,:\s@"]+(\.[^<>()\[\]\\.,:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/
const BTN_GUARDAR = document.getElementById('guardar');
const g_const_505 = 505

let estado = {
    nom: true,
    app: true,
    apm: true,
    telefono: true,
    email: true,
    usuario: true,
    contraseñaAnterior: true,
    contraseñaNueva: false,
    confirmacionContraseña: false
}

function consultarDatosPerfil() {
    fetch('Perfil.aspx/DataPerfil', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json; Scharset=utf-8'
        }
    })
        .then(response => response.json())
        .then(data => {
            txt_nombres.value = data.d[0].nombre
            txt_app.value = data.d[0].apellidoPaterno
            txt_apm.value = data.d[0].apellidoMaterno
            txt_telefono.value = data.d[0].telefono
            txt_email.value = data.d[0].correo
            txt_usuario.value = data.d[0].usuario
            txt_contraseñaAnterior.value = data.d[0].password
            txt_nombres.focus();
        })
        .catch(e => console.log(e));
}

document.getElementById('formulario').addEventListener('submit', e => { e.preventDefault(); });

txt_email.addEventListener("blur", e => {
    if (e.target.value.trim().length = 0) {
        estado.email = true;

    } else {
        alertify.error("El campo nombre no puede quedar vacío")
    }

});

txt_nombres.addEventListener('blur', e => {
    if (e.target.value.trim().length > 0) {
        if (LETRAS.test(txt_nombres.value)) {
            estado.nom = true
        } else {
            estado.nom = false;
            alertify.error("El nombre no puede contener números");
        }
    } else {
        alertify.error("El nombre no puede quedar vacío");
    }
});

txt_app.addEventListener('blur', e => {
    if (e.target.value.trim().length > 0) {
        if (LETRAS.test(txt_app.value)) {
            estado.app = true
        } else {
            estado.app = false;
            alertify.error("El apellido paterno no puede contener números");
        }
    } else {
        alertify.error("El apellido paterno no puede quedar vacío");
    }
});

txt_apm.addEventListener('blur', e => {
    if (e.target.value.trim().length > 0) {
        if (LETRAS.test(txt_apm.value)) estado.apm = true
        else {
            estado.apm = false;
            alertify.error("El apellido materno no puede contener números");
        }
    } else {
        alertify.error("El apellido materno no puede quedar vacío");
    }
});

txt_telefono.addEventListener('blur', e => {
    if (e.target.value.trim().length > 0) {
        if (TELEFONO.test(txt_telefono.value)) estado.telefono = true
        else {
            estado.telefono = false;
            alertify.error("El telefono no debe contener letras")
        }
    } else {
        alertify.error("El telefono no debe quedar vacío")
    }
});

txt_nuevaContraseña.addEventListener('blur', e => {
    if (e.target.value.trim().length > 0) {
        if (passwordRegex.test(txt_nuevaContraseña.value)) estado.contraseñaNueva = true
        else {
            if (!alertify.errorAlert) {
                //define a new errorAlert base on alert
                alertify.dialog('errorAlert', function factory() {
                    return {
                        build: function () {
                            var errorHeader = '<span class="fa fa-times-circle fa-2x" '
                                + 'style="vertical-align:middle;color:#e10000;">'
                                + '</span> Error en formato de contraseña';
                            this.setHeader(errorHeader);
                            txt_nuevaContraseña.value = ""
                        }
                    };
                }, true, 'alert');
            }
            alertify.errorAlert('La contraseña debe tener el siguiente formato:' +
                '<li> 1 letra minúscula</li>' +
                '<li> 1 letra mayúscula </li>' +
                '<li> 1 número</li>' +
                '<li> 1 carácter especial y tener al menos 8 caracteres de longitud </li>');
            
        }
    } else {
        estado.contraseñaNueva = false;
       
    }
});

txt_contraseñaConfirmacion.addEventListener('blur', e => {
    if (e.target.value.trim().length > 0) {
        console.log(txt_nuevaContraseña.value, "nueva: ", txt_contraseñaConfirmacion.value);
        if (txt_nuevaContraseña.value == txt_contraseñaConfirmacion.value) {
            estado.confirmacionContraseña = true
            estado.contraseñaNueva = true
            estado.contraseñaAnterior = true
        } else {

            estado.contraseñaNueva = false;
            alertify.error("Las contraseñas deben ser iguales");
            
        }

    } else {
        estado.contraseñaNueva = false;
        
    }

});

function cerrarSesion() {
    fetch('login.aspx/CerrarSesion', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json; Scharset=utf-8'
        }
    })
        .then(response => response.json())
        .then(data => {
            if (parseInt(data.d[0].respuesta, 10) == 2000) {
                let p = document.getElementById('nombreUsuario');
                p.innerHTML = " ";
                console.log(document.getElementById('nombreUsuario').innerText);
                location.href = 'login.aspx';
            }
            else {
                alertify.error("se produjo un error al intentar cerrar la sesion")
            }
        })
        .then(e => console.log(e));
}

function mensajeError() {
    if (!alertify.errorAlert) {
        //define a new errorAlert base on alert
        alertify.dialog('errorAlert', function factory() {
            return {
                build: function () {
                    var errorHeader = '<span class="fa fa-times-circle fa-2x" '
                        + 'style="vertical-align:middle;color:#e10000;">'
                        + '</span> Application Error';
                    this.setHeader(errorHeader);
                }
            };
        }, true, 'alert');
    }
    alertify.errorAlert('Se presento un error al intentar actualizar los datos del perfil');
}

function actualizarPerfil(nombre, apellidoPaterno, apellidoMaterno, telefono, correo, password) {
    fetch('Perfil.aspx/ActualizarPerfil', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json; Scharset=utf-8'
        },
        body: "{'nombre': '" + nombre + "','apellidoPaterno': '" + apellidoPaterno + "','apellidoMaterno':'" + apellidoMaterno + "','telefono':'" + telefono + "' ,'correo':'" + correo + "','password':'" + password + "'}"
    })
        .then(response => response.json())
        .then(data => (data.d == g_const_505) ? cerrarSesion() : mensajeError())
        .catch(e => console.log(e));
}

function validaciones() {
    let valores = Object.values(estado);
    let validacion = valores.findIndex(value => value == false);
    console.log(valores);

    if (validacion == -1) {
        actualizarPerfil(txt_nombres.value, txt_app.value, txt_apm.value, txt_telefono.value, txt_email.value, txt_contraseñaConfirmacion.value);
    } else {
        alertify.error("Complete todos los campos");
    }

}

consultarDatosPerfil();
BTN_GUARDAR.addEventListener('click', validaciones);



});
