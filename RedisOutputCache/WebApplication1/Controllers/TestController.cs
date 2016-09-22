using System.Net;
using System.Net.Http;
using System.Web.Http;
using RedisApiCache.Attribute;

namespace WebApplication1.Controllers
{
    public class TestController : ApiController
    {
        [Cache]
        [HttpGet]
        public HttpResponseMessage Method()
        {
            return new HttpResponseMessage(HttpStatusCode.Accepted);
        }
    }
}
