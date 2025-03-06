using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

public class RedirectIfNotAuthenticated : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.HttpContext.User.Identity.IsAuthenticated)
        {
            context.Result = new RedirectResult("https://localhost:7086/Identity/Account/Register");
        }

        base.OnActionExecuting(context);
    }
}
