var vm = (function () {
    var recipeVM = (function () {

        var recipeViewModel = function(data) {
            return RecipeViewModel.recipeViewModel(data);
        }

        var recipeListViewModel = function(data) {
            return RecipeListViewModel.recipeListViewModel(data);
        }

        return {
            recipeViewModel: recipeViewModel,
            recipeListViewModel: recipeListViewModel
        };
    })();
    return {
        recipeVM: recipeVM
    };

})();

    