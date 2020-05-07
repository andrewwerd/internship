using DbCard.Domain.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace DbCard.Infrastructure.Extensions
{
    public class CustAccessFilter
    {

    }
    public class AdminModeAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // - Token
            // = DB - TOKEN - LEVEL

            var level = URole.Admin;
            if (level == URole.Admin)
            {
                context.Result = new ContentResult()
                {
                    StatusCode = StatusCodes.Status200OK
                };
            }
            else
            {
                context.Result = new ContentResult()
                {
                    StatusCode = StatusCodes.Status404NotFound
                };
            }




        }
    }
}
