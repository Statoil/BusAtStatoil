var shuttle = {};

(function (ns) {
    ns.newShuttleView = function () {
        function showTransportInfo() {
            $('#TransportInfo').html(" ");
            $.getJSON("/Home/GetTransportInformation?city=" + $('#ShuttleCity').val() + "&kind=" + $('#ShuttleService').val(), function (json) {
                $.each(json, function (val, text) {
                    $('#TransportInfo').html(text['Information']);
                })                
            });
        }

        function showgeolocation(position) {
            //Used for setting city list only
            var latlng = new google.maps.LatLng(position.coords.latitude, position.coords.longitude);
            var geocoder = new google.maps.Geocoder();
            geocoder.geocode({ 'latLng': latlng }, function (results, status) {
                if (status == google.maps.GeocoderStatus.OK) {
                    var city = results[4].formatted_address;
                    city = city.substring(0, city.indexOf(','));
                    $('#ShuttleCity').val(city);
                    $('#ShuttleCity').selectmenu('refresh');
                    $('#ShuttleService').trigger('change');
                }
            });

            return latlng;
        }

        return {
            initializeLocations: function () {
                if (navigator.geolocation) {
                    navigator.geolocation.getCurrentPosition(showgeolocation);
                } else {
                    error('not supported');
                }

                $('#ShuttleCity').empty();
                $('#ShuttleCity').selectmenu('refresh');

                $.getJSON("/Home/GetOfficeCities", function (json) {
                    $('#ShuttleCity').append($('<option></option>').val('').text(''));
                    $.each(json, function (val, text) {
                        $('#ShuttleCity').append(
                            $('<option></option>').val(text).html(text)
                        )
                    }
                )
                });
                $('#ShuttleCity').selectmenu('refresh');

                $('#ShuttleCity').live('change', function () {
                    showTransportInfo()
                });
                $('#ShuttleService').live('change', function () {
                    showTransportInfo()
                });

            }
        };
    };
})(shuttle);