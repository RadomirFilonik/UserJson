using System;
using userJson.Utilities;

namespace zadanieDom
{
    class Program
    {
        private static readonly CreateJsonFile _createJsonFile = new CreateJsonFile();
        static void Main(string[] args)
        {
            if (args.Length == 3)
            {
                bool sucess;
                var dataFromArgs = _createJsonFile.CreateJson(args[0], args[1], args[2], out sucess);

                if(sucess)
                {
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
                    bool sucess;
                    var dataFromUser = _createJsonFile.CreateJson(userData[0], userData[1], userData[2], out sucess);

                    if (sucess)
                    {
                        Console.WriteLine(dataFromUser);
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