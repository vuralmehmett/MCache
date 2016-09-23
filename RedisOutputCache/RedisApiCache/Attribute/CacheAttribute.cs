using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RedisApiCache.Manager;

namespace RedisApiCache.Attribute
{
    public class CacheAttribute : ActionFilterAttribute
    {
        private static readonly RedisManager Rm = new RedisManager();

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var key = actionContext.Request.RequestUri + "-" + actionContext.Request.Method.Method;
            var cachedResponse = Rm.GetValue(key);

            if (!string.IsNullOrEmpty(cachedResponse))
            {
                
                actionContext.Response = new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.NotModified,
                    Content = new StringContent(cachedResponse, Encoding.UTF8, "application/json")
                };

                return;
            }

            base.OnActionExecuting(actionContext);
        }

        public override async void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            string response = await actionExecutedContext.Response.Content.ReadAsStringAsync();
            var isSet = Rm.SetValue(actionExecutedContext.Request.RequestUri + "-" + actionExecutedContext.Request.Method.Method,
               response);

            if (!isSet)
            {
                Debug.WriteLine("sorun var");
            }

            base.OnActionExecuted(actionExecutedContext);
        }
    }
}
