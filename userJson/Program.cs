using System;
using Newtonsoft.Json.Linq;

namespace zadanieDom
{
    class Program
    {
        class User
        {
            public string Name { get; set; }
            public int Age { get; set; }

            // Simply method to calculate age: https://stackoverflow.com/a/11942
            public int CalculateAge(int year, int month, int day)
            {
                var today = (DateTime.Today.Year * 100 + DateTime.Today.Month) * 100 + DateTime.Today.Day;
                var birthday = (year * 100 + month) * 100 + day;
                return (today - birthday) / 10000;
            }
        }
        
        public static JObject CreateJson(string firstName, string secondName, int year, int month, int day)
        {
            User newUser = new User();
            newUser.Name = firstName + " " + secondName;
            newUser.Age = newUser.CalculateAge(year, month, day);
            JObject jasonUser = JObject.FromObject(newUser);
            return jasonUser;
        }

        static void Main(string[] args)
        {

            if (args.Length == 3)
            {
                bool validYear, validMonth, validDay;
                string[] dateNumbersString = args[2].Split('.');

                validYear = int.TryParse(dateNumbersString[0], out int argsYear);
                validMonth = int.TryParse(dateNumbersString[1], out int argsMonth);
                validDay = int.TryParse(dateNumbersString[2], out int argsDay);

                if (validYear && validMonth && validDay)
                {
                    JObject dataFromArgs = CreateJson(args[0], args[1], argsYear, argsMonth, argsDay);
                    Console.WriteLine(dataFromArgs);
                }
            }
            else
            {
                Console.WriteLine("Wprowadź imię, nazwisko i datę urodzenia");
                Console.WriteLine("w formacie 'imię nazwisko yyyy.mm.dd': \n");
                string userInput = Console.ReadLine();
                string[] userData = userInput.Split(' ');

                if (userData.Length != 3)
                {
                    Console.WriteLine("Podałeś nieprawidłowy format wejściowy.");
                }
                else
                {
                    string[] numbersInDate = userData[2].Split('.');
                    bool validYear, validMonth, validDay;
                    validYear = int.TryParse(numbersInDate[0], out int userYear);
                    validMonth = int.TryParse(numbersInDate[1], out int userMonth);
                    validDay = int.TryParse(numbersInDate[2], out int userDay);

                    if (validYear && validMonth && validDay)
                    {
                        JObject userObject = CreateJson(userData[0], userData[1], userYear, userMonth, userDay);
                        Console.WriteLine(userObject);
                    }
                    else
                    {
                        Console.WriteLine("Podałeś nieprawidłową datę.");
                    }
                }
            }

            Console.ReadKey();

        }
    }
}