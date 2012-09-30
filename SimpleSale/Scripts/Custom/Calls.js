function checkoutViewModel() {
    var self = this;

    self.categories = ko.observableArray();
    self.categoryToAdd =  ko.observable(""),

    $.getJSON("/api/default1", function (data) {
        var viewModel = {
            // data
            categories: ko.observableArray(ko.toProtectedObservableItemArray(data)),
            categoryToAdd: ko.observable(""),
            selectedCategory: ko.observable(new ko.protectedObservableItem(data[0])),

            // behaviors
            addCategory: function () {
                var newCategory = { Name: self.categoryName() };
                this.categoryToAdd("");

                ajaxAdd("/api/default1/", ko.toJSON(newCategory), function (data) {
                    viewModel.categories.push(new ko.protectedObservableItem(data));
                });
            },

            selectCategory: function () {
                viewModel.selectedCategory(this);
            },

            // Data (Drills)
            currentCategoryItems: ko.observableArray([]),
            categoryToAdd: ko.observable(""),
            useItemEditTemplate: ko.observable(null),
            hoverItem: ko.observable(),
            clickedItem: ko.observable(null),

            // Behaviors (Drills)
            editItem: function () {
                viewModel.useItemEditTemplate(true);
            },

            categoryNameFor: function (id) {
                var tagItem = ko.utils.arrayFirst(viewModel.categories(), function (item) {
                    return item.Id === parseInt(id);
                });
                return tagItem.Name;
            },

            saveItem: function () {
                viewModel.selectedItem().commit();
                var item = viewModel.selectedItem();
                viewModel.useItemEditTemplate(null);
                ajaxUpdate("/api/items/" + item.Id, ko.toJSON(item));
            }
        }
    })
};
        