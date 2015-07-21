﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talks.Model
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductCompany { get; set; }
        public DateTime SignDate { get; set; }
        public DateTime UpdateData { get; set; }
    }
}
