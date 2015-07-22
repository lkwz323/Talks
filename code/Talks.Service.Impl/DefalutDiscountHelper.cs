using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talks.Service.Impl
{
    public class DefalutDiscountHelper : IDiscountHelper
    {
        private decimal discountRate;

        public decimal DiscountSize { get; set; }

        public DefalutDiscountHelper(decimal discountParam)
        {
            discountRate = discountParam;
        }

        public decimal ApplyDiscount(decimal totalParam)
        {
            return (totalParam - (discountRate / 100M * totalParam));
        }
    }

}
