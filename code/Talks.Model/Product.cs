﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talks.Model
{
    public class Product
    {
        public string ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Company { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public DateTime AddTime { get; set; }
    }

}
