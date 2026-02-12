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



            AnimalDiet diet;
            bool dietIsValid = false;
            do
            {
                Console.WriteLine("Please enter your animal diet. Carnivore (meat-eating) or Herbivore (plant-eating)");
                string input = Console.ReadLine().Trim().ToLower();

                dietIsValid = Enum.TryParse(input, true, out diet);


                if(!dietIsValid)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Please enter Carnivore or Herbivore.");
                    Console.ResetColor();
                }
            }
            while (!dietIsValid);
            Console.WriteLine($"Success! You selected {diet} diet.");


            AnimalSize size;
            bool sizeIsValid = false;
            int sizeInPoints = 0;
            do
            {
                Console.WriteLine("Please enter your animal size. Small (1 point), Medium (3 points), Large (5 points)");
                string input = Console.ReadLine().Trim().ToLower();
                sizeIsValid = Enum.TryParse(input, true, out size);

                if (!sizeIsValid)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Animal's size you input is invalid. Choose one of the following:  Small (1 point), Medium (3 points), Large (5 points)");
                    Console.ResetColor();
                }
            } while (!sizeIsValid);
            Console.WriteLine($"Success! You selected {size} size.");

            Animal animal = new Animal(diet, sizeInPoints);

            Console.WriteLine($"Your animal's diet is {animal.diet} and it's size costs {animal.sizeInPoints} points.");
        }
    }
}