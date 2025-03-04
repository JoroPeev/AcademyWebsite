using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace AcademyWebsite
{
    public class CustomHandleErrorAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.ExceptionHandled || context.HttpContext == null)
                return;

            var statusCode = context.HttpContext.Response.StatusCode;
            var viewName = statusCode switch
            {
                400 => "BadRequest",
                401 => "Unauthorized",
                403 => "Forbidden",
                404 => "NotFound",
                _ => "ServerError"
            };

            context.Result = new ViewResult
            {
                ViewName = $"~/Views/Error/{viewName}.cshtml"
            };

            context.ExceptionHandled = true;
        }
    }
}
