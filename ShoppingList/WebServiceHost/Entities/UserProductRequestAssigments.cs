using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServiceHost.Entities
{
    public class UserProductRequestAssigment
    {
        public int UserId { get; set; }

        public int ProductRequestId { get; set; }

        public virtual UserInfo User { get; set; }

        public virtual ProductRequest ProductRequest { get; set; }
    }
}
