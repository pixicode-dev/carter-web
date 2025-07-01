using System;

namespace CARTER.Models.Common
{
    public class BaseModel
    {

        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public bool? IsActive { get; set; }

    }
}
