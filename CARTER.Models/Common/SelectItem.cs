﻿using System;
using System.Text.Json.Serialization;

namespace CARTER.Models.Common
{
    public class SelectItem
    {
        [JsonIgnore]
        public string Id { get; set; }
        public string Name { get; set; }

        public bool Selected { get; set; }

        public object Select()
        {
            throw new NotImplementedException();
        }
    }
}
