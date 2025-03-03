using Microsoft.AspNetCore.Mvc;

[Route("error")]
public class ErrorController : Controller
{
    [Route("400")]
    public IActionResult BadRequest()
    {
        return View("~/Views/Error/BadRequest.cshtml");
    }

    [Route("401")]
    public IActionResult Unauthorized()
    {
        return View("~/Views/Error/Unauthorized.cshtml");
    }

    [Route("403")]
    public IActionResult Forbidden()
    {
        return View("~/Views/Error/Forbidden.cshtml");
    }

    [Route("404")]
    public IActionResult NotFound()
    {
        return View("~/Views/Error/NotFound.cshtml");
    }

    [Route("429")]
    public IActionResult TooManyRequests()
    {
        return View("~/Views/Error/TooManyRequests.cshtml");
    }

    [Route("500")]
    public IActionResult ServerError()
    {
        return View("~/Views/Error/ServerError.cshtml");
    }
}