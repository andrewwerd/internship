using System;
using System.Collections;

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

        public Angle()
        {
            _degrees = _minutes = _seconds = 0;
        }
        public Angle(int seconds)
        {
            toDefault(seconds);
        }
        public Angle(int degrees, int minutes, int seconds)
        {
            if (minutes > 60)
            {
                _degrees = degrees + minutes / 60;
            }
            if (seconds > 60)
            {
                _minutes = minutes + seconds / 60;
                _degrees = degrees + minutes / 60;
            }
            _degrees = degrees;
            _minutes = minutes;
            _seconds = seconds;
        }
        private Angle toDefault(int seconds)
        {
            _degrees = seconds / 3600;
            _minutes = seconds / 60 % 60;
            _seconds = seconds % 60;
            return this;

        }
        public string toString()
        {
            string s = "";
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
            if (a1.toSeconds() < a2.toSeconds())
            {
                Console.WriteLine("Ошиииииииииииибка!");
                return a1;
            }
            return a.toDefault(a1.toSeconds() - a2.toSeconds());
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
            return text + a.toString();
        }
        public static bool operator >(Angle a1, Angle a2)
        {
            if (a1.toSeconds() > a2.toSeconds())
                return true;
            else return false;
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
        //    #region magic yield return
        //    The yield keyword is used to specify the value(or values)
        //    to be returned to the caller’s foreach construct.
        //    When the yield return statement is reached, the current location in the container is stored, 
        //    and execution is restarted from this location the next time the iterator is called.
        //    yield return this[0];
        //    yield return this[1];
        //    yield return this[2];
        //    #endregion
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
            int i = 0;
            for (i = 0; i < 3; i++)
                yield return this[i];
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Angle a = new Angle(3, 36, 53);
            Angle b = new Angle(4, 27, 45);
            Angle c = new Angle();
            Console.WriteLine();
            c = a + b;
            Console.WriteLine("a = " + a + "\nb = " + b + "\na + b = " + c);
            foreach (int i in a)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine($"a compare to b{b.CompareTo(a)}");
        }
    }
}
