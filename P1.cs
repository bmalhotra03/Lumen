using System;
using lumenClass;

namespace P1
{
    class P1
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int numObjects = 5;
            Lumen[] lumens = new Lumen[numObjects];

            // Initialize objects with random values
            for (int i = 0; i < numObjects; i++)
            {
                int b = random.Next(1, 100);
                int s = random.Next(1, 4);
                int p = random.Next(1, 100);
                lumens[i] = new Lumen(b, s, p);
            }

            // Simulate glowing for each object
            for (int i = 0; i < numObjects; i++)
            {
                Console.WriteLine($"Lumen {i+1}:");
                for (int j = 0; j < 10; j++) // simulate 10 glows
                {
                    int brightness = lumens[i].glow();
                    Console.WriteLine($"  Glow {j+1}: brightness={brightness}");
                    if (!lumens[i].isActive())
                    {
                        Console.WriteLine("  Lumen is inactive.");
                        break;
                    }
                    if (!lumens[i].isStable())
                    {
                        Console.WriteLine("  Lumen is unstable.");
                    }
                }
                Console.WriteLine();
            }

            // Reset objects if necessary
            for (int i = 0; i < numObjects; i++)
            {
                if (lumens[i].glowCount >= Lumen.RESET_THRESHOLD)
                {
                    Console.WriteLine($"Resetting Lumen {i+1}...");
                    lumens[i].Reset();
                    Console.WriteLine($"  New brightness: {lumens[i].initialBrightness}");
                    Console.WriteLine($"  New power: {lumens[i].initialPower}");
                    Console.WriteLine();
                }
            }
        }
    }
}