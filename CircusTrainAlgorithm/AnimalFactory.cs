using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace CircusTrainAlgorithm
{
    public class AnimalFactory
    {
        public static Animal CreateAnimal()
        {
            AnimalDiet diet = GetDietFromUser();
            AnimalSize size = GetSizeFromUser();
            Animal animal = new Animal(diet, size);
            Message.Success("You've created a new animal successfully!");
            Message.Success($"Your animals diet: {animal.Diet}; Animal size: {animal.Size}");
            return animal;
        }

        

        private static AnimalDiet GetDietFromUser()
        {
            AnimalDiet diet;
            bool dietIsValid = false;
            do
            {
                Console.WriteLine("Please enter your animal diet. Carnivore (meat-eating) or Herbivore (plant-eating)");
                string input = Console.ReadLine().Trim().ToLower();

                dietIsValid = Enum.TryParse(input, true, out diet);


                if (!dietIsValid)
                {
                    Message.Error("Invalid input. Please enter Carnivore or Herbivore.");
                }
            }
            while (!dietIsValid);
            Message.Success($"Success! You selected {diet} diet.");
            return diet;
        }

        private static AnimalSize GetSizeFromUser()
        {
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
                    Message.Error("Animal's size you input is invalid. Choose one of the following:  Small (1 point), Medium (3 points), Large (5 points)");
                }
            } while (!sizeIsValid);
            Message.Success($"Success! You selected {size} size.");
            return size;
        }

        public static Animal CreateRandomAnimal()
        {
            AnimalDiet diet = GenerateRandomDiet();
            AnimalSize size = GenerateRandomSize();
            Animal animal = new Animal(diet, size);
            Message.Success("You've generated a new animal successfully!");
            Message.Success($"Animal diet: {animal.Diet}; Animal size: {animal.Size}");
            return animal;
        }
        public static AnimalDiet GenerateRandomDiet()
        {
            Random rand = new Random();
            Array values = Enum.GetValues(typeof(AnimalDiet));
            int randomIndex = rand.Next(values.Length);
            AnimalDiet randomDiet = (AnimalDiet)values.GetValue(randomIndex);
            return randomDiet;
        }
        public static AnimalSize GenerateRandomSize()
        {
            Random rand = new Random();
            Array values = Enum.GetValues(typeof(AnimalSize));
            int randomIndex = rand.Next(values.Length);
            AnimalSize randomSize = (AnimalSize)values.GetValue(randomIndex);
            return randomSize;
        }

        public static List<Animal> CreateListWithRandomAnimals(int numberOfAnimals)
        {
            List<Animal> list = new List<Animal>();
            for(int i = 0; i < numberOfAnimals; i++)
            {
                Message.Success($"[{i + 1}]");
                list.Add(CreateRandomAnimal());
            }
            return list;
        }
    }
}
