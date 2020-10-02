// Code goes here

$(document).ready(function () {

    var map = null;
    var myMarker;
    var myLatlng;
    var myCoordenada = new Array();
    var minDate = $("#min-date");
    var maxDate = $("#max-date");
    var buttonModalMapa = $('#buttonModalMapa');
    var ModalMapa = $('#ModalMapa');
    var mesUno;
    var mesDos;
    var anioUno;
    var anioDos;
    var betweenMes = new Array();
    var sumaDias = 0;
    var maxDias = 1;
    var tr;
    var ObjCoordenadas = new Array();
    var plantillaInfoWin = new Array();
    var infowindow;
    var geocoder;
    var infoDir;
    

    buttonModalMapa.click(function () {
        
        var sumaTotal;
        ObjCoordenadas = []

        var minVal = minDate.val();
        var minrVal = minVal.split('/').join('-');
        var minfVal = moment(minrVal, 'DD-MM-YYYY').format("YYYY-MM-DD");

        var maxVal = maxDate.val();
        var maxrVal = maxVal.split('/').join('-');
        var maxfVal = moment(maxrVal, 'DD-MM-YYYY').format("YYYY-MM-DD");
        
        sumaTotal = CalcularDias(minDate.val(), maxDate.val());
        var minfVal = moment(minrVal, 'DD-MM-YYYY').format("YYYY-MM-DD");
        var tr = $("#tbl_body_table_bitacora tr");

        if (minVal == "" || maxVal == "" || (sumaTotal > maxDias) || (maxfVal < minfVal) || (tr[0].innerText == "No hay registros" ) ) {

            swal({
                title: "Filtre fecha de inicio y fin",
                text: "Maximo de rango 3 meses",
                icon: "warning",
                buttons: {

                    cancel: {
                        text: "Cancelar",
                        visible: false,
                    },
                    confirm: {
                        text: "Aceptar",
                        visible: true,
                    },
                },

                dangerMode: true,

            })

        } else {

            var ModalOn = ModalMapa.modal();
            var bool = true;
            if (ModalOn != "") {
                tr = $("#tbl_body_table_bitacora tr");               
                for (var i = 0; i < tr.length; i++) {
                    var latitud = parseFloat(tr[i].cells[6].innerText);
                    var longitud = parseFloat(tr[i].cells[7].innerText);
                    var cliente = tr[i].cells[2].innerText;

                    ObjCoordenadas.push(
                        {
                            lat: latitud,
                            lng: longitud,
                            cliente: cliente
                        }

                    )

                }
               ObetenerMarcadoresGooogleMaps(bool, ObjCoordenadas )
            }
            

        }                               

    });

    function CalcularDias(valFechaUno, valFechaDos) {
        var sumaDiasTotal;

        if (valFechaUno != "" && valFechaDos != "") {
            betweenMes = [];
            sumaDias = 0;

            var min = valFechaUno;
            var minr = min.split('/').join('-');
            var minf = moment(minr, 'DD-MM-YYYY').format("YYYY-MM-DD");

            var max = valFechaDos;
            var maxr = max.split('/').join('-');
            var maxf = moment(maxr, 'DD-MM-YYYY').format("YYYY-MM-DD");

            var fechamIn = new Date(minf);
            var fechamFin = new Date(maxf);

            var diasBettwen;
            var cantMesesSobrant;
            var totalMeses;
            var position = 0;
            var mesUnoInput;
            var mesDosInput;
            var diaUno;
            var diaDos;
            var diasMesUno;
            var diasMesDos;
            

            mesUno = fechamIn.getMonth() + 1;
            mesDos = fechamFin.getMonth() + 1;

            anioUno = fechamIn.getFullYear();
            anioDos = fechamFin.getFullYear();

            mesUnoInput = fechamIn.getMonth() + 1;
            mesDosInput = fechamFin.getMonth() + 1;

            diaUno = fechamIn.getDate() + 1;
            diaDos = fechamFin.getDate() + 1;

            diasMesUno = new Date(anioUno, mesUnoInput, 0).getDate();
            diasMesDos = new Date(anioDos, mesDosInput, 0).getDate();

            if (anioUno != anioDos) {
                cantMesesSobrant = 12 - mesUno;
                totalMeses = cantMesesSobrant + mesDos
                if (cantMesesSobrant == 0) {
                    mesUno = 0;
                    anioUno = anioUno + 1;
                }
                for (var i = mesUno; i < totalMeses; i++) {
                    if (i != mesUno) {
                        betweenMes.push(i);


                        diasBettwen = new Date(anioUno, betweenMes[position], 0).getDate();
                        sumaDias = sumaDias + diasBettwen;
                        sumaDias = sumaDias;
                        position++;

                        if (i == 12) {
                            totalMeses = totalMeses - (position);
                            i = 0;
                            mesUno = totalMeses;
                            anioUno = anioUno + 1;
                        }
                    }
                }

                diasMesUno = diasMesUno - diaUno;
                diasMesDos = diasMesDos - diaDos;
                sumaDiasTotal = diasMesUno + diasMesDos + sumaDias;

            } else {
                if (mesUnoInput != mesDosInput) {

                    for (var i = mesUno; i < mesDos; i++) {
                        if (i != mesUno) {
                            betweenMes.push(i);
                            diasBettwen = new Date(anioUno, betweenMes[position], 0).getDate();
                            sumaDias = sumaDias + diasBettwen;
                            sumaDias = sumaDias;
                            position++;

                        }

                    }

                    diasMesUno = diasMesUno - diaUno;
                    diasMesDos = diasMesDos - diaDos;

                    sumaDiasTotal = diasMesUno + diasMesDos + sumaDias;

                } else {
                    sumaDiasTotal = diaDos - diaUno ;
                }
              
            }

            return sumaDiasTotal;
        } else {

            sumaDiasTotal = maxDias + 1;

            return sumaDiasTotal;
        }

    }



  function  ObetenerMarcadoresGooogleMaps(bool, coordenadasXY) {
      var jasonCoord = { arrayCord: coordenadasXY };
      if (bool == true) {
          if ("geolocation" in navigator) { //check Geolocation available 

              initializeGMap(jasonCoord);
             // initializeGMap(jasonCoord.arrayCord[0].lat, jasonCoord.arrayCord[0].lon);

              for (const i in jasonCoord.arrayCord) {

                //  addMarker(jasonCoord.arrayCord[i]);
              }
           

          } else {
              console.log("Geolocation not available!");
          }
            
      }

    }

  

    function initializeGMap(jasonCoord) {
        myLatlng = new google.maps.LatLng(jasonCoord.arrayCord[0].lat, jasonCoord.arrayCord[0].lng);
        
        var myOptions = {
            zoom: 18,
            zoomControl: true,
            center: myLatlng,
            mapTypeId: google.maps.MapTypeId.ROADMAP,   
        };
        map = new google.maps.Map(document.getElementById("map_canvas"), myOptions);
        infowindow = new google.maps.InfoWindow();
        geocoder = new google.maps.Geocoder;
        addMarker(jasonCoord)
        
            // addMarker({ lat: jasonCoord.arrayCord[i].lat, lng: jasonCoord.arrayCord[i].lng }, jasonCoord.arrayCord[i].cliente );
       /* addMarker({ lat: -6.7697739, lng: -79.8513036 })
        addMarker({ lat: -6.770649, lng: -79.849892})*/
       

        function addMarker(jasonCoord) {
            infoDir = geocodeLatLng(geocoder, jasonCoord)
            console.log(infoDir);
            for ( i in jasonCoord.arrayCord) {
                
                var position = new google.maps.LatLng(jasonCoord.arrayCord[i].lat, jasonCoord.arrayCord[i].lng);
              /*  plantillaInfoWin = `<div class="form-group">
                                 <p style="font-size:14px;font-weight:bold">${jasonCoord.arrayCord[i].cliente}</p> `*/

                myMarker = new google.maps.Marker({
                    position: position,
                    map: map    
                });

                myMarker.addListener('click', (function (myMarker, i) {
                    return function () {
                        infowindow.setContent(`<div class="form-group">
                                 <p style="font-size:14px;font-weight:bold">${jasonCoord.arrayCord[i].cliente}</p> 
                                 <p style="font-size:12px"><span style="font-weight:bold">Dirreción:    </span>${infoDir[i]}</p>`);
                        infowindow.setOptions({ maxWidth: 200 });
                        infowindow.open(map, myMarker);
                    }
                })(myMarker, i));
            }
        }

       // addMarker({ lat: -6.7697764, lon: -79.8513075 }) 
    }

    function geocodeLatLng(geocoder, jasonCoord) {
        var latlng;
        //var input = document.getElementById('latlng').value;
        //var latlngStr = input.split(',', 2);
        for (i in jasonCoord.arrayCord) {
            latlng = { lat: parseFloat(jasonCoord.arrayCord[i].lat), lng: parseFloat(jasonCoord.arrayCord[i].lng) };
            geocoder.geocode({ 'location': latlng }, function (results, status) {
                if (status === 'OK') {
                    if (results[0]) {
                        plantillaInfoWin.push(results[0].formatted_address);

                    } else {
                        window.alert('No results found');
                    }
                } else {
                   // window.alert('Geocoder failed due to: ' + status);
                }
            });
        }
        return plantillaInfoWin;
        // addMarker({ lat: -6.7697764, lon: -79.8513075 }) 
    }

    

    // Re-init map before show modal
    $('#ModalMapa').on('show.bs.modal', function (event) {
        $("#location-map").css("width", "100%");
        $("#map_canvas").css("width", "100%");
    });

    // Trigger map resize event after modal shown
    $('#ModalMapa').on('shown.bs.modal', function () {
        google.maps.event.trigger(map, "resize");
        map.setCenter(myLatlng);
    });
}); 