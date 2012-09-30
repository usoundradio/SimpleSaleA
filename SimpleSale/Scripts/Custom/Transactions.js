function transactionViewModel() {
    var self = this;
    self.transactions = ko.observableArray();

    self.removeTransaction = function (reciept) {
        $.ajax({
            type: "delete",
            url: "/api/reciept/" + this.Id,
            success: function (
                ) {
                self.transactions.remove(reciept);

                $("#removedStatus").slideDown().delay(3000).hide(500);
            }
        });
    }
    self.openeditwindow = function () {
        var hello =  this.id;


        $("#window").fadeIn(1000);
    }

    

function getTransactions() {
    $.getJSON("api/reciept", function (data) {

    
        self.transactions(data);
    })
    }
    

getTransactions();
}

ko.applyBindings(new transactionViewModel, $("#transactions")[0]);

