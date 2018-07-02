var vm = (function () {
    var recipeVM = (function () {
        function DropDownsSource () {
            this.FoodTypesDD = ko.observableArray([]);
            this.FoodsDD = ko.observableArray([]);
            this.IngredientTypesDD = ko.observableArray([]);
            this.IngredientsDD = ko.observableArray([]);
            this.UnitOfMeasureDD = ko.observableArray([]);
        }

        function Recipe (data) {
            this.Title = ko.observable(data.Title());
            this.FoodTypeId = ko.observable(data.FoodTypeId());
            this.FoodId = ko.observable(data.FoodId());
            this.selectedFood = ko.observable(data.FoodId());
            this.RecipeIngredients = ko.observableArray(data.RecipeIngredients());
            this.AllFoods = ko.observableArray([]);
        }

        function Ingredient () {
            var self = this;
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
        }

        var recipeViewModel = function (data) {

            var mappedViewModel = ko.mapping.fromJS(data);

            var dropDownsSource = ko.observable(
                new DropDownsSource()
                    .FoodTypesDD(mappedViewModel.FoodTypes())
                    .FoodsDD(mappedViewModel.Foods())
                    .IngredientTypesDD(mappedViewModel.IngredientTypes())
                    .UnitOfMeasureDD(mappedViewModel.UnitOfMeasures())
            );
            var selectedFoodType = ko.observable(mappedViewModel.FoodTypeId());
            var selectedFood = ko.observable(mappedViewModel.FoodId()); 
            var selectedIngredientType = ko.observable("");

            //Filtered Foods DDL based on selected FoodType DDL
            var filteredFoods = ko.computed(function () {
                var contextFilteredFoods = ko.observableArray([]);
                contextFilteredFoods(ko.utils.arrayFilter(mappedViewModel.ContextFoods(),
                    function(cf) {
                        return cf.FoodTypeId() === parseInt(selectedFoodType());
                    }));
                var contextFilteredIds = ko.observableArray([]);
                if (contextFilteredFoods()) {
                    for (var x = 0; x < contextFilteredFoods().length; x++) {
                        contextFilteredIds.push(contextFilteredFoods()[x].Id().toString());
                    }
                }


                var newArray = ko.observableArray([]);
                newArray(ko.utils.arrayFilter(mappedViewModel.Foods(),
                        function (f) {
                            if (contextFilteredFoods().length > 0) {
                                return contextFilteredIds().indexOf(f.Value())>=0;
                            }
                        }));
                return newArray();

            });

            var recipe = ko.observable(
                new Recipe(mappedViewModel)
                //.AllFoods(mappedViewModel.ContextFoods())
            );


            //Knockout Subscribe example
            selectedFoodType.subscribe(function (value) {
                recipe().FoodTypeId(value);
                dropDownsSource().FoodsDD(filteredFoods());
            });

            var foodTypeChange = function(obj) {
                obj.dropDownsSource().FoodsDD(filteredFoods());
                obj.selectedFood(mappedViewModel.FoodId());
            };

            var foodChange = function (obj) {
                if (!obj.selectedFood())
                    return;
                obj.recipe().FoodId(obj.selectedFood());
            };

            var changeIngredientType = function (obj, event) {
                var selected = this.IngredientTypeId();
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
                obj.IngredientId(ingredientId()[0].Id());
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
                $.ajax({
                    url: "/Recipes/Save",
                    type: "Post",
                    data: ko.toJSON(recipe),
                    contentType: "application/json",
                    success: function(data) {
                        ko.mapping.fromJS(data);
                        console.log("Success");
                        window.location = data.homePage;
                    }
                });
            };
            return { 
                mappedViewModel: mappedViewModel,
                filteredFoods: filteredFoods,
                dropDownsSource: dropDownsSource,
                selectedFoodType: selectedFoodType,
                selectedFood: selectedFood,
                recipe: recipe,
                foodTypeChange: foodTypeChange,
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
        };
    })();
    return {
        recipeVM: recipeVM
    };

})();

    