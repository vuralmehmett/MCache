using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using RedisApiCache.Manager;

namespace RedisApiCache.Attribute
{
    public class CacheAttribute : ActionFilterAttribute
    {
        private readonly string _fileName;

        public CacheAttribute(string fileName = "redisconfig")
        {
            _fileName = fileName;
        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            RedisManager rm = new RedisManager();

            rm.SetValue("myKey", "test1");
            rm.GetValue("myKey");

            base.OnActionExecuting(actionContext);
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnActionExecuted(actionExecutedContext);
        }
    }
}
