function onDeviceReadyBuslocation() {
    alert("onDeviceReadyBuslocation");

    var loc = window.localStorage.getItem("navlocation");
    window.localStorage.removeItem("navlocation");
    document.querySelector('#OfficeLocation').innerHTML = 'The ' + loc + ' area have the following Statoil services:';

    var serviceUrl = "http://statoiltransport.cloudapp.net/Home/GetTransportInformation";

    var online = navigator.onLine || false;
    //buslocationView = buslocation.newBusLocationView();

    //var busView = busses.newbusview();
    alert("onDeviceReadyBuslocation 2");

    if (online) {
        locationGetAndStore(loc, "Office", "OfficeInfo", "Information");
        locationGetAndStore(loc, "Office", "OfficeMoreInfo", "Moreinformation");
        locationGetAndStore(loc, "Hotel", "HotelInfo", "Information");
        locationGetAndStore(loc, "Hotel", "HotelMoreInfo", "Moreinformation");
        locationGetAndStore(loc, "Airport", "AirportInfo", "Information");
        locationGetAndStore(loc, "Airport", "AirportMoreInfo", "Moreinformation");

        document.querySelector('#Storage').innerHTML = "Online";


        /*$.getJSON(serviceUrl + "?kind=Office&city=" + loc, function (data) {
            $.each(data, function (val, text) {
                document.querySelector('#OfficeInfo').innerHTML = text['Information'];
                document.querySelector('#OfficeMoreInfo').innerHTML = text['Moreinformation'];
                window.localStorage.setItem(loc + "-OfficeInfo", text['Information']);
                window.localStorage.setItem(loc + "-OfficeMoreInfo", text['Moreinformation']);
            })
        });
        $.getJSON(serviceUrl + "?kind=Hotel&city=" + loc, function (data) {
            $.each(data, function (val, text) {
                document.querySelector('#HotelInfo').innerHTML = text['Information'];
                document.querySelector('#HotelMoreInfo').innerHTML = text['Moreinformation'];
                window.localStorage.setItem(loc + "-HotelInfo", text['Information']);
                window.localStorage.setItem(loc + "-HotelMoreInfo", text['Moreinformation']);
            })
        });
        $.getJSON(serviceUrl + "?kind=Airport&city=" + loc, function (data) {
            $.each(data, function (val, text) {
                document.querySelector('#AirportInfo').innerHTML = text['Information'];
                document.querySelector('#AirportMoreInfo').innerHTML = text['Moreinformation'];
                window.localStorage.setItem(loc + "-AirportInfo", text['Information']);
                window.localStorage.setItem(loc + "-AirportMoreInfo", text['Moreinformation']);
            })
        });
        */
    } else {
        locationGet(loc, "Office", "OfficeInfo", "Information");
        locationGet(loc, "Office", "OfficeMoreInfo", "Moreinformation");
        locationGet(loc, "Hotel", "HotelInfo", "Information");
        locationGet(loc, "Hotel", "HotelMoreInfo", "Moreinformation");
        locationGet(loc, "Airport", "AirportInfo", "Information");
        locationGet(loc, "Airport", "AirportMoreInfo", "Moreinformation");


        document.querySelector('#Storage').innerHTML = "<b>Offline data</b>";

        /*document.querySelector('#OfficeInfo').innerHTML = window.localStorage.getItem(loc + "-OfficeInfo") || "... no data cached ...";
        document.querySelector('#OfficeMoreInfo').innerHTML = window.localStorage.getItem(loc + "-OfficeMoreInfo") || "... no data cached ...";
        document.querySelector('#HotelInfo').innerHTML = window.localStorage.getItem(loc + "-HotelInfo") || "... no data cached ...";
        document.querySelector('#HotelMoreInfo').innerHTML = window.localStorage.getItem(loc + "-HotelMoreInfo") || "... no data cached ...";
        document.querySelector('#AirportInfo').innerHTML = window.localStorage.getItem(loc + "-AirportInfo") || "... no data cached ...";
        document.querySelector('#AirportMoreInfo').innerHTML = window.localStorage.getItem(loc + "-AirportMoreInfo") || "... no data cached ...";
        */
    }
}

function locationGetAndStore(loc, kind, container, infofield) {
    var serviceUrl = "http://statoiltransport.cloudapp.net/Home/GetTransportInformation";
    alert("set" + loc);
    //locationGetAndStore(loc, "Office", "OfficeInfo", "Information");
    $.getJSON(serviceUrl + "?kind=" + kind + "&city=" + loc, function (data) {
        $.each(data, function (val, text) {
            document.querySelector('#' + container).innerHTML = text[infofield];
            window.localStorage.setItem(loc + "-" + container, text[infofield]);
        })
    });
};

function locationGet (loc, kind, container, infofield) {
    alert("get" + loc);
    window.localStorage.getItem(loc + "-" + container) || "... no data cached ...";
}

function mytest(p) {
    alert(p);
}