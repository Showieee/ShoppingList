using System.Collections.Generic;

namespace Entities
{
    public class UserInfo
    {
        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Telephone { get; set; }

        public bool IsDriver { get; set; }

        public virtual ICollection<UserProductRequestAssigment> UserAssignments { get; set; }

        public virtual LoginInfo LoginInfo { get; set; }

        public UserInfo()
        {
            UserAssignments = new HashSet<UserProductRequestAssigment>();
        }
    }
}