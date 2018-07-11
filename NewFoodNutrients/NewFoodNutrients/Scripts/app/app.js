var vm = (function () {
    var recipeVM = (function () {
        function DropDownsSource () {
            this.FoodTypesDD = ko.observableArray([]);
            this.FoodsDD = ko.observableArray([]);
            this.IngredientTypesDD = ko.observableArray([]);
            this.IngredientsDD = ko.observableArray([]);
            this.UnitOfMeasureDD = ko.observableArray([]);
        }

        function Recipe(data) {
            this.Id = ko.observable(data.Id());
            this.Title = ko.observable(data.Title());
            this.ObjectState = ko.observable(data.ObjectState());
            this.FoodTypeId = ko.observable(data.FoodTypeId());
            this.FoodId = ko.observable(data.FoodId());
            this.selectedFood = ko.observable(data.FoodId());
            this.AllFoods = ko.observableArray([]);
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


        function Ingredient () {
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
        }


        var recipeViewModel = function (data) {

            var mappedViewModel = ko.mapping.fromJS(data);

            var dropDownsSource = ko.observable(
                new DropDownsSource()
                    .FoodTypesDD(mappedViewModel.FoodTypes())
                    .FoodsDD(mappedViewModel.Foods())
                    .IngredientTypesDD(mappedViewModel.IngredientTypes())
                    .IngredientsDD(mappedViewModel.Ingredients())
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
            );

            //Knockout Subscribe example
            selectedFoodType.subscribe(function (value) {
                recipe().FoodTypeId(value);
            });

            var foodTypeChange = function(obj) {
                obj.dropDownsSource().FoodsDD(filteredFoods());
                obj.selectedFood(mappedViewModel.FoodId());
                obj.flagRecipeAsEdited();
            };

            var foodChange = function (obj) {
                obj.flagRecipeAsEdited();
                if (!obj.selectedFood())
                    return;
                obj.recipe().FoodId(obj.selectedFood());
            };

            var changeIngredientType = function (obj, event) {
                if (obj.ObjectState !== ObjectState.Added)
                    obj.ObjectState(ObjectState.Modified);
                var selected = this.IngredientTypeId();
                var contextFilteredIngredients = ko.observableArray([]);
                contextFilteredIngredients(ko.utils.arrayFilter(mappedViewModel.ContextIngredients(),
                    function (ci) {
                        return ci.IngredientTypeId() === parseInt(selected);
                    }));
                var contextFilteredIds = ko.observableArray([]);
                if (contextFilteredIngredients()) {
                    for (var x = 0; x < contextFilteredIngredients().length; x++) {
                        contextFilteredIds.push(contextFilteredIngredients()[x].Id().toString());
                    }
                }
                var newArray = ko.observableArray([]);
                newArray(ko.utils.arrayFilter(mappedViewModel.Ingredients(),
                    function (i) {
                        if (contextFilteredIngredients().length > 0) {
                            return contextFilteredIds().indexOf(i.Value()) >= 0;
                        }
                    }));
                obj.IngredientsDD(newArray());
                obj.Amount(0);
                obj.UnitOfMeasureId("");

                return true;
            };

            var changeIngredient = function (obj, event) {
                if(obj.ObjectState!==ObjectState.Added)
                    obj.ObjectState(ObjectState.Modified);
            };

            var changeAmount = function (obj, event) {
                if (obj.ObjectState !== ObjectState.Added)
                    obj.ObjectState(ObjectState.Modified);
            };
            var changeUnitOfMeasure = function (obj, event) {
                if (obj.ObjectState !== ObjectState.Added)
                    obj.ObjectState(ObjectState.Modified);
            };
            var addRecipeIngredient = function () {
                recipe().RecipeIngredients.push(new Ingredient()
                    .ObjectState(ObjectState.Added)
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

            var flagRecipeAsEdited = function () {
                if (recipe().ObjectState() !== ObjectState.Added) {
                    recipe().ObjectState(ObjectState.Modified);
                }


                return true;
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
                changeAmount: changeAmount,
                changeUnitOfMeasure: changeUnitOfMeasure,
                removeRecipeIngredient: removeRecipeIngredient,
                flagRecipeAsEdited: flagRecipeAsEdited,
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

    