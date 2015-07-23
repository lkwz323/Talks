using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talks.Model.Searcher.Base;

namespace Talks.Model.Searcher
{
    public class ProductSearcher : AbstractSearchModel
    {
        public string ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Company { get; set; }      
        public string Category { get; set; }

    }
}
