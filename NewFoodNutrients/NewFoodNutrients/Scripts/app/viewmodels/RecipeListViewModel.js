var RecipeListViewModel = function() {
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

        var modalClose = function () {
            $('#deleteModal').modal('hide');

        };

        search.subscribe(function (value) {
            filteredRecipeListViewModel(ko.utils.arrayFilter(recipeListViewModel(),
                function (recipe) {
                    if (!search())
                        return true;
                    return recipe.Title().indexOf(search()) !== -1 || recipe.FoodName().indexOf(search()) !== -1;
                }));
            return true;
        });


        var modalSave = function () {
            $.ajax({
                    url: "/Home/Delete/",
                    type: "Post",
                    data: '{ RecipeId:"' + recipe.Id() + '"}',
                    contentType: "application/json"
                })
                .done(function (data) {
                    recipeListViewModel(ko.mapping.fromJS(data));
                    filteredRecipeListViewModel(ko.mapping.fromJS(data));
                    console.log("Success");
                    $('#deleteModal').modal('hide');
                    $('#successDeleteModal').modal('show');

                })
                .fail(function() {
                    alert('Something fail!');
                });
                setTimeout(function () {
                    $("#successDeleteModal").modal("hide");
                },1000);
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
        recipeListViewModel: recipeListViewModel
    }
}();