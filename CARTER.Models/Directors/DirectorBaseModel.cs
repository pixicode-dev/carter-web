using CARTER.Models.Clubs;
using System;
using System.Collections.Generic;

namespace CARTER.Models.Directors
{
    public class DirectorBaseModel
    {
        public Guid Id { get; set; }
        public ICollection<ClubModel> Clubs { get; set; }
    }
}
