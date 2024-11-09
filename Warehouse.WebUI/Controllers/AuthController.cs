using Microsoft.AspNetCore.Mvc;
using Warehouse.WebUI.Models;
using Warehouse.WebUI.Services;

namespace Warehouse.WebUI.Controllers
{
    [Route("api/[controller]")] // /api/auth
    [ApiController]

    public class AuthController : ControllerBase
    {
        [HttpPost]
        public ActionResult<bool> Login(LoginRequest request)
        {
            //return request.LastName;
            var authService = new AuthService();
            return Ok(authService.Login(request.LastName));
        }
    }
}
