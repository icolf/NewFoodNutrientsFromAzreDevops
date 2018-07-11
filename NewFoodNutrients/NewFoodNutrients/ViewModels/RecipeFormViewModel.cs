using NewFoodNutrients.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace NewFoodNutrients.ViewModels
{
    public class RecipeFormViewModel : IObjectWithState
    {
        public RecipeFormViewModel()
        {
            RecipeIngredients=new List<IngredientViewModel>();
        }
        //Recipe Header

        public int Id { get; set; }

        [Display(Name = "Title")]
        public string Title { get; set; }

        public IEnumerable<FoodType> ContextFoodTypes { get; set; }

        [Display(Name = "Food Type")]
        public int FoodTypeId { get; set; }

        public IEnumerable<SelectListItem> FoodTypes
        {
            get
            {
                var allFoodTypes = ContextFoodTypes.Select(f => new SelectListItem
                {
                    Value = f.Id.ToString(),
                    Text = f.FoodTypeName
                });
                return allFoodTypes;
            }
        }

        public string FoodName { get; set; }

        [Display(Name = "Food")]
        public int FoodId { get; set; }

        public List<Food> ContextFoods { get; set; }

        public IEnumerable<SelectListItem> Foods
        {
            get
            {
                var allFoods = ContextFoods.Select(f => new SelectListItem
                {
                    Value = f.Id.ToString(),
                    Text = f.FoodName
                });
                return allFoods;
            }
        }

        //Recipe Ingredients
        [Display(Name = "Ingredient Type")]
        public int IngredientTypeId { get; set; }
        public List<IngredientType> ContextIngredientTypes { get; set; }

        public IEnumerable<SelectListItem> IngredientTypes
        {
            get
            {
                var allIgredientTypes = ContextIngredientTypes.Select(i => new SelectListItem
                {
                    Text = i.IngredientTypeName,
                    Value = i.Id.ToString()

                });
                return allIgredientTypes;

            }
        }

        public int IngredientId { get; set; }
        public List<Ingredient> ContextIngredients { get; set; }

        public IEnumerable<SelectListItem> Ingredients
        {
            get
            {
                var allIngredients = ContextIngredients.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                });
                return allIngredients;
            }
        }

        public List<IngredientViewModel> RecipeIngredients { get; set; }

        public decimal Amount { get; set; }

        public int UnitOfMeasureId { get; set; }
        public List<UnitOfMeasure> ContextUnitOfMeasures { get; set; }

        public IEnumerable<SelectListItem> UnitOfMeasures
        {
            get
            {
                var allUnitOfMeasures = ContextUnitOfMeasures.Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.UnitofMeasure
                });
                return allUnitOfMeasures;
            }
        }

        public ObjectState ObjectState { get; set; }
    }
}