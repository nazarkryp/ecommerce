using eCommerce.Web.Infrastructure.Errors;
using Microsoft.AspNetCore.Mvc.Filters;

namespace eCommerce.Web.Infrastructure.Attributes;

public class GlobalExceptionFilterAttribute : ExceptionFilterAttribute
{
    private readonly WebApiErrorProvider _errorProvider;

    public GlobalExceptionFilterAttribute(WebApiErrorProvider errorProvider)
    {
        _errorProvider = errorProvider;
    }

    public override void OnException(ExceptionContext context)
    {
        context.Result = _errorProvider.GetError(context.Exception);
    }
}