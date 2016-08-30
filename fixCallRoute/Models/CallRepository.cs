using System.Collections.Generic;
using System.Linq;
using DbClassLibrary;

namespace fixCallRoute.Models
{
    public class CallRepository : IRepository<CallClass>
    {
        public void Dispose()
        {
        }

        public IEnumerable<CallClass> Get()
        {
            var records = new CallRecords
            {
                Instance = DbBaseClass.SEDP,
                Query =
                   "select * from call where call_start_time > to_date('03/01/2016', 'MM/DD/YYYY') and (status = 'ABORTED' or status = 'ABANDONED') and (select DISTINCT call_id from CALL_CLAIM CL where CL.CALL_ID = call.call_id ) is null order by CLAIM_NUMBER, CALL_ID"
                //"select * from call where call_start_time > sysdate -3  and (status = 'ABORTED' or status = 'ABANDONED') and (select call_id from CALL_CLAIM CL where CL.CALL_ID = call.call_id ) is null order by CLAIM_NUMBER, CALL_ID"
            };
            return records.Results().Select(a => new CallClass
                {
                    CallId = int.Parse(a.CallId),
                    Status = a.Status,
                    PolicyNumber = a.PolicyNumber,
                    ClaimNumber = a.ClaimNumber
                });
        }

        public CallClass FindById(int id)
        {
            var records = new CallRecords
            {
                Instance = DbBaseClass.SEDP,
                Query =
                    $"select * from call where call_id = {id} "
            };
            return records.Results().Select(a => new CallClass
            {
                CallId = int.Parse(a.CallId),
                Status = a.Status,
                PolicyNumber = a.PolicyNumber,
                ClaimNumber = a.ClaimNumber
            }).FirstOrDefault();
        }

        public void FixCall(CallClass call)
        {
            var nextId = Sequence.GetNextSequence("CALL_CLAIM", DbBaseClass.SEDP);
            var sql =
                $"insert into CALL_CLAIM (CALL_CLAIM_ID, CALL_ID, CLAIM_NUMBER) values ({nextId}, {call.CallId}, '{call.ClaimNumber}')";
            GeneralUtility.ExecuteNonQuery(sql,DbBaseClass.SEDP);
        }
    }
}
