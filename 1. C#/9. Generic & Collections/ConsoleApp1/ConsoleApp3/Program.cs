using System;
using System.Collections.Generic;

public class LevelPriceException : Exception
{
    public LevelPriceException(string message):base(message)
    {
    }
}
namespace ConsoleApp3
{
    public class Discount
    {
        public int Id;
        public int PartnerId;
        private List<int> Levels;
        protected Dictionary<string, decimal> AccumulationPercent;
        protected Dictionary<string, decimal> DiscountPercent;
        public (decimal, decimal) GetDiscount(int Balance)
        {
            string CurrentLevel;
            for (int i = 0; i < Levels.Count - 1; i++)
                if (Balance >= Levels[i] && Balance < Levels[i + 1])
                {
                    CurrentLevel = $"Level{i + 1}";
                    return (AccumulationPercent.GetValueOrDefault(CurrentLevel), DiscountPercent.GetValueOrDefault(CurrentLevel));
                }
            CurrentLevel = $"Level{Levels.Count}";
            return (AccumulationPercent.GetValueOrDefault(CurrentLevel), DiscountPercent.GetValueOrDefault(CurrentLevel));
        }
        public void SetDiscount()
        {
            Levels = new List<int>();
            AccumulationPercent = new Dictionary<string, decimal>();
            DiscountPercent = new Dictionary<string, decimal>();
            Console.WriteLine("Enter numbers of levels: ");
            int NumberOfLevels = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter price of each step, and discounts percent: ");
            for (int i = 0; i < NumberOfLevels; i++)
            {
                Console.Write($"Price for level {i + 1}: ");
                int temp = 0;
                Input:
                try
                {
                    temp = int.Parse(Console.ReadLine());
                    if (i > 0 && temp <= Levels[i - 1]||temp<0) throw new LevelPriceException("Entered value is too small\n Please enter it one more time");
                }
                catch (LevelPriceException ex)
                {
                    Console.WriteLine(ex.Message);
                    goto Input;
                }
                    Levels.Add(temp);
                Console.Write($"Accmulution procent for level {i + 1}: ");
                AccumulationPercent.Add($"Level{i + 1}", decimal.Parse(Console.ReadLine()));
                Console.Write($"Discount procent for level {i + 1}: ");
                DiscountPercent.Add($"Level{i + 1}", decimal.Parse(Console.ReadLine()));
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Discount Test = new Discount();
            Test.SetDiscount();
            decimal DiscountPercent;
            decimal AccumulationPercent;
            (AccumulationPercent, DiscountPercent) = Test.GetDiscount(1000);
            Console.WriteLine($"{AccumulationPercent}%, {DiscountPercent}%");
        }
    }
}
