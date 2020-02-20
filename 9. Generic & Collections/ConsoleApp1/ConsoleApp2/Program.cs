using System;
using System.Collections;
using System.Collections.Generic;
namespace ConsoleApp2
{
    class MyList<T> : IEnumerable
    {
        T[] Items;
        private void TryResize()
        {
            Count++;
            if (Items.Length <= Count)
            {
                Array.Resize(ref Items, Items.Length == 0 ? 1 : Items.Length * 2);
            }
        }
        public int Capacity => Items.Length;
        public int Count { get; private set; }
        public T this[int index]
        {
            get
            {
                return Items[index];
            }
            set
            {
                Items[index] = value;
            }
        }
        public MyList()
        {
            Items = new T[1];
            Count = 0;
        }
        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
                if (Items[i].Equals(item)) return i;
            throw new Exception("Not such item!");
        }
        public void Add(T Item)
        {
            TryResize();
            Items[Count - 1] = Item;
        }
        public void Remove(int index)
        {
            for (var i = index; i < Count - 1; i++)
            {
                Items[i] = Items[i + 1];
            }
            Items[Count - 1] = default(T);
            Count--;
        }
        public void Remove(T item) => Remove(IndexOf(item));
        public void TrimList() => Array.Resize(ref Items, Count);
        public void Clear()
        {
            Count = 0;
            Array.Clear(Items, 0, Capacity);
            Array.Resize(ref Items, Count+1);
        }
        public void Swap(int index1, int index2)
        {
            T temp = Items[index1];
            Items[index1] = Items[index2];
            Items[index2] = temp;
        }
        public void Swap(T item1, T item2) => Swap(IndexOf(item1), IndexOf(item2));
        IEnumerator IEnumerable.GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
                yield return this[i];
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyList<string> test = new MyList<string>() { "one", "two", "three", "four", "five" };
            Console.WriteLine($"MyList Count = {test.Count}  Capacity ={test.Capacity}");
            foreach (var i in test)
                Console.WriteLine(i);
            test.Add("six"); 
            Console.WriteLine($"MyList after add Six Count = {test.Count}  Capacity = {test.Capacity}");
            foreach (var i in test)
                Console.WriteLine(i);
            test.Remove("one");
            Console.WriteLine($"MyList after remove One Count = {test.Count}  Capacity = {test.Capacity}");
            foreach (var i in test)
                Console.WriteLine(i);
            test.TrimList();
            Console.WriteLine($"MyList after trim Count = {test.Count}  Capacity = {test.Capacity}");
            foreach (var i in test)
                Console.WriteLine(i);
            test.Swap("two","four");
            Console.WriteLine($"MyList after trim Count = {test.Count}  Capacity = {test.Capacity}");
            foreach (var i in test)
                Console.WriteLine(i);
            for (int i = 0; i < 10; i++)
            {
                test.Add($"Car {i}");
            }
            Console.WriteLine($"MyList after add ten cars Count = {test.Count}  Capacity = {test.Capacity}");
            foreach (var i in test)
                Console.WriteLine(i);
            test.Clear();
            Console.WriteLine($"MyList after cleaning Count = {test.Count}  Capacity = {test.Capacity}");
            foreach (var i in test)
                Console.WriteLine(i);
        }
    }
}
