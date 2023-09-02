using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using DotNetStarter.Common;
using DotNetStarter.Common.Models;
using System.Net;

namespace Api.Common
{
    public class FluentValidationExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            ErrorResponse? content = null;
            HttpStatusCode? statusCode = null;

            if (context.Exception is ValidationException validationException)
            {
                content = new ErrorResponse
                {
                    Errors = validationException.Errors.Select(e => new DomainException
                    {
                        Code = e.ErrorCode,
                        Message = e.ErrorMessage,
                    }).ToList(),
                };

                statusCode = HttpStatusCode.BadRequest;

                if (validationException.Errors.Any(e => e.ErrorCode.Contains(DomainExceptions.NotFound.Code)))
                {
                    statusCode = HttpStatusCode.NotFound;
                }
                if (validationException.Errors.Any(e => e.ErrorCode.Contains(DomainExceptions.Conflict.Code)))
                {
                    statusCode = HttpStatusCode.Conflict;
                }
                if (validationException.Errors.Any(e => e.ErrorCode.Contains(DomainExceptions.Forbidden.Code)))
                {
                    statusCode = HttpStatusCode.Forbidden;
                }
                if (validationException.Errors.Any(e => e.ErrorCode.Contains(DomainExceptions.Unauthorized.Code)))
                {
                    statusCode = HttpStatusCode.Unauthorized;
                }
            }

            if (statusCode == null || content == null)
            {
                return;
            }

            context.Result = ToJsonResult(content, statusCode.Value);
            context.ExceptionHandled = true;
        }

        private JsonResult ToJsonResult(ErrorResponse response, HttpStatusCode statusCode)
        {
            var result = new JsonResult(response)
            {
                StatusCode = (int)statusCode
            };
            return result;
        }

        class ErrorResponse
        {
            public List<DomainException> Errors { get; set; }
        }
    }
}
