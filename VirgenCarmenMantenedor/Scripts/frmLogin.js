
addEventListener('load', () => {
    const D = document;
    const TXT_USER = D.getElementById("exampleInputEmail1");
    const TXT_PASS = D.getElementById("exampleInputPassword1");
    const SUCURSAL = D.getElementById("sucursal");

    const BTN_INGRESAR = D.getElementById('ingresar');
    const BTN_RECUPERC = D.getElementById('recuperarCont');

    /* codigos de validacion */

    const g_const_500 = 500;
    const g_const_501 = 501;
    const g_const_502 = 502;
    const g_const_503 = 503;
    const g_const_504 = 504;
    const g_const_505 = 505;
    const g_const_506 = 506;
    const g_const_507 = 507;

   
    
    function llenarSucursal(datos) {
        console.log(datos);
        let data = Object.values(datos);

        for (let i = 0; i < data.length; i++) {
            let option = document.createElement('option');
            option.value = data[i].ntraSucursal;
            option.text = data[i].descripcion;
            SUCURSAL.appendChild(option)
        }
    }

    function cargarSucursal() {
        fetch('login.aspx/listarSucursal', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json; Scharset=utf-8'
            },
            body: JSON.stringify({ flag: 18 })
        })  .then(response => response.json())
            .then(data => llenarSucursal(data.d))
            .catch(e => console.log(e));
    }



    function validacionUser() {
        alertify.error('DEBE COMPLETAR EL NOMBRE DE USUARIO');
        TXT_USER.focus();
    }

    function validacionPass() {
        alertify.error('DEBE COMPLETAR LA CONTRASEÑA')
        TXT_PASS.focus();
    }

    function validarSucu() {
        alertify.error('DEBE SELECCIONAR LA SUSCURSAL');

    }

    function validaciones() {
              
    
            if (TXT_USER.value.trim() == "" && TXT_PASS.value.trim()== "" && SUCURSAL.value == 0) {
                alertify.error("DEBE COMPLETAR TODOS LOS CAMPOS");
                TXT_USER.focus();
            } else {
                if (TXT_USER.value.trim() == "" || TXT_USER.value == null) {
                    validacionUser()
                } else if (TXT_PASS.value.trim() == "" || TXT_PASS.value == null) {
                    validacionPass()
                } else if (SUCURSAL.value == 0) {
                    validarSucu()
                } else {
                    consultarCredenciales(TXT_USER.value, TXT_PASS.value, SUCURSAL.value);
                }
            }
        



    }

    function setSession(perfil, nombre, sucursal, ntraUsuario, codPersona) {
        fetch('login.aspx/InsertSession', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json; Scharset=utf-8'
            },
            body: "{'perfil': '" + perfil + "','nombre': '" + nombre + "','sucursal':'" + sucursal + "','codUser':'" + ntraUsuario + "','codPersona':'" + codPersona + "'  }",
        }).then(response => response.json())
            .then(data => {
                console.log(data.d);
                if (data.d) {
                    location.href = 'PanelControl.aspx'
                } else {
                    alertify.error("Se produjo un error inesperado");
                }
            })
            .catch(e => console.log(e));
    }

    function consultarCredenciales(usuario, password, sucursal) {
        let intentos
        if (localStorage.getItem('intentos') == null || parseInt(localStorage.getItem('intentos'), 10) == 0) {
            localStorage.setItem('intentos', 0);
            intentos = parseInt(localStorage.getItem('intentos'), 10) + 1;
            localStorage.removeItem('intentos');
            localStorage.setItem('intentos', intentos)
        } else {
            intentos = parseInt(localStorage.getItem('intentos'), 10) + 1;

            localStorage.removeItem('intentos');
            localStorage.setItem('intentos', intentos)
            console.log(localStorage.getItem('intentos'));
        }

        fetch('login.aspx/consultarDatos', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json; Scharset=utf-8' },
            body: "{'user': '" + usuario + "','pass': '" + password + "','intentos': '" + intentos + "','sucursal':'" + sucursal + "'}"
        })
            .then(response => response.json())
            .then(data => {
                console.log(data.d[0]);
                let estado = data.d[0].respuesta;

                switch (estado) {
                    case g_const_500:
                        alertify.error(data.d[0].nombre)
                        break
                    case g_const_501:
                        localStorage.clear();
                        alertify.error(data.d[0].nombre)
                        break
                    case g_const_502:
                        alertify.error(data.d[0].nombre)
                        break
                    case g_const_503:
                        localStorage.clear();
                        alertify.error(data.d[0].nombre)
                        break
                    case g_const_504:
                        localStorage.clear();          
                        alertify.error(data.d[0].nombre)
                        break
                    case g_const_505:
                        localStorage.clear();
                        localStorage.setItem('user', data.d[0].ntraUsuario);
                        setSession(data.d[0].perfil, data.d[0].nombre, data.d[0].sucursal, data.d[0].ntraUsuario, data.d[0].fkcodPersona);
                        break
                    case g_const_506:
                        localStorage.clear();                        
                        alertify.error(data.d[0].nombre)
                        break
                    case g_const_507:
                        localStorage.clear();
                        alertify.error(data.d[0].nombre)
                        break
                    default:
                        localStorage.clear();
                        alertify.error('No puede ingresar,usuario bloqueado');
                        break

                }
            })
            .catch(e => console.log(e));

    }
    TXT_USER.addEventListener('change', function (e) {
        if (e.target.value.trim().length > 0) {
            estado.user = true;
        } else {
            estado.user = false;
            validacionUser();
        }
    });

    TXT_PASS.addEventListener('change', function (e) {
        if (e.target.value.trim().length > 0) {
            estado.pass = true;
        } else {
            estado.pass = false;
            validacionPass();

        }
    });

  Selection

    BTN_INGRESAR.addEventListener('click', validaciones);
    BTN_RECUPERC.addEventListener('click', function () { location.href = 'recuperarContraseña.aspx' });

    D.getElementById('form').addEventListener('submit', (e) => {
        e.preventDefault();
    });


    cargarSucursal()
});