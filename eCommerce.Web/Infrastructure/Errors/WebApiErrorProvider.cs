using System;
using System.Linq;
using System.Net;

using eCommerce.Application.Exceptions;

using FluentValidation;

using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Web.Infrastructure.Errors
{
    public class WebApiErrorProvider
    {
        public IActionResult GetError(Exception exception)
        {
            return exception switch
            {
                ResourceNotFoundException ex => NotFound(ex),
                ValidationException ex => InvalidRequest(ex),
                _ => InternalServerError(exception)
            };
        }

        private static IActionResult InternalServerError(Exception exception)
        {
            var errorResult = new ErrorResult(HttpStatusCode.InternalServerError.ToString(), exception.Message);

            return new ObjectResult(errorResult)
            {
                StatusCode = (int)HttpStatusCode.InternalServerError
            };
        }

        private static IActionResult NotFound(Exception exception)
        {
            var errorResult = new ErrorResult(HttpStatusCode.NotFound.ToString(), exception.Message);

            return new ObjectResult(errorResult)
            {
                StatusCode = (int)HttpStatusCode.NotFound
            };
        }

        private static IActionResult InvalidRequest(ValidationException exception)
        {
            var errorResult = new ErrorResult(HttpStatusCode.NotFound.ToString(), exception.Message);

            var errors = exception.Errors
                .Select(e => new
                {
                    PropertyName = e.PropertyName,
                    Errors = new[] { e.ErrorMessage }
                })
                .ToArray();

            errorResult.Details = errors;

            return new ObjectResult(errorResult)
            {
                StatusCode = (int)HttpStatusCode.BadRequest
            };
        }
    }
}
