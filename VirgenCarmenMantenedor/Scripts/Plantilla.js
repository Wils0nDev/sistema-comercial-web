$(document).ready(function () {

    var btnEliminar = $(".btnDelete");
    var idDateTable = $("#idDateTable");

    //Convertimos la tabla en dataTable y le pasamos parametros
    idDateTable.DataTable({
        language: {
            lengthMenu: "Mostrar _MENU_ registros",
            zeroRecords: "No hay registros",
            info: "Mostrando la página _PAGE_ de _PAGES_",
            infoEmpty: "No hay registros disponibles.",
            infoFiltered: "(filtered from _MAX_ total records)",
            search: "Busqueda rapida: ",
            oPaginate: {
                "sFirst": "Primero",
                "sLast": "Último",
                "sNext": "Siguiente",
                "sPrevious": "Anterior"
            },

        },
    });

    btnEliminar.click(function () {
        //Obtengo los valores de mi tr seleccionado.
      

        // var restantes = parseInt(cantidadFilas - Orden)


        swal({
            title: "Se eliminara el registro",
            text: "¿Esta seguro que desea eliminar el registro?",
            icon: "warning",
            buttons: true,
            dangerMode: true,
        })
            //Promesa que me trae el valor true al confirmar OK.
            .then((willDelete) => {
                if (willDelete) {
                  
                    swal("Se elimino Registro", {
                        icon: "success",
                    });

                } else {
                    swal("Se Cancelo la eliminaciòn");

                }
            });
    });
});