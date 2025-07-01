using CARTER.Models.Categories;
using CARTER.Models.Common;
using CARTER.Models.HashTags;
using CARTER.Models.System.Users;
using System;
using System.Collections.Generic;

namespace CARTER.Models.Exercises
{
    public class ExerciseBaseModel : BaseModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public ICollection<HashTagModel> HashTags { get; set; }
        public string Objectives { get; set; }
        public string Instruction { get; set; }
        public string Evolution { get; set; }
        public ICollection<TacticalboardModel> Tacticalboards { get; set; }
        public AppUserBaseModel AppUser { get; set; }
        public List<TypeModel> Types { get; set; }
        public List<CategoryModel> Categories { get; set; }
        public StatusModel Status { get; set; }
    }
}
