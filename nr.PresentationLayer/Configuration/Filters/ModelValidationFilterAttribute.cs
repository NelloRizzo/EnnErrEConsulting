using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace nr.PresentationLayer.Configuration.Filters
{

    public class ModelValidationFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context) {
            if (!context.ModelState.IsValid) {
                context.Result = new BadRequestObjectResult(GetValidationErrors(context.ModelState));
            }
        }

        private static object GetValidationErrors(ModelStateDictionary modelState) {
            var errors = modelState
                .Where(ms => ms.Value?.Errors.Count > 0)
                .ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value!.Errors.Select(e => e.ErrorMessage).ToArray()
                );

            return new {
                StatusCode = 400,
                Message = "Invalid model",
                Errors = errors
            };
        }
    }
}
