using System;
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
            var etag = actionContext.Request.Headers.IfNoneMatch.ToString().Replace("\"", string.Empty);
            var key = actionContext.Request.RequestUri.PathAndQuery + "-" + actionContext.Request.Method.Method + "-" + etag;

            var cachedResponse = Rm.GetValue(key);

            if (!string.IsNullOrEmpty(cachedResponse))
            {

                actionContext.Response = new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.NotModified
                };

                return;
            }

            base.OnActionExecuting(actionContext);
        }

        public override async void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            var etag = new EntityTagHeaderValue("\"" + Guid.NewGuid().ToString().Replace("-", string.Empty) + "\"");
            string response = await actionExecutedContext.Response.Content.ReadAsStringAsync();
            actionExecutedContext.Response.Headers.ETag = etag;

            var isSet = Rm.SetValue(actionExecutedContext.Request.RequestUri.PathAndQuery + "-" + actionExecutedContext.Request.Method.Method + "-" + etag,
               response);

            if (!isSet)
            {
                Debug.WriteLine("sorun var");
            }

            base.OnActionExecuted(actionExecutedContext);
        }
    }
}
