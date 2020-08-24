using Microsoft.AspNetCore.Mvc;

namespace Store.Api.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        public object Get()
        {
            return new { version = "version 0.0.1" };
        }
    }
}