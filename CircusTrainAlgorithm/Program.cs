using System;

namespace CircusTrainAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("***********************************************");
            Console.WriteLine("           *WELCOME TO THE SHOW!*");
            Console.WriteLine("***********************************************");

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(@"
  ____ ___ ____   ____ _   _ ____    _____ ____     _    ___ _   _ 
 / ___|_ _|  _ \ / ___| | | / ___|  |_   _|  _ \   / \  |_ _| \ | |
| |    | || |_) | |   | | | \___ \    | | | |_) | / _ \  | ||  \| |
| |___ | ||  _ <| |___| |_| |___) |   | | |  _ < / ___ \ | || |\  |
 \____|___|_| \_\\____|\___/|____/    |_| |_| \_/_/   \_\___|_| \_|
");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("-------------- THE STORY OF HANS --------------");
            Console.WriteLine("Hans needs your help! Rent is high and animals are hungry.");
            Console.WriteLine("Pack the wagons. Save the animals. Don't go broke.");
            Console.WriteLine("-----------------------------------------------\n");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("INSTRUCTIONS:");
            Console.WriteLine("Every animal boarding the train must be logged.");
            Console.WriteLine("We need to know two things:");
            Console.WriteLine("1. DIET: Are they a Carnivore or a Herbivore?");
            Console.WriteLine("2. SIZE: Small (1pt), Medium (3pts), or Large (5pts)?");
            Console.WriteLine("-----------------------------------------------");
            Console.ResetColor();



            string animalDiet;
            bool dietIsValid = false;

            do
            {
                Console.WriteLine("Please enter your animal diet. Carnivore (meat-eating) or Herbivore (plant-eating)");
                animalDiet = Console.ReadLine().Trim().ToLower();
                switch (animalDiet)
                {
                    case "carnivore":
                        dietIsValid = true;
                        break;
                    case "herbivore":
                        dietIsValid = true;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Diet should be either Carnivore or Herbivore");
                        Console.ResetColor();
                        break;
                }
            }
            while (!dietIsValid);
            Console.WriteLine($"Success! You selected {animalDiet} diet.");

            string animalSize;
            bool sizeIsValid = false;
            int sizeInPoints = 0;
            do
            {
                Console.WriteLine("Please enter your animal size. Small (1 point), Medium (3 points), Large (5 points)");
                animalSize = Console.ReadLine().Trim().ToLower();
                switch (animalSize)
                {
                    case "small":
                        sizeIsValid = true;
                        sizeInPoints = 1;
                        break;
                    case "medium":
                        sizeIsValid = true;
                        sizeInPoints = 3;
                        break;
                    case "large":
                        sizeIsValid = true;
                        sizeInPoints = 5;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Animal's size you input is invalid. Choose one of the following:  Small (1 point), Medium (3 points), Large (5 points)");
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                }
            } while (!sizeIsValid);
            Console.WriteLine($"Another success! You selected {animalSize} size.");

            Animal animal = new Animal(animalDiet, sizeInPoints);

            Console.WriteLine($"Your animal's diet is {animal.diet} and it's size costs {animal.sizeInPoints} points.");
        }
    }
}