using System;
using System.Globalization;
using System.IO;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //#region Encoding
            //FileStream textUnicode = new FileStream(@"C:\Users\andrei.tirsina\Documents\Internship\internship\15. Encoding\textUnicode.txt", FileMode.Open, FileAccess.Read);
            //StreamWriter textAscii = new StreamWriter(@"C:\Users\andrei.tirsina\Documents\Internship\internship\15. Encoding\textAscii.txt");
            //string asciiString;

            //Encoding Ascii = Encoding.ASCII;
            //Encoding Unicode = Encoding.Unicode;

            //int length = (int)textUnicode.Length;
            //byte[] buffer = new byte[length];
            //textUnicode.Read(buffer);

            //byte[] asciiByte = buffer;
            //asciiString = Ascii.GetString(asciiByte);
            //asciiString = $"String in ASCII without converting \n {asciiString}";
            //Console.WriteLine(asciiString);
            //textAscii.WriteLine(asciiString);

            //asciiByte = Encoding.Convert(Unicode, Ascii, buffer);
            //asciiString = Ascii.GetString(asciiByte);
            //asciiString = $"String in ASCII with convert \n {asciiString}";
            //Console.WriteLine(asciiString);
            //textAscii.WriteLine(asciiString);

            //textUnicode.Close();
            //textAscii.Close();
            //#endregion

            #region Formating, Search and Comparing

            string PersonInfo = "First name: {0}\nSecond name : {1}\nBirthday {2}.{3}.{4}";
            var date = DateTime.Parse("03.09.1999", CultureInfo.CurrentCulture).Date;
            string person = string.Format(PersonInfo, "Andrew", "Smith", date.Day, date.Month, date.Year);
            Console.WriteLine(person);
            Console.WriteLine($"Person is Andrew?  {person.Contains("Andrew")}\nPerson birthday is 3.9.1999? {person.EndsWith("3.9.1999")}");

            Console.WriteLine("â".Equals("a", StringComparison.CurrentCultureIgnoreCase));
            Console.WriteLine("â".Equals("a", StringComparison.InvariantCulture));
            Console.WriteLine("â".Equals("a", StringComparison.Ordinal));
            #endregion
        }
    }
}
