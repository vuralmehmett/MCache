using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RedisApiCache.Attribute;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class TestController : ApiController
    {
        [Cache]
        [HttpGet]
        public HttpResponseMessage Method()
        {

            List<FakeModel> fakeModels = new List<FakeModel>
            {
                new FakeModel
                {
                    Name = "test",
                    Surname = "test"
                },
                 new FakeModel
                {
                    Name = "test",
                    Surname = "test"
                },
                  new FakeModel
                {
                    Name = "test",
                    Surname = "test"
                },
                   new FakeModel
                {
                    Name = "test",
                    Surname = "test"
                },
                    new FakeModel
                {
                    Name = "test",
                    Surname = "test"
                },
                     new FakeModel
                {
                    Name = "test",
                    Surname = "test"
                },
                      new FakeModel
                {
                    Name = "test",
                    Surname = "test"
                },
            };



            return Request.CreateResponse(HttpStatusCode.OK, fakeModels);
        }
    }
}
