using Microsoft.AspNetCore.Mvc;

namespace Benefits.Web.ApiControllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class SampleController : Controller
    {
        /*
         * Samples:
         */
        // The http attribute is now required, regardless of the method's name.
        //[HttpGet]
        //public IActionResult Get()
        //{
        //    return Ok();
        //}

        //// The syntax for declaring properties has changed and is also as follows.
        //[HttpGet("{id}")]
        //public IActionResult Get(int id)
        //{
        //    return Ok();
        //}
    }
}