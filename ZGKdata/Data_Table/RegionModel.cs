﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZGKdata.Data_Table
{
    public class RegionModel
    {
        [Key]
        public string id { get; set; }
        public string region { get; set; }
        public string regionID { get; set; }
    }
}
