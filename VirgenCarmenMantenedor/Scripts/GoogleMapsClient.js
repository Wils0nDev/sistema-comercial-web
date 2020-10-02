// Code goes here

$(document).ready(function () {

    var map = null;
    var myMarker;
    var myLatlng;
    var plantillaInfoWin = new Array();
    var infowindow;
    var geocoder;
    var infoDir;
    var btnGuardarMap = $('#btnGuardarMap');
    var btnGuardarMapPentrega = $('#btnGuardarMapPE');
    var buttonModals = $("#buttonModals");
    var modalMapClient = $("#modalMapClient");

    var ArrayMarkers = new Array();


    function ObetenerMarcadoresGooogleMaps() {

        if ("geolocation" in navigator) { //check Geolocation available 

            navigator.geolocation.getCurrentPosition(function (position) {
                var pos = {
                    lat: position.coords.latitude,
                    lng: position.coords.longitude
                };

                initializeGMap(pos)
            }, function () {
                handleLocationError(true, infoWindow, map.getCenter());
            });


        } else {
            console.log("Geolocation not available!");
        }

    }

    ObetenerMarcadoresGooogleMaps();

    function initializeGMap(pos) {
        myLatlng = new google.maps.LatLng(pos.lat, pos.lng);

        var myOptions = {
            zoom: 18,
            zoomControl: true,
            center: myLatlng,
            mapTypeId: google.maps.MapTypeId.ROADMAP,
        };
        map = new google.maps.Map(document.getElementById("map_canvas"), myOptions);
        infowindow = new google.maps.InfoWindow();
        geocoder = new google.maps.Geocoder;
        addMarker(myLatlng, geocoder, map)



        //BUSQUEDA DE DIRECCIONES POR INPUT///////////////////////////////////////////////////
        $("#btnDireccion").click(function () {

            var direccion = $("#txtDireccion").val();
            localizar(direccion, geocoder, map)
        });


    }


    function addMarker(myLatlng, geocoder, map) {
        var i = 0;

        var position = myLatlng;
        ArrayMarkers = new Array();

        infoDir = geocodeLatLng(geocoder, myLatlng);

        myMarker = new google.maps.Marker({
            position: position,
            map: map
        });

        myMarker.addListener('click', (function (myMarker, i) {
            return function () {
                infowindow.setContent(`<div class="form-group">
                                  
                                 <p style="font-size:12px"><span style="font-weight:bold">Dirreción: </span>${infoDir[i]}</p>`);
                infowindow.setOptions({ maxWidth: 200 });
                infowindow.open(map, myMarker);
            }
        })(myMarker, i));
        ArrayMarkers.push(myMarker)
        BuscarDireccionClick(ArrayMarkers)
        guardarCoords(position, infoDir);
    }

    function BuscarDireccionClick(ArrayMarkers) {

        map.addListener('click', function (e) {
            // ArrayMarkers.push(myMarker);
            var infoDirc = new Array();
            var marker = new google.maps.Marker({
                position: e.latLng,

            });
            marker.setMap(map);
            infoDirc = [];
            infoDirc = geocodeLatLng(geocoder, e.latLng);
            console.log(infoDirc);
            ArrayMarkers.push(marker)
            console.log(ArrayMarkers.length);
            for (var i = 0; i < ArrayMarkers.length; i++) {
                ArrayMarkers[0].setMap(null)
            }
            ArrayMarkers.shift();


            var index = 0;
            marker.addListener('click', (function (marker, index) {
                return function () {
                    infowindow.setContent(`<div class="form-group">
                                  
                                 <p style="font-size:12px"><span style="font-weight:bold">Dirreción: </span>${infoDirc[index]}</p>`);
                    infowindow.setOptions({ maxWidth: 200 });
                    infowindow.open(map, marker);
                }
            })(marker, index));

            guardarCoords(e.latLng, infoDirc);
        });
    }




    //BUSCAR DIRECCIONES MEDIANDO COORDENDAS
    function geocodeLatLng(geocoder, myLatlng) {
        var latlng;

        latlng = myLatlng;
        plantillaInfoWin = [];
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

        return plantillaInfoWin;
    }

    //Buscar Direccionas por address
    //BUSCAR DIRECCIONES MEDIANDO COORDENDAS
    function localizar(direccion, geocoder, map) {
        infoDir = [];
        geocoder.geocode({ 'address': direccion }, function (results, status) {
            if (status === 'OK') {
                var resultados = results[0].geometry.location
                map.setCenter(results[0].geometry.location);
                var marker = new google.maps.Marker({
                    map: map,
                    position: results[0].geometry.location
                });
                infoDir = geocodeLatLng(geocoder, resultados)
                marker.addListener('click', (function (marker) {
                    return function () {
                        infowindow.setContent(`<div class="form-group">
                                  
                                 <p style="font-size:12px"><span style="font-weight:bold">Dirreción: </span>${infoDir[0]}</p>`);
                        infowindow.setOptions({ maxWidth: 200 });
                        infowindow.open(map, marker);
                    }
                })(marker));

                ArrayMarkers.push(marker)
                for (var i = 0; i < ArrayMarkers.length; i++) {
                    ArrayMarkers[0].setMap(null)
                }
                ArrayMarkers.shift();
                guardarCoords(resultados, infoDir);

            } else {
                var mensajeError = "";
                if (status === "ZERO_RESULTS") {
                    mensajeError = "No hubo resultados para la dirección ingresada.";
                } else if (status === "OVER_QUERY_LIMIT" || status === "REQUEST_DENIED" || status === "UNKNOWN_ERROR") {
                    mensajeError = "Error general del mapa.";
                } else if (status === "INVALID_REQUEST") {
                    mensajeError = "Error de la web. Contacte con Name Agency.";
                }
                alert(mensajeError);
            }
        });
    }

    /////////////////////////

    function guardarCoords(position, infoDir) {

        btnGuardarMap.click(function () {

            var lat = position.lat();
            var lng = position.lng();
            var txtMrmDireccion = $('#ContentPlaceHolder1_txtMrmDireccion');
            var txtLatitud = $('#ContentPlaceHolder1_txtLatitud');
            var txtLongitud = $('#ContentPlaceHolder1_txtLongitud');
            var txtLatitudXa = $('#ContentPlaceHolder1_txtLatitudXa');
            var txtLongitudYa = $('#ContentPlaceHolder1_txtLongitudYa');
            txtMrmDireccion.val(infoDir[0]);
            txtLatitud.val(lat);
            txtLongitud.val(lng);
            txtLatitudXa.val(lat);
            txtLongitudYa.val(lng);
            // $('#modalMapClient').modal('toggle');
        });

        btnGuardarMapPentrega.click(function () {

            var lat = position.lat();
            var lng = position.lng();
            var txtMrmDireccionPE = $('#ContentPlaceHolder1_gvMrmPuntosEntrega_txtgvMrmDireccion');
            var txtLatitudPE = $('#ContentPlaceHolder1_gvMrmPuntosEntrega_txtLatitudPE');
            var txtLongitudPE = $('#ContentPlaceHolder1_gvMrmPuntosEntrega_txtLongitudPE');
            console.log(txtLatitudPE);
            txtMrmDireccionPE.val(infoDir[0]);
            txtLatitudPE.val(lat);
            txtLongitudPE.val(lng);


            // $('#modalMapClient').modal('toggle');
        });

    }





    // Re-init map before show modal
    $('#modalMapClient').on('show.bs.modal', function (event) {
        $("#location-map").css("width", "100%");
        $("#map_canvas").css("width", "100%");
    });

    // Trigger map resize event after modal shown
    $('#modalMapClient').on('shown.bs.modal', function () {
        //var btnmo = buttonModals.click().data();
        google.maps.event.trigger(map, "resize");
        map.setCenter(myLatlng);
    });




}); 