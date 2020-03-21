using System;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public class AngleEnumerator : IEnumerator
    {
        Angle angle;
        int position = -1;
        public AngleEnumerator(Angle angle)
        {
            this.angle = angle;
        }
        public bool MoveNext()
        {
            if (position < 2)
            {
                position++;
                return true;
            }
            else
                return false;
        }

        public object Current
        {
            get
            {
                if (position < 0 || position > 2)
                    throw new InvalidOperationException();
                return angle[position];
            }
        }
        public void Reset()
        {
            position = -1;
        }
    }
    public class Angle : IEnumerable, IComparable
    {
        private int _degrees;
        private int _minutes;
        private int _seconds;
        public static List<Angle> Angles;
        public Angle()
        {
            _degrees = _minutes = _seconds = 0;
            Angles.Add(this);
        }
        public Angle(int seconds)
        {
            toDefault(seconds);
            Angles.Add(this);
        }
        public Angle(int degrees, int minutes, int seconds)
        {
            if (seconds > 60)
            {
                minutes += seconds / 60;
                seconds %= 60;
            }
            if (minutes > 60)
            {
                degrees += minutes / 60;
                minutes %= 60;
            }
            _degrees = degrees % 360;
            _minutes = minutes;
            _seconds = seconds;
            Angles.Add(this);
        }
        static Angle()
        {
            Angles = new List<Angle>();
        }
        private Angle toDefault(int seconds)
        {
            _degrees = seconds / 3600 % 360;
            _minutes = seconds / 60 % 60;
            _seconds = seconds % 60;
            return this;

        }
        public override string ToString()
        {
            string s = " ";
            s += _degrees.ToString() + "° " + _minutes.ToString() + "\' " + _seconds.ToString() + "\"";
            return s;
        }
        public int toSeconds()
        {
            return _degrees * 3600 + _minutes * 60 + _seconds;
        }
        public static Angle operator +(Angle a1, Angle a2)
        {
            Angle a = new Angle();
            return a.toDefault(a1.toSeconds() + a2.toSeconds());
        }
        public static Angle operator -(Angle a1, Angle a2)
        {
            Angle a = new Angle();
            int i = a1.toSeconds() - a2.toSeconds();
            if (i<0)
                return a.toDefault(360*3600 + i);
            else
                return a.toDefault(i);
        }
        public static Angle operator *(Angle a1, int i)
        {
            Angle a = new Angle();
            return a.toDefault(a1.toSeconds()*i);
        }
        public static Angle operator /(Angle a1, int i)
        {
            Angle a = new Angle();
            return a.toDefault(a1.toSeconds() / i);
        }
        public static bool operator ==(Angle a1, Angle a2)
        {
            if (a1.toSeconds() == a2.toSeconds())
                return true;
            else return false;
        }
        public static bool operator !=(Angle a1, Angle a2)
        {
            if (a1.toSeconds() != a2.toSeconds())
                return true;
            else return false;
        }
        public static string operator +(string text, Angle a)
        {
            return text + a.ToString();
        }
        public static bool operator >(Angle a1, Angle a2)
        {
            return a1.toSeconds() > a2.toSeconds();
        }
        public static bool operator <(Angle a1, Angle a2)
        {
            if (a1.toSeconds() < a2.toSeconds())
                return true;
            else return false;
        }
        public override bool Equals(Object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Angle p = (Angle)obj;
                return (_degrees == p._degrees) && (_minutes == p._minutes) && (_seconds == p._seconds);
            }
        }
        public override int GetHashCode()
        {
            return $"{_degrees}°{ _minutes}\'{ _seconds} \"".GetHashCode();
        }
        public int this[int i]
        {
            get
            {
                switch (i)
                {
                    case 0: return _degrees;
                    case 1: return _minutes;
                    case 2: return _seconds;
                    default: throw new ArgumentException($"Nonexistent index [{i}]");
                }
            }
            set
            {
                switch (i)
                {
                    case 0: { _degrees = value; break; }
                    case 1: { _minutes = value; break; }
                    case 2: { _seconds = value; break; }
                    default: throw new ArgumentException($"Nonexistent index [{i}]");
                }
            }
        }
        //public IEnumerator GetEnumerator()
        //{
        //    return new AngleEnumerator(this);
        //}
        public int CompareTo(object obj)
        {
            if (obj != null)
            {
                Angle a = (Angle)obj;
                return this.toSeconds().CompareTo(a.toSeconds());
            }
            else
                throw new NotImplementedException();
        }
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < 3; i++)
                yield return this[i];
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Angle a = new Angle(10, 36, 53);
            Angle b = new Angle(4, 27, 45);
            Angle c = new Angle(4555);
            Angle d = new Angle(850,98,7);
            Angle e = new Angle(548654);
            Angle f = new Angle(344, 45 ,56);
            Angle j = new Angle(123,5354,5665);
            Angle k = new Angle(45,55,0);
            Angle l = new Angle(85,90,34);
            Angle m = new Angle(40555);

            Console.WriteLine("a = " + a + "\nb = " + b + "\nb-a = " + c);

            Console.WriteLine("Unsorted list: ");
            foreach (Angle i in Angle.Angles)
            { 
                Console.WriteLine($"Angle {Angle.Angles.IndexOf(i)+1} = {i}");
            }

            Angle.Angles.Sort();
            Console.WriteLine("Sorted list: ");
            Angle.Angles.Sort();
            foreach (var i in Angle.Angles)
            {
                Console.WriteLine($"Angle {Angle.Angles.IndexOf(i) + 1} = {i}");
            }
        }
    }
}
