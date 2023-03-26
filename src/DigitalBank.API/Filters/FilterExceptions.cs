using DigitalBank.Communication.Responses;
using DigitalBank.Exceptions;
using DigitalBank.Exceptions.ExceptionsBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

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
    }

    private void HandleValidationErrorException(ExceptionContext context)
    {
        var validationErrors = context.Exception as ValidationsErrorException;

        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        context.Result = new ObjectResult(new ResponseErrorJson(validationErrors.ErrorMessages)); 
    }

    private void ThrowUnknownError(ExceptionContext context)
    {
        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        context.Result = new ObjectResult(new ResponseErrorJson(ResourceErrorMessages.ERRO_DESCONHECIDO));
    }
}
