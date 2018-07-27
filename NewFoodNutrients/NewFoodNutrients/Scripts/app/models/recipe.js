function Recipe(data) {
    this.Id = ko.observable(data.Id());
    this.Title = ko.observable(data.Title());
    this.ObjectState = ko.observable(data.ObjectState());
    this.FoodTypeId = ko.observable(data.FoodTypeId());
    this.FoodId = ko.observable(data.FoodId());
    this.selectedFood = ko.observable(data.FoodId());
    this.AllFoods = ko.observableArray([]);
    this.RecipeIngredientsToDelete = ko.observableArray(data.RecipeIngredientsToDelete());
    this.RecipeIngredients = ko.observableArray([]);
    for (var x = 0; x < data.RecipeIngredients().length; x++) {
        this.RecipeIngredients.push(new Ingredient()
            .IngredientTypesDD(data.IngredientTypes())
            .IngredientTypeId(data.RecipeIngredients()[x].IngredientTypeId())
            .IngredientsDD(data.Ingredients())
            .Id(data.RecipeIngredients()[x].Id())
            .RecipeId(data.RecipeIngredients()[x].RecipeId())
            .IngredientId(data.RecipeIngredients()[x].IngredientId())
            .Amount(data.RecipeIngredients()[x].Amount())
            .UnitOfMeasureDD(data.UnitOfMeasures())
            .UnitOfMeasureId(data.RecipeIngredients()[x].UnitOfMeasureId())

        );
    }
}


var ObjectState = {
    Unchanged: 0,
    Added: 1,
    Modified: 2,
    Deleted: 3
};






