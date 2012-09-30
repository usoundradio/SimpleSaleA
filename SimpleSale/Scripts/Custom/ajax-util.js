/// <reference path="jquery-1.6.2.js" />

$(function () {
    $.ajaxSetup({ cache: false });
});

function ajaxAdd(url, dataToSave, callback) {
    ajaxModify(url, dataToSave, "POST", "Category Added.", callback);
}

function ajaxUpdate(url, dataToSave, successCallback) {
    ajaxModify(url, dataToSave, "PUT", "Category Updated.", successCallback);
}

function ajaxDelete(url) {
    ajaxModify(url, null, "DELETE", "Category Deleted.");
}

function ajaxModify(url, dataToSave, httpVerb, successMessage, callback) {
    $.ajax(url, {
        data: dataToSave,
        type: httpVerb,
        dataType: 'json',
        contentType: 'application/json',
        success: function (data) {
            $("input[type=text]").val("");
            $.notifyBar({
                html: successMessage,
                cls: "success",
            });
            if (callback !== undefined) {
                callback(data);
            }
          },
        error: function () {
            $.notifyBar({
                html: "Unexpected error.",
                cls: "error",
            });
        }
    });
}
