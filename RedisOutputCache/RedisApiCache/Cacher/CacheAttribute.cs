using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using RedisApiCache.CacheConnection;

namespace RedisApiCache.Cacher
{
    public class CacheAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            RedisConnection con = new RedisConnection();

            con.Connection();


            base.OnActionExecuting(actionContext);
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnActionExecuted(actionExecutedContext);
        }
    }
}
