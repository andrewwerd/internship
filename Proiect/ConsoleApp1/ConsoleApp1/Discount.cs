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

        public CurrentDiscount CurrentDiscount
        {
            get => default;
            set
            {
            }
        }

        public (int, int) get(int Balance)
        {
            string CurrentLevel;
            for (int i = 0; i < Levels.Count - 1; i++)
                if (Balance >= Levels[i] || Balance < Levels[i + 1]) 
                { 
                    CurrentLevel = $"Level {i + 1}"; 
                    return (AccumulationPercent.GetValueOrDefault(CurrentLevel), DiscountPercent.GetValueOrDefault(CurrentLevel)); 
                }
            CurrentLevel = $"Level {Levels.Count}";
            return (AccumulationPercent.GetValueOrDefault(CurrentLevel), DiscountPercent.GetValueOrDefault(CurrentLevel));
        }
    }
}