/* http://www.knockmeout.net/2011/03/guard-your-model-accept-or-cancel-edits.html */
//wrapper for an observable that protects value until committed
ko.protectedObservable = function (initialValue) {
    //private variables
    var _temp = initialValue;
    var _actual = ko.observable(initialValue);

    var result = ko.dependentObservable({
        read: function () {
            return _actual();
        },
        write: function (newValue) {
            _temp = newValue;
        }
    });

    //commit the temporary value to our observable, if it is different
    result.commit = function () {
        if (_temp !== _actual()) {
            _actual(_temp);
        }
    };

    //notify subscribers to update their value with the original
    result.reset = function () {
        _actual.valueHasMutated();
        _temp = _actual();
    };

    return result;
};








/// <reference path="knockout-1.3.0beta.debug.js" />
/// <reference path="jquery-1.6.2.js" />

ko.bindingHandlers.executeOnEnter = {
    init: function (element, valueAccessor, allBindingsAccessor, viewModel) {
        var value = valueAccessor();
        $(element).keypress(function (event) {
            var keyCode = (event.which ? event.which : event.keyCode);
            if (keyCode === 13) {
                value.call(viewModel);
                return false;
            }
            return true;
        });
    }
};