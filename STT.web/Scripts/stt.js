var stt = {};
(function (ns) {    
    ns.newSttRepository = function () {
        var locationObject = {};
        var cubeList = [];

        var isEmpty = function (ob) {
            for (var i in ob) {
                return false;
            }
            return true;
        };

        return {
            getOfficeCodes: function (callback) {
                callback(officecodes);
            },
            getLocations: function (callback) {
                if (isEmpty(locationObject)) {
                    $.getJSON("/Home/GetLocations", function (json) {
                        locationObject = json;
                        callback(json);
                    });
                } else {
                    callback(locationObject);
                }
                
            }                       
        };
    };
          
})(stt);