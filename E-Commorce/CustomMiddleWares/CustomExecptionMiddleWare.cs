using System.Text.Json;
using Azure;
using Domain_Layer.Exceptions;
using Microsoft.AspNetCore.Http;
using Shared.ErrorModels;

namespace E_Commorce.CustomMiddleWares
{
    public class CustomExecptionHandlerMiddleWare
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CustomExecptionHandlerMiddleWare> _logger;

        public CustomExecptionHandlerMiddleWare(RequestDelegate next, ILogger<CustomExecptionHandlerMiddleWare> logger)
        {
            _next = next;
            _logger = logger;
        }


        public async Task InvokeAsync(HttpContext httpcontext) {
        
            try
            {

                await _next.Invoke(httpcontext);
                if (httpcontext.Response.StatusCode == StatusCodes.Status404NotFound)
                {
                    var Response = new ErrorToReturn()
                    {

                        StatusCode = StatusCodes.Status404NotFound,
                        ErrorMessage = $"End Point {httpcontext.Request.Path} Is Not Found"
                    };

                    await httpcontext.Response.WriteAsJsonAsync(Response);


                }

            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Something Went Wrong");

                httpcontext.Response.StatusCode = ex switch
                {
                    NotFoundEx => StatusCodes.Status404NotFound,
                    UnauthorizedException => StatusCodes.Status401Unauthorized,


                    BadRequestExpection badRequestExpection => GetBadRequestErrors(badRequestExpection),

                    _ => StatusCodes.Status500InternalServerError
                };
                // Handle validation errors differently from other errors
                if (ex is BadRequestExpection badRequestEx && badRequestEx.Errors != null)
                {
                    var validationResponse = new ValidationErrorToReturn
                    {
                        StatusCode = httpcontext.Response.StatusCode,
                        Message = "Validation Failed",
                        ValidationErrors = new List<ValidationError>
                        {
                            new ValidationError
                            {
                                Field = "Authentication",
                                Errors = badRequestEx.Errors
                            }
                        }
                    };
                    await httpcontext.Response.WriteAsJsonAsync(validationResponse);
                }
                else
                {
                    // For non-validation errors, use the standard error response
                    var response = new ErrorToReturn()
                    {
                        StatusCode = httpcontext.Response.StatusCode,
                        ErrorMessage = ex.Message
                    };
                    await httpcontext.Response.WriteAsJsonAsync(response);
                }
            }




        }

        private static int GetBadRequestErrors(BadRequestExpection badRequestExpection)
        {
            return StatusCodes.Status400BadRequest;
        }
    }
}
