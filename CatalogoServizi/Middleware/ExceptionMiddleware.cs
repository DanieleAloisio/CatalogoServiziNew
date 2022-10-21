using CatalogoServizi.Business.Dto;
using CatalogoServizi.Business.Dto.Common;
using CatalogoServizi.Business.Exceptions;

namespace CatalogoServizi.Middleware
{
   
    /// <summary>
    /// Exception middleware
    /// </summary>
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        /// <summary>
        /// Constructors
        /// </summary>
        /// <param name="next">Request delegate</param>
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// Invoke
        /// </summary>
        /// <param name="context">Context</param>
        /// <returns>Task</returns>
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (ItemNotFoundException e)
            {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                await context.Response.WriteAsJsonAsync(new MessageDto(e.Message, 404));
                
            }
            
            catch (Exception e)
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsJsonAsync(new MessageDto(e.Message, 500));
            }
        }
    }
}
