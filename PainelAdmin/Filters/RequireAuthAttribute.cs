using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace PainelAdmin.Filters
{
    public class RequireAuthAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Items["UsuarioId"] == null)
            {
                context.Result = new RedirectResult("/login");
            }
        }
    }
}