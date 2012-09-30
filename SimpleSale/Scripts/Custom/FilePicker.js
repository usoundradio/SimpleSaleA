//Seting up Filepicker.io with your api key
filepicker.setKey('Ar548EgNMTtWCWcVCrkF5z');
document.getElementById('filepicker').onclick = function () {
    var win = $("#createitemwindow").data("kendoWindow");
    win.center();
    win.close();

    filepicker.getFile('image/*', function (url, metadata) {
        var results = $('#imgresult').text("Loading...")
        win.center();
        win.open();
        filepicker.getContents(url, true, function (data) {
            $("#thispicurl").val(url);

            var data_url = 'data:' + metadata.type + ';base64,' + data;
            results.html('<img width="200"  src="' + data_url + '" />');
        });

    });
}
