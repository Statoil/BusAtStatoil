var geotests = {};
var pos;
var geoOpts = {};
var geolocMap;
var bounds;
var locicon;

(function (ns) {
    ns.newGeotestView = function () {


        function showgeoloc(position) {
            var s = document.querySelector('#geolocaccuracy');
            var a = document.querySelector('#geolocaddress');
            var c = document.querySelector('#geoloccoords');

            s.innerHTML = position.coords.accuracy + " m";

            var latlng = new google.maps.LatLng(position.coords.latitude, position.coords.longitude);
            var geocoder = new google.maps.Geocoder();

            c.innerHTML = latlng;

            geocoder.geocode({ 'latLng': latlng }, function (results, status) {
                if (status == google.maps.GeocoderStatus.OK) {
                    //p.innerHTML = results[3].formatted_address;
                    a.innerHTML = results[0].formatted_address;
                }
            });

            return latlng;
        }

        function showiploc(position) {
            var s = document.querySelector('#iplocaccuracy');
            var a = document.querySelector('#iplocaddress');
            var c = document.querySelector('#iploccoords');

            s.innerHTML = position.coords.accuracy + " m";

            var latlng = new google.maps.LatLng(position.coords.latitude, position.coords.longitude);
            var geocoder = new google.maps.Geocoder();

            c.innerHTML = latlng;

            geocoder.geocode({ 'latLng': latlng }, function (results, status) {
                if (status == google.maps.GeocoderStatus.OK) {
                    //p.innerHTML = results[3].formatted_address;
                    a.innerHTML = results[0].formatted_address;
                }
            });

            return latlng;
        }

        function getCurrentIPPosition (success, error, opts){
            var locationAPIs = 2,
                errorTimer,
                googleTimer,
                calledEnd,
                endCallback = function(){
                    if(calledEnd){return;}
                    if(pos){
                        calledEnd = true;
                        success($.extend({timestamp: new Date().getTime()}, pos));
                        resetCallback();
                        if(window.JSON && window.sessionStorage){
                            try{
                                sessionStorage.setItem('storedGeolocationData654321', JSON.stringify(pos));
                            } catch(e){}
                        }
                    } else if(error && !locationAPIs) {
                        calledEnd = true;
                        resetCallback();
                        error({ code: 2, message: "POSITION_UNAVAILABLE"});
                    }
                },
                googleCallback = function(){
                    locationAPIs--;
                    getGoogleCoords();
                    endCallback();
                },
                resetCallback = function(){
                    $(document).unbind('google-loader', resetCallback);
                    clearTimeout(googleTimer);
                    clearTimeout(errorTimer);
                },
                getGoogleCoords = function(){
                    if(pos || !window.google || !google.loader || !google.loader.ClientLocation){return false;}
                    var cl = google.loader.ClientLocation;
                    pos = {
                        coords: {
                            latitude: cl.latitude,
                            longitude: cl.longitude,
                            altitude: null,
                            accuracy: 43000,
                            altitudeAccuracy: null,
                            heading: parseInt('NaN', 10),
                            velocity: null
                        },
                        //extension similiar to FF implementation
                        address: $.extend({streetNumber: '', street: '', premises: '', county: '', postalCode: ''}, cl.address)
                    };
                    return true;
                },
                getInitCoords = function(){
                    if(pos){return;}
                    getGoogleCoords();
                    if(pos || !window.JSON || !window.sessionStorage){return;}
                    try{
                        pos = sessionStorage.getItem('storedGeolocationData654321');
                        pos = (pos) ? JSON.parse(pos) : false;
                        if(!pos.coords){pos = false;} 
                    } catch(e){
                        pos = false;
                    }
                }
            ;
				
            getInitCoords();
				
            if(!pos){
                if(geoOpts.confirmText && !confirm(geoOpts.confirmText.replace('{location}', location.hostname))){
                    if(error){
                        error({ code: 1, message: "PERMISSION_DENIED"});
                    }
                    return;
                }
                $.ajax({
                    url: 'http://freegeoip.net/json/',
                    dataType: 'jsonp',
                    cache: true,
                    jsonp: 'callback',
                    success: function(data){
                        locationAPIs--;
                        if(!data){return;}
                        pos = pos || {
                            coords: {
                                latitude: data.latitude,
                                longitude: data.longitude,
                                altitude: null,
                                accuracy: 43000,
                                altitudeAccuracy: null,
                                heading: parseInt('NaN', 10),
                                velocity: null
                            },
                            //extension similiar to FF implementation
                            address: {
                                city: data.city,
                                country: data.country_name,
                                countryCode: data.country_code,
                                county: "",
                                postalCode: data.zipcode,
                                premises: "",
                                region: data.region_name,
                                street: "",
                                streetNumber: ""
                            }
                        };
                        endCallback();
                    },
                    error: function(){
                        locationAPIs--;
                        endCallback();
                    }
                });
                clearTimeout(googleTimer);
                if (!window.google || !window.google.loader) {
                    googleTimer = setTimeout(function(){
                        //destroys document.write!!!
                        if (geoOpts.destroyWrite) {
                            document.write = domWrite;
                            document.writeln = domWrite;
                        }
                        $(document).one('google-loader', googleCallback);
                        $.webshims.loader.loadScript('http://www.google.com/jsapi', false, 'google-loader');
                    }, 800);
                } else {
                    locationAPIs--;
                }
            } else {
                setTimeout(endCallback, 1);
                return;
            }
            if(opts && opts.timeout){
                errorTimer = setTimeout(function(){
                    resetCallback();
                    if(error) {
                        error({ code: 3, message: "TIMEOUT"});
                    }
                }, opts.timeout);
            } else {
                errorTimer = setTimeout(function(){
                    locationAPIs = 0;
                    endCallback();
                }, 10000);
            }
        }


        function createmap(lalo) {
            if ((geolocMap == null) || (typeof geolocMap == 'undefined')) {
                var myMapOptions = {
                    zoom: 15,
                    center: lalo,
                    mapTypeControl: false,
                    navigationControlOptions: { style: google.maps.NavigationControlStyle.SMALL },
                    mapTypeId: google.maps.MapTypeId.ROADMAP
                };

                var geomapcanvas = document.getElementById('geomapcanvas');
                geolocMap = new google.maps.Map(geomapcanvas, myMapOptions);
            }

            if ((bounds == null) || (typeof bounds == 'undefined')) {
                bounds = new google.maps.LatLngBounds();
            }
        }

        function showlocoptions(options) {
            alert(options);
        }

        function showlocationonmap(position) {
            var geomapcanvas = document.getElementById('geomapcanvas');
            geomapcanvas.style.height = '300px';
            geomapcanvas.style.width = '400px';

            var latlng = new google.maps.LatLng(position.coords.latitude, position.coords.longitude);
            createmap(latlng);

            //if (typeof gMap != 'undefined') {
            locMarker = new google.maps.Marker({
                position: latlng,
                map: geolocMap,
                title: "x",
                icon: 'http://chart.apis.google.com/chart?chst=d_map_pin_letter&chld=*|8888FF'  
            });
            
            bounds.extend(locMarker.getPosition());
            //ToDo: do a test if bounds has only 1 marker
            geolocMap.fitBounds(bounds);
            //}
        }

        function errorHandler(err) {
            switch (error.code) {
                case error.TIMEOUT:
                    alert('Timeout');
                    break;
                case error.POSITION_UNAVAILABLE:
                    alert('Position unavailable');
                    break;
                case error.PERMISSION_DENIED:
                    alert('Permission denied');
                    break;
                case error.UNKNOWN_ERROR:
                    alert('Unknown error');
                    break;
            }
        }

        return {
            initializeGeotests: function (callback) {
                geolocMap = null;
                bounds = null;

                navigator.geolocation.getCurrentPosition(showgeoloc);
                navigator.geolocation.getCurrentPosition(showlocationonmap, errorHandler, showlocoptions);

                getCurrentIPPosition(showiploc);
                getCurrentIPPosition(showlocationonmap, errorHandler, showlocoptions);
            }
        };
    };
})(geotests);
