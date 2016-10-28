using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication1.Controllers
{
    public class MeuFiltroAttribute : ActionFilterAttribute
    {
        public string Roles { get; set; }
        //public string Users { get; set; }

        //ANTES de executar a Action
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //string[] userRoles = System.Web.Security.Roles.GetRolesForUser();
            string[] userRoles = { "Admin", "Gerente" };

            foreach (var controllerRole in this.Roles.Split(','))
            {
                foreach (var role in userRoles)
                {
                    if (controllerRole.Equals(role))
                        return;
                }
            }

            throw new SecurityException("Acesso negado.");




            //var request = filterContext.HttpContext.Request;

            //if (request.IsAjaxRequest())
            //{
            //    var response = filterContext.HttpContext.Response;
            //    response.Write("IsAjaxRequest");
            //}
            //else
            //    filterContext.Result = 
            //        new RedirectToRouteResult(
            //            new RouteValueDictionary(
            //                new { controller = "Home", action = "Index" }));


            base.OnActionExecuting(filterContext);
        }


        //DEPOIS de executar a Action
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
        }
    }
}