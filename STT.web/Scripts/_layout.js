var maintainServiceView;
var maintainNewsView;
var geotestView;

$('#maintainservice').live('pageinit', '#maintainservice', function () {
    maintainServiceView = maint.newMaintenanceView();
    maintainServiceView.initializeMaintainService();
});

$('#maintainnews').live('pageinit', '#maintainnews', function () {
    maintainNewsView = maint.newMaintenanceView();
    maintainNewsView.initializeMaintainNews();
});

$('#geotests').live('pageinit', '#geotests', function () {
    geotestView = geotests.newGeotestView();
    geotestView.initializeGeotests();
});
