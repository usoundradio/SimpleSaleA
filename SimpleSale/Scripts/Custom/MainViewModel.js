$("#categoryDialog").hide();
$("#itemDialog").hide();


function formatCurrency(value) {
    return "$" + value.toFixed(2);
}

function checkoutViewModel() {
    var self = this;
    self.categories = ko.observableArray();
    self.items = ko.observableArray();
    self.cart = ko.observableArray();
    self.selectedCategory = ko.observable();
    self.selectCatAddnew = ko.observable();
    self.tax = ko.observable(7);
    self.shipping = ko.observable(0);
    self.discount = ko.observable(0);
    self.realtotal = ko.observable(0);
    self.recieptitems = ko.observable();
    self.selectedItemId = ko.observable();

    self.testclick = function () {
        self.selectedResultValue = ko.observable($("#selectedCategoryvalue").val());
    }
    self.addToCart = function (product, event) {
        var selectedName = this.Name;
        var selectedPrice = (this.Price).toFixed(2);
        var CartItem = function (product, quantity) {
            var self = this; // Scope Trick
            self.quantity = ko.observable(quantity || 1);
            self.name = ko.observable(selectedName);
         
            self.cost = ko.computed(function () {
                return formatCurrency((selectedPrice * self.quantity()));
            })
            self.costcomp = ko.computed(function () {
                return (selectedPrice * self.quantity());
            })
            
        }
        
        // Instantiate a new CartItem object using the passed // in `Product` object, and then set a quantity of 1.
        var cart_item = new CartItem(product, 1);
        

        // Add the CartItem instance to the self.cart (Observable Array)
        self.cart.push(cart_item);

    };
    self.subtotal = ko.computed(function () {
        var subtotal = 0;
        $(self.cart()).each(function (index, cart_item) {
            subtotal += cart_item.costcomp();
        });
        return subtotal;
    });
    self.taxtotals = ko.computed(function () {
        var taxrate = ("." + self.tax());
        var addtaxprop = (("." + 10) * taxrate).toFixed(2);
        var totalwithtax = (self.subtotal() * addtaxprop).toFixed(2);
        return totalwithtax;
    });
    self.cartstotal = ko.computed(function () {
        var total = parseFloat(self.subtotal());
        var tax = parseFloat(self.taxtotals());
        var shipping = parseFloat(self.shipping());
        var discount = parseFloat(self.discount());

        var actualtotal = (shipping + tax + total) - discount;
        return actualtotal;
    });
    self.removeFromCart = function (cart_item, event) {
        // Remove the `cart_item` (which is a `CartItem` instance) from self.cart
        self.cart.remove(cart_item);
    };
    self.checkoutFromCart = function (product, event) {
        var win = $("#checkoutwindow").data("kendoWindow");
        win.center();
        win.open();
    }

    self.checkOutCustomer = function (cart, event) {
        var name = '"Name": ';
        var quantity = '"Quantity": ';


        $(self.cart()).each(function (index, cart_item) {
            var what = name += "Item:" + cart_item.name() + "," + "Quantity: " + cart_item.quantity();
            self.recieptitems = what;

        });
        
        var totalprice = $("#totaltest").text();
        var subtotal = $("#subtotal").text();
        var tax = $("#tax").text();
        var total = $("#total").text();
        var time = "1/1/1753 12:00:00 AM";

        var date = "1/1/1753 12:00:00 AM";
        var recieptItems = self.recieptitems;
        $.post("api/reciept", { Name: totalprice, Sum: subtotal, Tax: tax, Total: total, Time: time, Date: date, RecieptItems: recieptItems },
    function (data) {
            
    },
   
    "json")

        $(self.cart()).each(function (index, cart_item) {

            self.cart.remove(cart_item);
        });
    
          
      
        self.realtotal = ko.observable(self.realtotal() + self.cartstotal());
        var win = $("#checkoutwindow").data("kendoWindow");
        win.center();
        win.close();
    }
    self.editCategory = function () {
        $("#categoryDialog").dialog({
            buttons: {
                Save: function (category) {
                    $(this).dialog("close");
                    ajaxUpdate("/api/default1/" + self.selectedCategory().Id, ko.toJSON(self.selectedCategory()))
                    self.selectedCategory(category);
                },
                Cancel: function () {
                    $(this).dialog("close");
                }
            }
        })
    }
    self.editItem = function () {
        $
            ("#itemDialog").dialog({
            buttons: {
                Save: function (item) {
                    $(this).dialog("close");

                    ajaxUpdate("/api/items/" + self.selectedItemId().Id, ko.toJSON(self.selectedItemId()));

                    self.selectedItemId(item);

                },
                Cancel: function () {
                    $(this).dialog("close");
                }
            }
        })
    }

    self.removeCategory = function (category) {
        ajaxDelete("/api/default1/" + this.Id);
        self.categories.remove(category);


    }
    
    self.removeItem = function (item) {
        ajaxDelete("/api/items/" + this.Id);
        self.categories.remove(item);
      
            
        }
    
    self.addItem = function () {
        $.post("api/items/",
            $("#addItem").serialize(),
            function (value) {
                var win = $("#createitemwindow").data("kendoWindow");
                win.close();
                self.categories.push(value);
                getCategories();
                $("input[type=text]").val("");
            })
        }

               
    
    self.addCategory = function () {
        $.post("api/default1/",
            $("#addCategory").serialize(),
            function (value) {
                var win = $("#createcategorywindow").data("kendoWindow");
                win.center();
                win.close();
                self.categories.push(value);
                $("input[type=text]").val("");
                $("#savedStatus").slideDown().delay(3000).hide(500)
            },
            "json");
    }

  

    // Fetch Categories from server
    function getCategories() {
        $.getJSON("api/default1", function (data) {
             self.categories(data);

        });
    }

    
    getCategories();

}
ko.applyBindings(new checkoutViewModel, $("#checkout")[0]);

