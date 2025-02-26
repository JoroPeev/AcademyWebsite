using Microsoft.AspNetCore.Mvc;

public class ErrorController : Controller
{
    [Route("Error/404")]
    public IActionResult NotFoundPage()
    {
        Response.StatusCode = 404;
        return View("NotFound");
    }

    [Route("Error/500")]
    public IActionResult InternalServerError()
    {
        Response.StatusCode = 500;
        return View("InternalServerError");
    }

    [Route("Error/General")]
    public IActionResult GeneralError()
    {
        return View("General");
    }
}
