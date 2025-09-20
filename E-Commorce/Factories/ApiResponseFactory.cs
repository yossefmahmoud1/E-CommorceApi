using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Shared.ErrorModels;

namespace E_Commorce.Factories
{
    public class ApiResponseFactory
    {
        public static IActionResult GenricApiValidationErrorsResponse(ActionContext context)
        {
            var errors = context.ModelState
                .Where(m => m.Value.Errors.Any())
                .Select(m => new ValidationError()
                {
                    Field = m.Key,
                    Errors = m.Value.Errors.Select(e => e.ErrorMessage)
                });

            var response = new ValidationErrorToReturn()
            {
                ValidationErrors = errors
            };

            return new BadRequestObjectResult(response);
        }
    }
}
