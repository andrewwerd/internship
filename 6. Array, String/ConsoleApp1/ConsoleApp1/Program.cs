using System;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {

        static void someStringMethod()
        {
            Console.WriteLine("Write your name!");
            string s = Console.ReadLine();
            Console.WriteLine(s.PadLeft(20, '=') + new string('=', 20) + '\n');
            while (true)
            {
                Console.WriteLine("Same opportunities: \n\t 1. To Upper \n\t 2. To Lower \n\t 3. Replace \n\t 4. Insert \n\t 5. Equal \n\t 0. Exit");
                object a = Console.ReadLine();
                var choice = int.TryParse(a.ToString(), out int b) ? b : a;
                Console.Clear();
                switch (choice)
                {
                    case string c when c.ToLower() == "to upper":
                    case int i when i == 1:
                        {
                            Console.WriteLine("Name to upper: {0}", s.ToUpper());
                            break;
                        }
                    case string c when c.ToLower() == "to lower":
                    case int i when i == 2:
                        {
                            Console.WriteLine("Name to lower: {0}", s.ToLower());
                            break;
                        }
                    case string c when c.ToLower() == "replace":
                    case int i when i == 3:
                        {
                            Console.WriteLine("Pleace enter symbols which you want to replace");
                            string s1 = Console.ReadLine();
                            if (s.Contains(s1))
                            {
                                Console.WriteLine("Pleace enter symbols which you want to insert");
                                string s2 = Console.ReadLine();
                                Console.WriteLine("String after replace{0}", s.Replace(s1, s2));
                            }
                            else
                            {
                                Console.WriteLine("These characters are not contained in the string");
                                break;
                            }

                            break;
                        }
                    case string c when c.ToLower() == "insert":
                    case int i when i == 4:
                        {
                            Console.WriteLine("Pleace enter symbols which you want to insert");
                            string s2 = Console.ReadLine();
                            Console.WriteLine("Pleace enter index");
                            int n = Console.Read();
                            Console.WriteLine("String after insert{0}", s.Insert(n, s2));
                            break;
                        }
                    case string c when c.ToLower() == "equal":
                    case int i when i == 5:
                        {
                            Console.WriteLine("Pleace enter string which you want to compare");
                            string s2 = Console.ReadLine();
                            Console.WriteLine("String s is equal to string s2 : {0}", s.Equals(s2));
                            break;
                        }
                    case string c when c.ToLower() == "exit":
                    case int i when i == 0:
                        {
                            Console.WriteLine("GoodBye");
                            return;
                        }
                }
                Console.ReadKey();
                Console.Clear();
            }

        }
        static void evenLast(ref int[] a)
        {
            for (int i = 0; i < a.Length; i++)
                for (int j = i; j < a.Length - 1; j++)
                    if (a[i] % 2 == 0)
                    {
                        int temp = a[i];
                        a[i] = a[j + 1];
                        a[j + 1] = temp;
                    }
        }
        static void outputArray(int[] a)
        {
            Console.Write("{");
            foreach (int i in a)
                Console.Write("{0} ", i);
            Console.WriteLine("}");
            Console.WriteLine();
        }
        static int Gauss(double[,] a)
        {
            int k, i, j, n = 4;
            double temp;
            for (k = 0; k < n - 1; k++)
                for (i = k + 1; i < n; i++)
                {
                    temp = a[i, k] / a[k, k];
                    for (j = k; j < n; j++)
                        a[i, j] -= temp * a[k, j];
                }
            double det = 1;
            for (i = 0; i < n; i++)
                det *= a[i, i];
            Console.WriteLine("det A= {0}", det);
            return 0;
        }
        static void splitJoin()
        {
            char[] delimiterChars = { ' ', ',', '.', ':', '\t' };

            string text = "one\ttwo three:four,five six seven";
            Console.WriteLine($"Original text: '{text}'");

            string[] words = text.Split(delimiterChars);
            Console.WriteLine($"{words.Length} words in text:");

            foreach (var word in words)
            {
                Console.WriteLine($"<{word}>");
            }
            string newtext;
            newtext = string.Join(' ', words);
            Console.WriteLine();
            Console.WriteLine(newtext);

        }
        static void FunWithStnngBuilder()
        {
            Console.WriteLine("=> Using the StringBuilder:");
            StringBuilder sb = new StringBuilder("**** Drinks ****");
            sb.Append("\n");
            sb.AppendLine("Tea");
            sb.AppendLine("Coffee");
            sb.AppendLine("Hot" + "Chocolate");
            sb.AppendLine("Whiskey");
            Console.WriteLine(sb.ToString());
            sb.Replace("Whiskey", "Green tea");
            Console.WriteLine(sb.ToString());
            Console.WriteLine("sb has {0} chars.", sb.Length);
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\t 1. One-Dimensional arrays \n\t 2. Two-Dimensional arrays \n\t 3. Fun with strings \n\t 4. Split/Join \n\t 0. Exit");
                object a = Console.ReadLine();
                var choice = int.TryParse(a.ToString(), out int b) ? b : a;
                Console.Clear();
                switch (choice)
                {
                    case string c when c.ToLower() == "one-dimensional arrays":
                    case int i when i == 1:
                        {
                            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                            Console.Write("Array before sort A[]=");
                            outputArray(array);
                            evenLast(ref array);
                            Console.Write("Array after sort A[]=");
                            outputArray(array);
                            break;
                        }
                    case string c when c.ToLower() == "two-dimensional arrays":
                    case int i when i == 2:
                        {
                            double[,] Array = { { 1.0, 2.0, 3.0, 4.0},
                                                { 5.0, 6.0, 7.0, 8.0},
                                                {9.0, 10.0, 21.0, 12.0},
                                                 { 13.0, 14.0, 15.0, 17.0 }};
                            Gauss(Array);
                            break;
                        }
                    case string c when c.ToLower() == "fun with strings":
                    case int i when i == 3:
                        {
                            someStringMethod();
                            break;
                        }
                    case string c when c.ToLower() == "split/join":
                    case int i when i == 4:
                        {
                            splitJoin();
                            break;
                        }
                    case string c when c.ToLower() == "exit":
                    case int i when i == 0:
                        {
                            return;
                        }
                }
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}