using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using RedisApiCache.Attribute;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class TestController : ApiController
    {
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

            var response = Request.CreateResponse(HttpStatusCode.OK, fakeModels);
            return response;
        }
    }
}
