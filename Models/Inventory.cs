﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFAConnectToMySql.Models
{
    public class Inventory
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public int quantity { get; set; }
    }
}
