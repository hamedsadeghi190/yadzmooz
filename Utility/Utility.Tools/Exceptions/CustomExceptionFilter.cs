using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using Utility;

namespace Utility.Tools.Exceptions
{
    public class CustomExceptionFilter : Attribute, IExceptionFilter
    {
        private readonly IModelMetadataProvider _modelMetadataProvider;
        public CustomExceptionFilter(IModelMetadataProvider modelMetadataProvider)
        {
            _modelMetadataProvider = modelMetadataProvider;
        }
        public void OnException(ExceptionContext context)
        {
            context.ExceptionHandled = true;
            context.Result = new StatusCodeResult(401);
            Console.Write(context.Exception);
            context.Result = new OkObjectResult(new { Message= context.Exception.ToString(),Status = false });
            //context.Result = new OkObjectResult(new { Message = $"خطایی رخ داده است. لطفا با شماره پشتیبانی {"03132274725".ToPersian()} تماس بگیرید", Status = false });

            
            //if (context.HttpContext.Request.IsAjaxRequest())
            //{
            //    context.Result = new StatusCodeResult(ErrorHandler.StatusCode);
            //}
            //else
            //{
            //    ViewResult view = new ViewResult();
            //    view.ViewName = "Error";
            //    view.ViewData = new ViewDataDictionary(_modelMetadataProvider, context.ModelState);
            //    view.ViewData.Model = ErrorHandler.ErrorMessage;
            //    context.Result = view;
            //}
        }


    }


    public class CustomValidationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //if (!context.HttpContext.Request.IsAjaxRequest())
            //    return;

            //if (context.ModelState.IsValid)
            //    return;

            //var ListError = (from state in context.ModelState.Values
            //                 from error in state.Errors
            //                 select error.ErrorMessage).ToList();

            //string str = "خطا";
            //foreach (var item in ListError)
            //{
            //    str += "\n - " + item;
            //}

            context.Result = new OkObjectResult(new { isNotValid = true, errorMessage = "Hiwa" });
        }
    }
}
