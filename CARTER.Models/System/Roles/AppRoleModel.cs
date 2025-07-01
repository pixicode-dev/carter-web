using System;
using System.Text.Json.Serialization;

namespace CARTER.Models.System.Roles
{
    public class AppRoleModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        [JsonIgnore]
        public string Description { get; set; }
    }
}
