function addSpace(nStr) {
    nStr += '';
    x = nStr.split('.');
    x1 = x[0];
    x2 = x.length > 1 ? '.' + x[1] : '';
    var rgx = /(\d+)(\d{3})/ ;
    while (rgx.test(x1)) {
        x1 = x1.replace(rgx, '$1' + ' ' + '$2');
    }
    return x1 + x2;
}

function populateSelect(el, items) {
    el.options.length = 0;
    $.each(items, function() {
        el.options[el.options.length] = new Option(this.Name, this.Value);
    });
}

var Units = [
    { Name: 'Sm\u00b3', Value: 1.0 },
    { Name: 'boepd', Value: 58.0286 },
    { Name: 'Therm', Value: 2.63764 },
    { Name: 'kWh', Value: 0.09 },
    { Name: 'MSm\u00b3', Value: 1000000.0 },
    { Name: 'GSm\u00b3 (BCM)', Value: 1000000000.0 },            
    { Name: 'Mboepd', Value: 58028.6 },
    { Name: 'MMboepd', Value: 58028600 },            
    { Name: 'MMBTU', Value: 26.3764 },
    { Name: 'MJ', Value: 0.025 },
    { Name: 'GJ', Value: 25.0 },
    { Name: 'kcal', Value: 0.0001046375 },
    { Name: 'MWh', Value: 90 },
    { Name: 'GWh', Value: 90000 },
    { Name: 'NM3', Value: 1.05623947 }
];

