$(document).ready(function () {

    var upload = $('#upload');



    
    var dat = new Array();
    

    var ExcelToJSON = function () {

        this.parseExcel = function (file) {
            var reader = new FileReader();

            reader.onload = function (e) {
                var data = e.target.result;
                var workbook = XLSX.read(data, {
                    type: 'binary'
                });
                workbook.SheetNames.forEach(function (sheetName) {
                    // Here is your object
                    var XL_row_object = XLSX.utils.sheet_to_row_object_array(workbook.Sheets[sheetName]);
                    var json_object = JSON.stringify(XL_row_object);                                                   
                    addRowDT(JSON.parse(json_object));
                })
            };

            reader.onerror = function (ex) {
                console.log(ex);
            };

            reader.readAsBinaryString(file);
        };
    };

    function handleFileSelect(evt) {

        var files = evt.target.files; // FileList object
        var xl2json = new ExcelToJSON();
        xl2json.parseExcel(files[0]);
        
    }

   /* upload.change(function () {
        handleFileSelect;
    });*/

    document.getElementById('upload').addEventListener('change', handleFileSelect, false);


    //creo variables despues de que el DataTable este creado en el DOM.
    var tabla = $("#idDateTable").dataTable(); //funcion jquery
    var table = $("#idDateTable").DataTable(); //funcion DataTable-libreria




    //para ajustar el diseño de tabla
    table.columns.adjust().draw();

    function addRowDT(data) {

        for (var i = 0; i < data.length; i++) {    
            
            tabla.fnAddData([
                i+1,            
                data[i].nombre,
                data[i].apellidos,
                data[i].DNI,
                data[i].direccion

            ]);
        } 

    }
})