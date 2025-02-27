using Microsoft.AspNetCore.Mvc;

[Route("error")]
public class ErrorController : Controller
{
    [Route("400")]
    public IActionResult BadRequestPage()
    {
        return View("~/Views/Error/BadRequest.cshtml");
    }

    [Route("401")]
    public IActionResult UnauthorizedPage()
    {
        return View("~/Views/Error/Unauthorized.cshtml");
    }

    [Route("403")]
    public IActionResult ForbiddenPage()
    {
        return View("~/Views/Error/Forbidden.cshtml");
    }

    [Route("404")]
    public IActionResult NotFoundPage()
    {
        return View("~/Views/Error/NotFound.cshtml");
    }

    [Route("429")]
    public IActionResult TooManyRequestsPage()
    {
        return View("~/Views/Error/TooManyRequests.cshtml");
    }

    [Route("500")]
    public IActionResult ServerError()
    {
        return View("~/Views/Error/ServerError.cshtml");
    }
}