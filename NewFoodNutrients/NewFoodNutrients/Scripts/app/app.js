var vm = (function () {
    var recipeVM = (function () {
        function DropDownsSource () {
            this.FoodTypesDD = ko.observableArray([]);
            this.FoodsDD = ko.observableArray([]);
            this.IngredientTypesDD = ko.observableArray([]);
            this.IngredientsDD = ko.observableArray([]);
            this.UnitOfMeasureDD = ko.observableArray([]);
        };

        function Recipe () {
            this.Title = ko.observable("");
            this.FoodType = ko.observable("");
            this.Food = ko.observable("");
            this.selectedFood = ko.observable("");
            this.RecipeIngredients = ko.observableArray([]);
            this.AllFoods = ko.observableArray([]);

        };

        function Ingredient () {
            var self = this;
            self.IngredientType = ko.observable("");
            self.selectedIngredientType = ko.observable("");
            self.selectedIngredient = ko.observable("");
            self.Ingredient = ko.observable("");
            self.Amount = ko.observable(0);
            self.UnitOfMeasure = ko.observable("");
            self.IngredientsDD = ko.observableArray([]);
            self.IngredientTypesDD = ko.observableArray([]);
            self.UnitOfMeasureDD = ko.observableArray([]);
            self.AllIngredients = ko.observableArray([]);
        };

        var recipeViewModel = function (data) {

            var mappedViewModel = ko.mapping.fromJS(data);

            var dropDownsSource = ko.observable(
                new DropDownsSource()
                    .FoodTypesDD(mappedViewModel.FoodTypes())
                    .IngredientTypesDD(mappedViewModel.IngredientTypes())
                    .UnitOfMeasureDD(mappedViewModel.UnitOfMeasures())
            );

            var selectedFoodType = ko.observable("");

            var selectedIngredientType = ko.observable("");

            //Filtered Foods DDL based on selected FoodType DDL
            var filteredFoods = ko.computed(function () {
                return ko.utils.arrayFilter(mappedViewModel.Foods(),
                    function (food) {
                        var foodFilter = food.Value();
                        return foodFilter === selectedFoodType();
                    });
            });

            var recipe = ko.observable(
                new Recipe()
                    .AllFoods(mappedViewModel.ContextFoods())
            );

            //Knockout Subscribe example
            selectedFoodType.subscribe(function (value) {
                recipe().FoodType(value);
                dropDownsSource().FoodsDD(filteredFoods());
            });

            var foodChange = function (obj) {
                if (!obj.recipe().selectedFood())
                    return;
                var text = obj.recipe().selectedFood().Text();
                var filteredFood = ko.computed(function () {
                    return ko.utils.arrayFilter(obj.recipe().AllFoods(),
                        function (f) {
                            return f.FoodName() === text;
                        });
                },
                    obj);
                obj.recipe().Food(filteredFood()[0].Id);
            };

            var changeIngredientType = function (obj, event) {
                var selected = this.IngredientType();
                this.IngredientsDD(mappedViewModel.Ingredients());
                var filteredIngredients = ko.computed(function () {
                    return ko.utils.arrayFilter(this.IngredientsDD(),
                        function (ingredient) {
                            var ingredientFilter = ingredient.Value();
                            return ingredientFilter === selected;
                        });
                },
                    obj);
                obj.IngredientsDD(filteredIngredients());
            };

            var changeIngredient = function (obj, event) {
                if (!obj.selectedIngredient())
                    return;
                var text = obj.selectedIngredient().Text();
                var ingredientId = ko.computed(function () {
                    return ko.utils.arrayFilter(obj.AllIngredients(),
                        function (i) {
                            return i.Name() === text;
                        });
                },
                    obj);
                obj.Ingredient(ingredientId()[0].Id());
            };
            var addRecipeIngredient = function () {
                recipe().RecipeIngredients.push(new Ingredient()
                    .IngredientTypesDD(mappedViewModel.IngredientTypes())
                    .IngredientsDD(mappedViewModel.Ingredients())
                    .AllIngredients(mappedViewModel.ContextIngredients())
                );
            };
            var removeRecipeIngredient = function (recipeIngredient) {
                recipe().RecipeIngredients.remove(recipeIngredient);
            };
            var save = function () {
                self = this;
            };
            return {
                mappedViewModel: mappedViewModel,
                filteredFoods: filteredFoods,
                dropDownsSource: dropDownsSource,
                selectedFoodType: selectedFoodType,
                recipe: recipe,
                foodChange: foodChange,
                addRecipeIngredient: addRecipeIngredient,
                selectedIngredientType: selectedIngredientType,
                changeIngredientType: changeIngredientType,
                changeIngredient: changeIngredient,
                removeRecipeIngredient: removeRecipeIngredient,
                save: save
            };
        };
        return {
            recipeViewModel: recipeViewModel
        }
    })();
    return {
        recipeVM: recipeVM
    }

})();

    