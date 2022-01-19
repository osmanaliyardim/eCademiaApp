using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace eCademiaApp.Core.Extensions
{
    // Exception middleware to handle errors on global scope.
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception e)
            {
                await HandleExceptionAsync(httpContext, e);
            }
        }

        private Task HandleExceptionAsync(HttpContext httpContext, Exception e)
        {
            httpContext.Response.ContentType = "application/json";

            if (e.GetType() == typeof(ValidationException))
            {
                return httpContext.Response.WriteAsync(new ValidationErrorDetails
                {
                    StatusCode = 400,
                    Message = e.Message,
                    InnerMessage = ((ValidationException)e).Errors != null ? ((ValidationException)e).Errors.FirstOrDefault().ErrorMessage : ""
                    //Errors = ((ValidationException)e).Errors // TODO: Can be changed
                }.ToString());
            }
            else if (e.Message == "You are not authorized.")
            {
                return httpContext.Response.WriteAsync(new ErrorDetails
                {
                    StatusCode = 401,
                    Message = e.Message
                }.ToString());
            }

            return httpContext.Response.WriteAsync(new ErrorDetails
            {
                StatusCode = (int)HttpStatusCode.InternalServerError,
                Message = "Internal Server Error",
                InnerMessage = e.Message // TODO: Can be deleted
            }.ToString());
        }
    }
}
