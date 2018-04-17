using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewFoodNutrients.Models;
using NewFoodNutrients.ViewModels;

namespace NewFoodNutrients.Controllers
{
    public class RecipesController : Controller
    {
        private ApplicationDbContext _context;

        public RecipesController( )
        {
            _context = new ApplicationDbContext();

        }
        // GET: Recipes
        public ActionResult Create()
        {
            var viewModel = new PlateViewModel();
            viewModel.FoodTypes = _context.FoodTypes.ToList();
            return View(viewModel);
        }
    }
}