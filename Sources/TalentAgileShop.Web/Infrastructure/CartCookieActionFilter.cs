using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;

namespace TalentAgileShop.Web.Infrastructure
{
    [AttributeUsage(AttributeTargets.Class| AttributeTargets.Method)]
    public class CartCookieActionFilter: ActionFilterAttribute
    {

        private string GetCookieId(HttpRequest request)
        {
            var cookie = request.Cookies["cart-id"];

            if (string.IsNullOrEmpty(cookie))
            {
                return Guid.NewGuid().ToString();
            }

            return cookie;
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
          
            var id = GetCookieId(filterContext.HttpContext.Request);

            var cookieOptions = new CookieOptions {
                Domain = filterContext.HttpContext.Request.Host.Host,
                Path = "/",
                Expires = DateTime.Now.AddMinutes(40)
            };

            filterContext.HttpContext.Response.Cookies.Append("cart-id", id, cookieOptions);
          
        }
    }
}