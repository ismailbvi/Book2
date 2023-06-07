using System;

class CarRace
{
    static void Main(string[] args)
    {
        while (true)
        {
            StartRace();

            Console.WriteLine("Reset (Y/N)");
            string input = Console.ReadLine();

            if (input.ToLower() != "y")
                break;
        }
    }
    static void StartRace()
    { 
        int car1Position = 0;
        int car2Position = 0;
        int car3Position = 0;
        int car4Position = 0;
        int car5Position = 0;
        int finishLine = 50;
        Random random = new Random();   

       
        Console.WriteLine("1.2.3");
        Console.WriteLine("Start");

        while (car1Position < finishLine && car2Position < finishLine && car3Position < finishLine && car4Position < finishLine && car5Position < finishLine)
        {
           
            car1Position += random.Next(1, 10);
            car2Position += random.Next(1, 10);
            car3Position += random.Next(1, 10);
            car4Position += random.Next(1, 10);
            car5Position += random.Next(1, 10);

            Console.WriteLine("Ferari s chvqt cherven  : " + new string('-', car1Position) + "-");

            Console.WriteLine("Stara Karavana          : " + new string('-', car2Position) + "-");

            Console.WriteLine("Golf 4 s 4x4            : " + new string('-', car3Position) + "-");

            Console.WriteLine("BMW kartofi             : " + new string('-', car4Position) + "-");

            Console.WriteLine("Mercedes S classa na gaz: " + new string('-', car5Position) + "-");

            System.Threading.Thread.Sleep(1000);
        }

        
        if (car1Position >= finishLine && car2Position >= finishLine && car3Position >= finishLine && car4Position >= finishLine && car5Position >= finishLine)
        {
            Console.WriteLine("Ravenstvo");
        }
        else if (car1Position >= finishLine)
        {
            Console.WriteLine("Ferari s chvqt cherven");
        }
        else if (car2Position >= finishLine)
        {
            Console.WriteLine("Stara Karavana");
        }
        else if (car3Position >= finishLine)
        {
            Console.WriteLine("Golf 4 s 4x4");
        }
        else if (car4Position >= finishLine)
        {
            Console.WriteLine("BMW kartofi");
        }
        else if (car5Position >= finishLine)
        {
            Console.WriteLine("S classa na gaz");
        }

        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();
    }
}
