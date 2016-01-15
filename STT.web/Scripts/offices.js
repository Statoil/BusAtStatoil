var offices = {};
var isinitialized = false;
var gMap;
var youMarker;
var officeMarker;
var officeMarkers = [];


(function (ns) {
    ns.newOfficeView = function () {

        function showgeolocation(position) {
            var s = document.querySelector('#geolocationstatus');
            var p = document.querySelector('#geolocationplace');
            var bounds = new google.maps.LatLngBounds();

            if (s == null)
                return;

            /*if (s.className == 'success') {
                // not sure why we're hitting this twice in FF, I think it's to do with a cached result coming back    
                return;
            }*/

            s.innerHTML = " (accuracy " + position.coords.accuracy + " m)";
            s.className = 'success';

            //document.querySelector('article').appendChild(mapcanvas);

            var latlng = new google.maps.LatLng(position.coords.latitude, position.coords.longitude);
            var geocoder = new google.maps.Geocoder();

            geocoder.geocode({ 'latLng': latlng }, function (results, status) {
                if (status == google.maps.GeocoderStatus.OK) {
                    //p.innerHTML = results[3].formatted_address;
                    p.innerHTML = results[0].formatted_address;
                    var city = results[4].formatted_address;
                    city = city.substring(0, city.indexOf(','));
                    $('#City').val(city);
                    $('#City').selectmenu('refresh');
                    updateOffices();
                    $('#mapcollapse').trigger('expand');
                }
            });

            return latlng;
        }

        function showmap(position) {
            var mapcanvas = document.getElementById('mapcanvas');
            mapcanvas.style.height = '250px';
            //mapcanvas.style.width = '400px';
            var latlng = new google.maps.LatLng(position.coords.latitude, position.coords.longitude);
            createmap(latlng);
            youMarker = new google.maps.Marker({
                position: latlng,
                map: gMap,
                title: "You are here!",
                icon: "http://www.google.com/mapfiles/arrow.png" // green arrow
            });
        }

        function createmap(lalo) {
            if ((gMap == null) || (typeof gMap == 'undefined')) {
                var myMapOptions = {
                    zoom: 15,
                    center: lalo,
                    mapTypeControl: false,
                    navigationControlOptions: { style: google.maps.NavigationControlStyle.SMALL },
                    mapTypeId: google.maps.MapTypeId.ROADMAP
                };

                var mapcanvas = document.getElementById('mapcanvas');
                gMap = new google.maps.Map(mapcanvas, myMapOptions);
            } 
        }

        function noofficemap() {
            bounds = new google.maps.LatLngBounds();
            if (typeof youMarker != 'undefined')
                bounds.extend(youMarker.getPosition());

            if (typeof officeMarker != 'undefined')
                officeMarker.setMap(null);

            if (typeof officeMarkers != 'undefined')
                for (var i = 0; i < officeMarkers.length; i++)
                    officeMarkers[i].setMap(null);
            officeMarkers = [];
        }

        function showofficemap(latitude, longitude, office) {
            
            var mapcanvas = document.getElementById('mapcanvas');
            mapcanvas.style.height = '300px';
            //mapcanvas.style.width = '400px';
            var latlng = new google.maps.LatLng(latitude, longitude);
            createmap(latlng);

            //if (typeof gMap != 'undefined') {
                officeMarker = new google.maps.Marker({
                    position: latlng,
                    map: gMap,
                    title: office,
                    icon: 'http://chart.apis.google.com/chart?chst=d_map_pin_letter&chld=S|FF69b0'  // Pink S
                });

                officeMarkers.push(officeMarker);
                bounds.extend(officeMarker.getPosition());
                //ToDo: do a test if bounds has only 1 marker
                gMap.fitBounds(bounds);
            //}
        }

        function updateMap() {
            noofficemap();
            $.getJSON("/Home/GetOfficesByCode?code=" + $('#Office').val(), function (json) {
                $.each(json, function (val, text) {
                    showofficemap(text['Lat'], text['Lon'], text['Name']);
                })
            });
        }

        function updateCities() {
            $('#City').append($('<option></option>').val('').text(''));

            $.getJSON("/Home/GetOfficeCities", function (json) {
                $.each(json, function (val, text) {
                    $('#City').append(
                        $('<option></option>').val(text).html(text)
                    )
                }
            )
            });

            $('#City').selectmenu('refresh');
        }

        function updateOffices() {
            $('#Office').empty();

            if ($('#City').val()) {
                $.getJSON("/Home/GetOfficesByCity?city=" + $('#City').val(), function (json) {
                    var first = json[0]['Code'];
                    $('#Office').append($('<option>').val(first.substring(0, first.indexOf('-') + 1))); // blank with code prefix
                    $.each(json, function (val, text) {
                        $('#Office').append(
                            $('<option>').val(text['Code']).html(text['Name'])
                        )
                    })
                });
            }
            $('#Office').selectmenu('refresh');            
        }

        return {
            initializeOffices: function (callback) {

                gMap = null;

                if (navigator.geolocation) {
                    navigator.geolocation.getCurrentPosition(showgeolocation);
                } else {
                    //alert("GeoLocation not supported");
                    console.log('GeoLocation not supported');
                }
                 
                $('#mapcollapse').bind('expand', function () {
                    navigator.geolocation.getCurrentPosition(showmap);
                });

                updateCities();

                if (!isinitialized) {//Something fishy with pageinit
                    isinitialized = true;

                    $('#City').live('change', function () {
                        updateOffices();
                        //Trouble with event sequencing, the Office is not updated when updatemap is called, hence making a short delay.
                        setTimeout(function () { $('#Office').trigger('change'); }, 200);
                    });

                    $('#Office').live('change', function () {
                        updateMap();
                    });
                }
            }
        };
    };
})(offices);
