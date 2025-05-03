using System;
using System.Collections.Generic;
using System.Globalization;

namespace ScienceTools
{
    public readonly record struct Element(string Symbol, int AtomicNumber, double AtomicMass);

    public static class Program
    {
        private static readonly Dictionary<string, Element> elements = new(StringComparer.OrdinalIgnoreCase)
        {
            ["hydrogen"] = new("H", 1, 1.008),
            ["helium"] = new("He", 2, 4.0026),
            ["carbon"] = new("C", 6, 12.011),
            ["nitrogen"] = new("N", 7, 14.007),
            ["oxygen"] = new("O", 8, 15.999),
            ["sodium"] = new("Na", 11, 22.990),
            ["chlorine"] = new("Cl", 17, 35.45),
            ["iron"] = new("Fe", 26, 55.845),
            ["copper"] = new("Cu", 29, 63.546),
            ["gold"] = new("Au", 79, 196.9665),
            ["silver"] = new("Ag", 47, 107.8682),
            ["aluminum"] = new("Al", 13, 26.9815),
            ["neon"] = new("Ne", 10, 20.1797),
            ["argon"] = new("Ar", 18, 39.948),
            ["krypton"] = new("Kr", 36, 83.798),
            ["xenon"] = new("Xe", 54, 131.293),
            ["radon"] = new("Rn", 86, 222.018)
        };

        private static void ListAvailableElements()
        {
            Console.WriteLine("\nAvailable Elements:");
            foreach (var pair in elements)
            {
                Console.WriteLine($"  - {pair.Key} ({pair.Value.Symbol})");
            }
            Console.WriteLine();
        }

        private static double? CalculateCompoundMass(string e1, int c1, string e2, int c2)
        {
            if (elements.TryGetValue(e1.ToLower(), out var el1) &&
                elements.TryGetValue(e2.ToLower(), out var el2))
            {
                return (el1.AtomicMass * c1) + (el2.AtomicMass * c2);
            }
            return null;
        }

        private static void Fibonacci(int n)
        {
            if (n <= 0)
            {
                Console.WriteLine("Please enter a positive integer greater than zero for Fibonacci terms.");
                return;
            }

            int a = 0, b = 1;
            Console.Write("Fibonacci Series: ");
            for (int i = 0; i < n; i++)
            {
                Console.Write(a + (i < n - 1 ? " " : "\n"));
                int next = a + b;
                a = b;
                b = next;
            }
        }

        private static void HackingTool()
        {
            const string targetFile = "<data><user>admin</user><password>justice2025</password></data>";
            int attempts = 3;

            Console.WriteLine("\n=== XSL HACKING TOOL INTERFACE ===");
            Console.WriteLine($"Encrypted File: {targetFile}");
            Console.WriteLine("Your task: Guess the admin password.");

            while (attempts > 0)
            {
                Console.Write($"Enter password guess ({attempts} attempt{(attempts > 1 ? "s" : "")} left): ");
                string? guess = Console.ReadLine();

                if (guess == "justice2025")
                {
                    Console.WriteLine("\nACCESS GRANTED. Decryption Successful.");
                    Console.WriteLine("[Extracted XML Data]");
                    Console.WriteLine("  User: admin");
                    Console.WriteLine("  Password: justice2025");
                    return;
                }

                Console.WriteLine("ACCESS DENIED.");
                attempts--;
            }

            Console.WriteLine("\nSYSTEM LOCKED. Intrusion Detected.");
        }

        private static int ReadInt(string prompt)
        {
            int value;
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out value))
                {
                    return value;
                }
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
        }

        public static void Main()
        {
            int choice;
            do
            {
                Console.WriteLine("\n=== MAIN MENU ===");
                Console.WriteLine("1. List Elements");
                Console.WriteLine("2. Calculate Compound Mass");
                Console.WriteLine("3. Fibonacci Series");
                Console.WriteLine("4. Hacking Tool");
                Console.WriteLine("0. Exit");
                choice = ReadInt("Enter your choice: ");

                switch (choice)
                {
                    case 1:
                        ListAvailableElements();
                        break;

                    case 2:
                        Console.Write("Enter the first element name: ");
                        string? element1 = Console.ReadLine()?.Trim();
                        int count1 = ReadInt($"Enter number of atoms for {element1}: ");

                        if (count1 <= 0)
                        {
                            Console.WriteLine("Number of atoms must be positive.");
                            break;
                        }

                        Console.Write("Enter the second element name: ");
                        string? element2 = Console.ReadLine()?.Trim();
                        int count2 = ReadInt($"Enter number of atoms for {element2}: ");

                        if (count2 <= 0)
                        {
                            Console.WriteLine("Number of atoms must be positive.");
                            break;
                        }

                        double? mass = CalculateCompoundMass(element1!, count1, element2!, count2);
                        if (mass == null)
                        {
                            Console.WriteLine("\nError: One or both elements not found in the database.");
                        }
                        else
                        {
                            Console.WriteLine($"\nCompound: {count1} {element1!.ToLower()} + " +
                                            $"{count2} {element2!.ToLower()}");
                            Console.WriteLine($"Estimated Molecular Mass: {mass.Value.ToString("F4", CultureInfo.InvariantCulture)} g/mol");
                        }
                        break;

                    case 3:
                        int n = ReadInt("Enter number of Fibonacci terms: ");
                        Fibonacci(n);
                        break;

                    case 4:
                        HackingTool();
                        break;

                    case 0:
                        Console.WriteLine("Exiting program. Goodbye!");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            } while (choice != 0);
        }
    }
}
