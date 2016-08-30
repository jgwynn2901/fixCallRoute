using System.Collections.Generic;
using System.Web.Http;
using DbClassLibrary;
using fixCallRoute.Models;

namespace fixCallRoute.Controllers
{
    public class ClaimController : ApiController
    {
        // GET: api/Claim
        public IEnumerable<string> Get()
        {
            return new[] { "value1", "value2" };
        }

        // GET: api/Claim/5
        public string Get(int id)
        {
            var results = "";
            var records = new ActiveRecordSet
            {
                Instance = DbBaseClass.SEDP,
                Query = $"select * from CALL_CLAIM where CALL_ID = {id}"
            };
            records.Execute();
            foreach (var record in records )
            {
                results += record.ToString();
            }
            return results;
        }

        // POST: api/Claim
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Claim/5
        public void Put(int id, [FromBody]string value)
        {
            var repo = new CallRepository();
            var call = repo.FindById(id);
            repo.FixCall(call);
        }

        // DELETE: api/Claim/5
        public void Delete(int id)
        {
        }
    }
}
