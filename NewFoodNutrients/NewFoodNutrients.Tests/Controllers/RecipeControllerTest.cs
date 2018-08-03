using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NewFoodNutrients.Controllers;
using NewFoodNutrients.Core;
using NewFoodNutrients.Core.Repositories;
using NewFoodNutrients.Tests.Extensions;
using System.Security.Principal;
using System.Web.Mvc;

namespace NewFoodNutrients.Tests.Controllers
{
    [TestClass]
    public class RecipeControllerTest
    {
        private RecipesController _controller;
        private Mock<IRecipeRepository> _mockRecipeRepository;
        [TestInitialize]
        public void TestInitialize()
        {
            //Create a mock RecicpeRepository
            _mockRecipeRepository = new Mock<IRecipeRepository>();

            //Create a mock UnitOfWork
            var mockUoW = new Mock<IUnitOfWork>();


            //Get the RecipeRepository Object
            mockUoW.SetupGet(u => u.Recipes).Returns(_mockRecipeRepository.Object);

            var identity = new GenericIdentity("tugberk");
            _controller = new RecipesController(mockUoW.Object);

            _controller.MockControllerContext("1", "icol@domain.com");

            //// In the case of an ApiController we can use the Extension Method to mock the current user
            //_controller = new YourApiController(mockUoW);
            //Use the extension method created
            //_controller.MockCurrentUserForApiControllers("1", "userName");
        }
        [TestMethod]
        public void Create_CreateANewRecipe_ShouldReturnEmptyViewModelOnlySelectListsWithData()
        {

        }

        [TestMethod]
        public void Edit_NoRecipeWithGivenIdExists_ShouldReturnNotFound()
        {
            var result = _controller.Edit(23);
            result.Should().BeOfType<HttpNotFoundResult>();

        }

    }
}
