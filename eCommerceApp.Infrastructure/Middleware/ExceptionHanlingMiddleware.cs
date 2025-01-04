using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace eCommerceApp.Infrastructure.Middleware
{
    public class ExceptionHanlingMiddleware(RequestDelegate _next)
    {
        public async Task TaskAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException is SqlException innerException)
                {
                    switch (innerException.Number)
                    {
                        case 2627: // Unique constraint violation 
                            context.Response.StatusCode = StatusCodes.Status409Conflict;
                            await context.Response.WriteAsync(innerException.Message);
                            break;
                        case 515: // Cannot insert null
                            context.Response.StatusCode = StatusCodes.Status400BadRequest;
                            await context.Response.WriteAsync(innerException.Message);
                            break;
                    }
                }
                else
                {
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    await context.Response.WriteAsync(context.Response.StatusCode.ToString());
                }
            }
            catch (Exception ex) 
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsync("An error occurred: " + ex.Message);
            }
        }
        }
    }
}
