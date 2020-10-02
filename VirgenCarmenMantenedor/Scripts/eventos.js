$(document).ready(function () {
    var vendedores = $("#vendedores");
    var buttonModal = $("#buttonModal");
    var mGuardar = $("#mGuardar");
    var Mvendedor = $("#Mvendedor");
    var McodVendedor = $("#McodVendedor");
    var rutas = $("#rutas");
    var Mabreviatura = $("#Mabreviatura");
    var buttonModal = $("#buttonModal");
    var phtml = $("#phtml");
    var McodOrden = $("#McodOrden");
    var btnGuardar = $("#btnGuardar");
    var Mmensaje = $("#Mmensaje");
    var Mpmensaje = $("#Mpmensaje");
    var btnActualizar = $("#btnActualizar");
    var btnCancelar = $("#btnCancelar");
    var selectDias = $("#dias");
   

    



    buttonModal.click(function () {
        Mmensaje.css('display', 'none');
        var tableBodyTR = $("#tbl_body_table tr");

        var optionSelected = vendedores.find("option:selected");
        var optionSelectedText = optionSelected.text();
        var optionSelectedVal = optionSelected.val();
        var codOrden;


        Mvendedor.val(optionSelectedText);
        McodVendedor.val(optionSelectedVal);
        if (isNaN(tableBodyTR.last()[0].cells[0].innerText)) {


            codOrden = 1;
        } else {
            codOrden = parseInt(tableBodyTR.last()[0].cells[0].innerText) + 1;
        }

        McodOrden.val(codOrden);
        rutas.prop('selectedIndex', "");
        Mabreviatura.val("");
        selectDias.val("");
        btnActualizar.css("display", "none");
        btnCancelar.css("margin-right", "90px");

        btnGuardar.css("display", "block")
            .css("margin-top", "-34px")
            .css("margin-left", "460px");



    })




    vendedores.change(function () {
           
        var optionSelected = $(this).find("option:selected");
        var valueSelected = optionSelected.val();


        if (valueSelected > 0) {
            buttonModal.prop("disabled", false);
        } else {
            buttonModal.prop("disabled", true);
        }
    });

    rutas.change(function () {

        var optionSelecedRuta = $(this).find("option:selected");
        var valueSelectedRuta = optionSelecedRuta.val();
        var textSelectedRuta = optionSelecedRuta.text();


        if (valueSelectedRuta > 0) {
            console.log(phtml.html(textSelectedRuta));
        }
    });




});