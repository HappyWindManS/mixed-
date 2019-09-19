using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCCodeFirst.Entity
{
    public class School
    {
        [Key]
        public long Key { get; set; }

        public string Name { get; set; }
    }
}