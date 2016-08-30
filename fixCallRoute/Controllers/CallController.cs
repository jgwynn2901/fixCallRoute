using System.Collections.Generic;
using System.Web.Http;
using fixCallRoute.Models;

namespace fixCallRoute.Controllers
{
    public class CallController : ApiController
    {
        // GET: api/Call
        public IEnumerable<CallClass> Get()
        {
            return new CallRepository().Get();
        }

        // GET: api/Call/5
        public CallClass Get(int id)
        {
            return new CallRepository().FindById(id);
        }

        // POST: api/Call
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Call/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Call/5
        public void Delete(int id)
        {
        }
    }
}
