using System;
using System.CodeDom.Compiler;
using System.Security.Cryptography.X509Certificates;

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
            Console.WriteLine("-----------------------------------------------\n");
            Console.ResetColor();

            

            bool running = true;
            while (running)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Choose one of the following:");
                Console.WriteLine("(0) Quit");
                Console.WriteLine("(1) Create your animal");
                Console.WriteLine("(2) Generate a random animal");
                Console.WriteLine("(3) Generate a list with random animals and distribute to the wagons");
                Console.ResetColor();

                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "0":
                        running = false;
                        break;
                    case "1":
                        AnimalFactory.CreateAnimal();
                        break;
                    case "2":
                        AnimalFactory.CreateRandomAnimal();
                        break;
                    case "3":
                        Console.WriteLine("Enter a number of animals you want to generate:");
                        if (int.TryParse(Console.ReadLine(), out int count))
                        {
                            List<Animal> generatedAnimals = AnimalFactory.CreateListWithRandomAnimals(count);

                            CircusTrain myTrain = new CircusTrain();
                            myTrain.OptimizeDistribution(generatedAnimals);

                            Console.WriteLine($"Successfully packed {count} animals into {myTrain.Wagons.Count} wagons!");
                        }
                        
                        break;
                    case "4":
                        break;

                    default:
                        Message.Error("Error! The value you entered is invalid. Enter a proper number.");
                        break;
                }
            }
        }
    }
}