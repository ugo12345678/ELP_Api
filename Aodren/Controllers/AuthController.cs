using Aodren.Domain.Interfaces.Business;
using Aodren.Domain.Models.Requests.Auth;
using Microsoft.AspNetCore.Mvc;

namespace Aodren.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private static IAuthBusiness _authBusiness;

        public AuthController(IAuthBusiness authBusiness)
        {
            _authBusiness = authBusiness;
        }

        [HttpPost]
        public ActionResult Login(ConnectUserRequest request)
        {
            if (ModelState.IsValid)
            {
                var token = _authBusiness.ConnectUser(request);
                return token != null ? Ok(token) : BadRequest("Invalid credentials");
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
