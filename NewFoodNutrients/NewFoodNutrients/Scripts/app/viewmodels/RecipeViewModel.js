﻿var RecipeViewModel = function () {

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
                function (cf) {
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
                        return contextFilteredIds().indexOf(f.Value()) >= 0;
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
                    function (ing) {
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

        var foodTypeChange = function (obj) {
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

        var changeIngredientField = function (obj, event) {
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
                contentType: "application/json"
            })
            .done(function (data) {
                $("#successSaveModal").modal("show");
                console.log("Success");
                mappedViewModel = ko.mapping.fromJS(data.vm);
                recipe(new Recipe(mappedViewModel));
            })
            .fail(function () {
                alert('Something fail!');
            });
            setTimeout(function () {
                $("#successSaveModal").modal("hide");
            },1000);
        };

        var cancel = function() {
            recipe(new Recipe(mappedViewModel));
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
            changeIngredientField: changeIngredientField,
            removeRecipeIngredient: removeRecipeIngredient,
            flagRecipeAsEdited: flagRecipeAsEdited,
            isValidRecipe: isValidRecipe,
            save: save,
            cancel: cancel,
            ObjectState: ObjectState
        };
    };

    return {
        recipeViewModel: recipeViewModel
    };

}();