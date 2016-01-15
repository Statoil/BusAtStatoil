var buslocation = {};

(function (ns) {
    ns.newBusLocationView = function () {

        return {
            initializeBusLocation: function () {
                var myDate = new Date();
                var displayDate = (myDate.getMonth() + 1) + '/' + (myDate.getDate()) + '/' + myDate.getFullYear();
                var displayTime = myDate.getHours() + '' + myDate.getMinutes();
                //$.each($('#toAirport'),);
            }
        };
    };
})(buslocation);