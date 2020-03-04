using System;
using System.Globalization;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

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

            #region WorkWithDateCulture
            WorkWithDateCulture();
            #endregion

            #region Dispose&Finalazer
            using (var owner = new PetOwner())
            {
                owner.Name = "John";
                owner.AddPet(new Pet("Lola", "Dog"));
                owner.AddPet(new Pet("Murka", "Cat"));
            }
            #endregion
            #region WorkWithDateTime
            WorkWithDateTime();
            #endregion

        }

        public static void WorkWithDateCulture()
        {

            FileInfo file = new FileInfo("SavingDate.txt");
            if (!file.Exists)
            {
                file.Create();
            }

            using (var fileWriter = new StreamWriter("SavingDate.txt"))
            {
                fileWriter.WriteLine(DateTime.Now.ToString(), CultureInfo.CurrentCulture);
            }
            string SavingDate;
            using (var fileReader = new StreamReader("SavingDate.txt"))
            {
                SavingDate = fileReader.ReadLine();
            }

            DateTime newDate = DateTime.Parse(SavingDate, CultureInfo.InvariantCulture);
            Console.WriteLine($"Current culture: {newDate.ToString(CultureInfo.CurrentCulture)}");
            Console.WriteLine($"Usa culture: {newDate.ToString(CultureInfo.GetCultureInfo("en-us"))}");
            Console.WriteLine($"Chinese culture: {newDate.ToString(CultureInfo.GetCultureInfo("cn-CN"))}");
        }

        public static void WorkWithDateTime()
        {
            var timeSpan = new TimeSpan(365, 0, 0, 0);
            Console.WriteLine($"There will be {DateTime.Now.Add(timeSpan).DayOfYear} day of year after {timeSpan.Days} days");

            DateTime Offset = new DateTime(DateTime.Now.Ticks, DateTimeKind.Unspecified);

            DateTimeOffset nowOffset = new DateTimeOffset(Offset, TimeSpan.FromHours(3));

            Console.WriteLine(Offset);
            Console.WriteLine(nowOffset);

            TimeZoneInfo timeZone = TimeZoneInfo.Local;

            Console.WriteLine(timeZone.IsDaylightSavingTime(DateTime.Now) ?
                         timeZone.DaylightName : timeZone.StandardName);
        }
    }

    class PetOwner : IDisposable
    {
        public string Name { get; set; }
        List<Pet> Pets { get; set; }

        public PetOwner()
        {
            Pets = new List<Pet>();
        }

        public PetOwner(string name, Pet pet)
        {
            Name = name;
            Pets = new List<Pet>();
            Pets.Add(pet);
        }
        public void AddPet(Pet pet)
        {
            Pets.Add(pet);
        }

        public void Dispose()
        {
            for (int i = 0; i < Pets.Count; i++)
                Pets[i] = default;
            Pets = null;
            Name = default;
            Console.WriteLine("PetOwner is disposed!");
        }
    }

    public class Pet
    {
        public string Name { get; set; }
        public string Category { get; set; }

        public Pet()
        {

        }
        public Pet(string name, string category)
        {
            Name = name;
            Category = category;
        }
        ~Pet()
        {
            Name = default;
            Category = default;
        }
    }
}