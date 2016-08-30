using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fixCallRoute.Models
{
    public class CallClass
    {
        public int CallId { get; set; }
        public string Status { get; set; }
        public int UserId { get; set; }
        public int AhsId { get; set; }
        public string ClaimNumber { get; set; }
        public string PolicyNumber { get; set; }
    }
}
