using System.Security.Claims;
using System.Security.Principal;
using System.Web.Http;
using System.Web.Mvc;
using Moq;

namespace NewFoodNutrients.Tests.Extensions
{
    public static class ControllerExtensions
    {
        public static void MockCurrentUserForApiControllers(this ApiController controller, string userId, string userName)
        {
            var identity = new GenericIdentity(userName);
            identity.AddClaim(
                new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name", userName));
            identity.AddClaim(
                new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", userId));
            var principal = new GenericPrincipal(identity, null);

            controller.User = principal;

        }

        public static void MockControllerContext(this Controller controller, string userId, string userName)
        {
            var controllerContext = new Mock<ControllerContext>();

            var identity = new GenericIdentity(userName);
            identity.AddClaim(
                new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name", userName));
            identity.AddClaim(
                new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", userId));
            var principal = new GenericPrincipal(identity, null);

            controllerContext.SetupGet(x => x.HttpContext.User).Returns(principal);
            controller.ControllerContext = controllerContext.Object;
        }
    }
}
