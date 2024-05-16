using System;
using System.Threading;

class AtomreaktorSimulator
{
    private static Random random = new Random();
    private static bool isRunning = false;
    private static double generatedEnergy = 0;
    private static int temperature = 40;

    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Atomreaktor Szimulátor");
            Console.WriteLine("1. Beindítás");
            Console.WriteLine("2. Leállítás");
            Console.WriteLine("3. Generált energia mennyiség");
            Console.WriteLine("4. Hőfok");
            Console.WriteLine("5. Hűtővíz beengedése");
            Console.WriteLine("6. Kilépés");
            Console.Write("Válassz egy menüpontot: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    StartReactor();
                    break;
                case "2":
                    StopReactor();
                    break;
                case "3":
                    ShowGeneratedEnergy();
                    break;
                case "4":
                    ShowTemperature();
                    break;
                case "5":
                    CoolReactor();
                    break;
                case "6":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Érvénytelen választás, próbáld újra.");
                    break;
            }
            Thread.Sleep(2000);
        }
    }

    static void StartReactor()
    {
        if (isRunning)
        {
            Console.WriteLine("A reaktor már be van indítva.");
            return;
        }

        Console.WriteLine("A reaktor indítása...");
        Thread.Sleep(3000);
        isRunning = true;
        GenerateTemperature();
        GenerateEnergy();
        Console.WriteLine("A reaktor sikeresen beindítva.");
    }

    static void StopReactor()
    {
        if (!isRunning)
        {
            Console.WriteLine("A reaktor nincs beindítva.");
            return;
        }

        if (temperature >= 70)
        {
            Console.WriteLine("A reaktor hőmérséklete túl magas a biztonságos leállításhoz! Hűtés szükséges.");
        }
        else
        {
            isRunning = false;
            Console.WriteLine("A reaktor biztonságosan leállítva.");
        }
    }

    static void ShowGeneratedEnergy()
    {
        if (!isRunning)
        {
            Console.WriteLine("A reaktor nincs beindítva.");
            return;
        }

        GenerateEnergy();
        Console.WriteLine($"Generált energia: {generatedEnergy:F2} GW");
    }

    static void ShowTemperature()
    {
        if (!isRunning)
        {
            Console.WriteLine("A reaktor nincs beindítva.");
            return;
        }

        GenerateTemperature();
        Console.WriteLine($"Reaktor hőmérséklete: {temperature} °C");
    }

    static void CoolReactor()
    {
        if (!isRunning)
        {
            Console.WriteLine("A reaktor nincs beindítva.");
            return;
        }

        temperature = 40;
        Console.WriteLine("A reaktor hőmérséklete lehűlt 40 °C-ra.");
    }

    static void GenerateEnergy()
    {
        if (!isRunning)
            return;

        generatedEnergy += random.NextDouble() * 10;
    }

    static void GenerateTemperature()
    {
        if (!isRunning)
            return;

        temperature = random.Next(40, 101);
    }
}
