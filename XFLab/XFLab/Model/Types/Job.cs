﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace XFLab.Model.Types
{
    public class Job
    {
        [JsonProperty(PropertyName = "prof")]
        public string Profession { get; set; }
    }
}
