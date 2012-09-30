$(document).ready(function () {

    $("#checkoutwindow").kendoWindow({
        actions: ["Custom", "Refresh", "Maximize", "Minimize", "Close"],
        draggable: false,
        modal: true,
        resizable: false,
        visible: false,
        title: "Change Tax Rate",
    });
    $("#taxwindow").kendoWindow({
        actions: ["Custom", "Refresh", "Maximize", "Minimize", "Close"],
        draggable: false,
        modal: true,
        resizable: false,
        visible: false,
        title: "Change Tax Rate",
    });
    $("#createcategorywindow").kendoWindow({
        actions: ["Custom", "Refresh", "Maximize", "Minimize", "Close"],
        draggable: false,
        modal: true,
        resizable: false,
        visible: false,
        title: "Create Category",
    });
    $("#createitemwindow").kendoWindow({
        actions: ["Custom", "Refresh", "Maximize", "Minimize", "Close"],
        modal: true,
        visible: false,
        title: "Create Item",
    });
    $("#changetax").click(function () {
        var win = $("#taxwindow").data("kendoWindow");
        win.center();
        win.open();
    });
    $("#createcategory").click(function () {
        var win = $("#createcategorywindow").data("kendoWindow");
        win.center();
        win.open();
    });
    $("#createitem").click(function () {
        var win = $("#createitemwindow").data("kendoWindow");
        win.center();
        win.open();
    });

});