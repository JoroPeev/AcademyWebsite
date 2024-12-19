using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

public class RedirectIfNotAuthenticated : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        // Check if the user is authenticated
        if (!context.HttpContext.User.Identity.IsAuthenticated)
        {
            // Redirect to the full URL of the Register page
            context.Result = new RedirectResult("https://localhost:7086/Identity/Account/Register");
        }

        base.OnActionExecuting(context);
    }
}
