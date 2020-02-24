using System;
using System.Collections.Generic;
using System.Text;

namespace Proiect
{
    public class Discount
    {
        public int Id;
        public int PartnerId;
        private List<int> Levels;
        protected Dictionary<string, int> AccumulationPercent;
        protected Dictionary<string, int> DiscountPercent;
    }
}