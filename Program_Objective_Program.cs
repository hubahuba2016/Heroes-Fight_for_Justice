using System;
using System.Collections.Generic;
using System.Globalization;

class Element
{
    public string Symbol { get; set; }
    public int AtomicNumber { get; set; }
    public double AtomicMass { get; set; }
}

class Program
{
    // Dictionary of elements with lowercase names as keys
    static readonly Dictionary<string, Element> elements = new Dictionary<string, Element>
    {
        // Non-metals
        {"hydrogen", new Element { Symbol = "H", AtomicNumber = 1, AtomicMass = 1.008 }},
        {"helium", new Element { Symbol = "He", AtomicNumber = 2, AtomicMass = 4.0026 }},
        {"carbon", new Element { Symbol = "C", AtomicNumber = 6, AtomicMass = 12.011 }},
        {"nitrogen", new Element { Symbol = "N", AtomicNumber = 7, AtomicMass = 14.007 }},
        {"oxygen", new Element { Symbol = "O", AtomicNumber = 8, AtomicMass = 15.999 }},
        {"sodium", new Element { Symbol = "Na", AtomicNumber = 11, AtomicMass = 22.990 }},
        {"chlorine", new Element { Symbol = "Cl", AtomicNumber = 17, AtomicMass = 35.45 }},

        // Metals
        {"iron", new Element { Symbol = "Fe", AtomicNumber = 26, AtomicMass = 55.845 }},
        {"copper", new Element { Symbol = "Cu", AtomicNumber = 29, AtomicMass = 63.546 }},
        {"gold", new Element { Symbol = "Au", AtomicNumber = 79, AtomicMass = 196.9665 }},
        {"silver", new Element { Symbol = "Ag", AtomicNumber = 47, AtomicMass = 107.8682 }},
        {"aluminum", new Element { Symbol = "Al", AtomicNumber = 13, AtomicMass = 26.9815 }},

        // Noble gases
        {"neon", new Element { Symbol = "Ne", AtomicNumber = 10, AtomicMass = 20.1797 }},
        {"argon", new Element { Symbol = "Ar", AtomicNumber = 18, AtomicMass = 39.948 }},
        {"krypton", new Element { Symbol = "Kr", AtomicNumber = 36, AtomicMass = 83.798 }},
        {"xenon", new Element { Symbol = "Xe", AtomicNumber = 54, AtomicMass = 131.293 }},
        {"radon", new Element { Symbol = "Rn", AtomicNumber = 86, AtomicMass = 222.018 }}
    };

    static void ListAvailableElements()
    {
        Console.WriteLine("Available Elements:");
        foreach (var kvp in elements)
        {
            Console.WriteLine($"  - {kvp.Key} ({kvp.Value.Symbol})");
        }
        Console.WriteLine();
    }

    static void DisplayElement(string name)
    {
        string lowerName = name.ToLower();

        if (elements.ContainsKey(lowerName))
        {
            var el = elements[lowerName];
            Console.WriteLine("\nElement Details:");
            Console.WriteLine($"  Name          : {CultureInfo.CurrentCulture.TextInfo.ToTitleCase(lowerName)}");
            Console.WriteLine($"  Symbol        : {el.Symbol}");
            Console.WriteLine($"  Atomic Number : {el.AtomicNumber}");
            Console.WriteLine($"  Atomic Mass   : {el.AtomicMass:F4}");
        }
        else
        {
            Console.WriteLine($"\nElement '{name}' not found in the database.");
        }
    }

    static void Main()
    {
        ListAvailableElements();

        Console.WriteLine("Example valid inputs: 'oxygen', 'gold', 'neon'");
        Console.WriteLine("Note: Please type the element name exactly as shown (case-insensitive).\n");

        Console.Write("Enter the element name from the list above: ");
        string input = Console.ReadLine();

        DisplayElement(input);
    }
}