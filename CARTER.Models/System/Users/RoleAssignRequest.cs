using CARTER.Models.Common;
using System.Collections.Generic;

namespace CARTER.Models.System.Users
{
    public class RoleAssignRequest
    {
        //public Guid Id { get; set; }
        public List<SelectItem> Roles { get; set; } = new List<SelectItem>();
    }
}
