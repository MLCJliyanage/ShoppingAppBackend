using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using ShoppingApp.Common;
using ShoppingApp.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingApp.API.ErrorHandling
{
    public class ExceptionHanglingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception)
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsync("Internal Server Error..");
            }
        }
    }
}
