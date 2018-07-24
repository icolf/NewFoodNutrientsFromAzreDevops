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
            self.isValidIngredient = ko.computed(function () {
                if (self.IngredientId() && self.IngredientTypeId() && self.Amount()>0 && self.UnitOfMeasureId())
                    return true;
                else
                    return false;
            });
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

            var isValidRecipe = ko.computed(function () {
                var isValidRecipe = ko.computed(function () {
                    if (this().Title() && this().FoodTypeId() && this().FoodId())
                        return true;
                    else
                        return false;
                }, this);
                var isValidRecipeIngredients = ko.computed(function () {
                    if (!this().RecipeIngredients().length > 0)
                        return false;
                    var isRecipeIngredients = true;
                    ko.utils.arrayForEach(this().RecipeIngredients(),
                        function(ing) {
                            if (!ing.isValidIngredient())
                                isRecipeIngredients = false;
                        });
                    return isRecipeIngredients;
                }, this);
                return isValidRecipe() && isValidRecipeIngredients();
            }, recipe);


            var flagRecipeAsEdited = function () {
                if (recipe().ObjectState() !== ObjectState.Added) {
                    recipe().ObjectState(ObjectState.Modified);
                }


                return true;
            };

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
            var changeIngredientType = function (obj) {
                if (obj.ObjectState() !== ObjectState.Added) {
                    obj.ObjectState(ObjectState.Modified);
                }
                flagRecipeAsEdited();
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
                if (obj.ObjectState() !== ObjectState.Added) {
                    obj.ObjectState(ObjectState.Modified);
                }
                flagRecipeAsEdited();
            };

            var changeAmount = function (obj, event) {
                if (obj.ObjectState() !== ObjectState.Added) {
                    obj.ObjectState(ObjectState.Modified);
                }
                flagRecipeAsEdited();
            };
            var changeUnitOfMeasure = function (obj, event) {
                if (obj.ObjectState() !== ObjectState.Added) {
                    obj.ObjectState(ObjectState.Modified);
                }
                flagRecipeAsEdited();
            };
            var addRecipeIngredient = function () {
                recipe().RecipeIngredients.push(new Ingredient()
                    .ObjectState(ObjectState.Added)
                    .IngredientTypesDD(mappedViewModel.IngredientTypes())
                    .IngredientsDD(mappedViewModel.Ingredients())
                    .UnitOfMeasureDD(mappedViewModel.UnitOfMeasures())
                    .AllIngredients(mappedViewModel.ContextIngredients())
                );
            };
            var removeRecipeIngredient = function (recipeIngredient) {
                recipe().RecipeIngredients.remove(recipeIngredient);
                if (recipeIngredient.Id() > 0 && recipe().RecipeIngredientsToDelete().indexOf(recipeIngredient.Id()) === -1) {
                    recipe().RecipeIngredientsToDelete.push(recipeIngredient.Id());
                    flagRecipeAsEdited();
                }
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

            var cancel = function() {
                recipe(new Recipe(mappedViewModel));
            }


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
                isValidRecipe: isValidRecipe,
                save: save,
                cancel: cancel,
                ObjectState: ObjectState
            };
        };

        var recipeListViewModel = function (data) {

            var recipeListViewModel = ko.mapping.fromJS(data);
            var filteredRecipeListViewModel = ko.mapping.fromJS(data);
            var search = ko.observable("");
            var editRecipe = function (recipe) {
                var Id = recipe.Id();
                window.location = "/Recipes/Edit/" + Id;
            };
            var removeRecipe = function (localRecipe) {
                recipe = localRecipe;
                $('#deleteModal').modal('show');
            };
            var addRecipe = function (recipe) {
                window.location = "/Recipes/Create/";
            };

            var modalClose = function() {
                $('#deleteModal').modal('hide');

            };

            search.subscribe(function(value) {
                filteredRecipeListViewModel(ko.utils.arrayFilter(recipeListViewModel(),
                    function (recipe) {
                        if (!search())
                            return true;
                        return recipe.Title().indexOf(search()) !== -1 || recipe.FoodName().indexOf(search()) !== -1;
                    }));
                return true;
            });


            var modalSave = function() {
                $.ajax({
                    url: "/Home/Delete/",
                    type: "Post",
                    data: '{ RecipeId:"'+recipe.Id()+'"}',
                    contentType: "application/json",
                    success: function (data) {
                        recipeListViewModel(ko.mapping.fromJS(data));
                        console.log("Success");
                        $('#deleteModal').modal('hide');
                    }
                });
            }
            return {
                recipeListViewModel: recipeListViewModel,
                filteredRecipeListViewModel: filteredRecipeListViewModel,
                editRecipe: editRecipe,
                removeRecipe: removeRecipe,
                addRecipe: addRecipe,
                modalClose: modalClose,
                modalSave: modalSave,
                search: search
            };

        };

        return {
            recipeViewModel: recipeViewModel,
            recipeListViewModel: recipeListViewModel
        };
    })();
    return {
        recipeVM: recipeVM
    };

})();

    