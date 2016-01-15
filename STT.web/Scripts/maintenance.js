var maint = {};

(function (ns) {
    ns.newMaintenanceView = function () {

        function showTransportInfo() {
            $('#submitservices').prop("disabled", true); 
            $('#info').val("");
            $('#moreinfo').val("");
            $.getJSON("/Home/GetTransportInformation?city=" + $('#city').val() + "&kind=" + $('#kind').val(), function (json) {
                $.each(json, function (val, text) {
                    $('#info').val(text['Information']);
                    $('#moreinfo').val(text['Moreinformation']);
                })
            });
            $('#submitservices').prop("disabled", false);
        }

        function showNews() {
            $('#submitnews').prop("disabled", true);
            $('#newsinfo').val("");
            $.getJSON("/Home/GetArticle?kind=" + $('#newskind').val(), function (json) {
                $.each(json, function (val, text) {
                    $('#newsinfo').val(text['Information']);
                })
            });
            $('#submitnews').prop("disabled", false);
        }

        return {
            initializeMaintainService: function () {
                showTransportInfo();

                $('#city').live('change', function () {
                    showTransportInfo()
                });
                $('#kind').live('change', function () {
                    showTransportInfo()
                });
            },

            initializeMaintainNews: function () {
                showNews();

                $('#newskind').live('change', function () {
                    showNews()
                });

            }
        };
    };
})(maint);