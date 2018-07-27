function Ingredient() {
    var self = this;
    self.ObjectState = ko.observable(ObjectState.Unchanged);
    self.Id = ko.observable(-1);
    self.RecipeId = ko.observable(-1);
    self.IngredientTypeId = ko.observable("");
    self.selectedIngredientType = ko.observable("");
    self.selectedIngredient = ko.observable("");
    self.IngredientId = ko.observable("");
    self.Amount = ko.observable(0);
    self.UnitOfMeasureId = ko.observable("");
    self.IngredientsDD = ko.observableArray([]);
    self.IngredientTypesDD = ko.observableArray([]);
    self.UnitOfMeasureDD = ko.observableArray([]);
    self.AllIngredients = ko.observableArray([]);
    self.isValidIngredient = ko.computed(function () {
        if (self.IngredientId() && self.IngredientTypeId() && self.Amount() > 0 && self.UnitOfMeasureId())
            return true;
        else
            return false;
    });
}
