using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using RedisApiCache.Connection;

namespace RedisApiCache.Cacher
{
    public class Cache : ActionFilterAttribute
    {
        private readonly string _fileName;

        public Cache(string fileName="redisconfig")
        {
            _fileName = fileName;
        }

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
