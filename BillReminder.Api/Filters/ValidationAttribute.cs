using BillReminder.Domain.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace BillReminder.Api.Filters;

public class ValidationAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.ModelState.IsValid)
        {
            var errors = new List<string>();
            foreach (var key in context.ModelState.Keys)
                errors.AddRange(context.ModelState[key]!.Errors.Select(x => x.ErrorMessage));
            context.Result = new JsonResult(Result<object>.Failure(errors));
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        }
    }
}
