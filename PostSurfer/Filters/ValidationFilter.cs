﻿using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;
using Post_Surfer.Contract.V1.Response;

namespace Post_Surfer.Filters
{
    public class ValidationFilter: IAsyncActionFilter
    {
        public string FieldName { get; private set; }

        async Task IAsyncActionFilter.OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var errorInModelState = context.ModelState.Where(x => x.Value.Errors.Count > 0)
                    .ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(x => x.ErrorMessage))
                    .ToArray();
                var errorResponse = new ErrorResponse();
                foreach (var error in errorInModelState)
                {
                    foreach (var subError in error.Value)
                    {
                        var errorModel = new ErrorModel
                        { 
                            FieldName= error.Key,
                            Message = subError
                        };
                        errorResponse.Errors.Add(errorModel);
                    }
                  
                }
                context.Result= new BadRequestObjectResult(errorResponse);
                return;
            }

            
            await next();
        }
    }
}
