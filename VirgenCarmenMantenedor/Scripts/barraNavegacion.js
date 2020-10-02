
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
                location.href = 'login.aspx';
            }
            else {
                alertify.error("se produjo un error al intentar cerrar la sesion")
            }
        })
        .then(e => console.log(e));
}

function cerrarSesionInactividad(codigo) {
    fetch('login.aspx/CerrarSesionInactividad', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json; Scharset=utf-8'
        },
        body: JSON.stringify({ codUser: codigo })
    })
        .then(response => response.json())
        .then(data => {
            if (!alertify.errorAlert) {
                //define a new errorAlert base on alert
                alertify.dialog('errorAlert', function factory() {
                    return {
                        build: function () {
                            var errorHeader = '<span class="fa fa-times-circle fa-2x" '
                                + 'style="vertical-align:middle;color:red;">'
                                + '</span> Error a la hora de recuperar la sesion';
                            this.setHeader(errorHeader);
                        }
                    };
                }, true, 'alert');
            }
            alertify.errorAlert('La sesion a caducado  </br></br> <strong> Vuelva a ingresar sesion</strong>');
            localStorage.clear();
            setTimeout(() => {
                location.href = 'login.aspx';
            }, 1000);

        })
        .then(e => console.log(e));
}

function credenciales() {

    fetch('login.aspx/getSession', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json; Scharset=utf-8'
        }
    })
        .then(response => response.json())
        .then(data => {

            if (data.d[0].nombre == "" || data.d[0].nombre == null) {
                let user = parseInt(localStorage.getItem('user'),10);
                cerrarSesionInactividad(user);                
                
            } else {
                let p = document.getElementById('nombreUsuario');
                p.innerHTML = data.d[0].nombre + " - " + data.d[0].perfil + " / " + '<a href="#" class="navbar - link" id="cerrarSesion">Cerrar sesión  <span class="glyphicon glyphicon - log - out"> </span></a>';
                document.getElementById('cerrarSesion').addEventListener('click', cerrarSesion);
                
            };
        })
        .catch(e => {
            console.log(e);
                let user = localStorage.getItem('user');
            cerrarSesionInactividad(user);
                        
        });


    console.log('validacion');
}

addEventListener('load', credenciales);
