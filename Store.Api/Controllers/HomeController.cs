using Microsoft.AspNetCore.Mvc;

namespace Store.Api.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        public object Get()
        {
            return new { version = "version 0.0.1" };
        }

        [HttpGet]
        [Route("error")]
        public string Error()
        {
            throw new System.Exception("Ocorreu algum erro");
            return "Error";
        }
    }
}