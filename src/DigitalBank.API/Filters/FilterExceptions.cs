using DigitalBank.Communication.Responses;
using DigitalBank.Exceptions;
using DigitalBank.Exceptions.ExceptionsBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DigitalBank.API.Filters;

public class FilterExceptions : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if(context.Exception is DigitalBankExceptions)
        {
            HandleDigitalBankExceptions(context);
        }
        else
        {
            ThrowUnknownError(context);
        }
    }

    private void HandleDigitalBankExceptions(ExceptionContext context)
    {
        if(context.Exception is ValidationsErrorException)
        {
            HandleValidationErrorException(context);
        }
        else if (context.Exception is LoginInvalidException)
        {
            HandleLoginInvalidException(context);
        }
    }

    private void HandleLoginInvalidException(ExceptionContext context)
    {
        var errorLogin = context.Exception as LoginInvalidException;

        context.HttpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
        context.Result = new ObjectResult(new ResponseErrorJson(errorLogin.Message));
    }

    private void HandleValidationErrorException(ExceptionContext context)
    {
        var validationErrors = context.Exception as ValidationsErrorException;

        context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
        context.Result = new ObjectResult(new ResponseErrorJson(validationErrors.ErrorMessages)); 
    }

    private void ThrowUnknownError(ExceptionContext context)
    {
        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Result = new ObjectResult(new ResponseErrorJson(ResourceErrorMessages.ERRO_DESCONHECIDO));
    }
}
