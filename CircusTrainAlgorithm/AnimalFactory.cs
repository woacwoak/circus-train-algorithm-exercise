using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace CircusTrainAlgorithm
{
    public class AnimalFactory
    {
        public static void CreateAnimal()
        {
            AnimalDiet diet = GetDietFromUser();
            AnimalSize size = GetSizeFromUser();
            
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
                    Message.ErrorMessage("Invalid input. Please enter Carnivore or Herbivore.");
                }
            }
            while (!dietIsValid);
            Console.WriteLine($"Success! You selected {diet} diet.");
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
                    Message.ErrorMessage("Animal's size you input is invalid. Choose one of the following:  Small (1 point), Medium (3 points), Large (5 points)");
                }
            } while (!sizeIsValid);
            Console.WriteLine($"Success! You selected {size} size.");
            return size;
        }
    }
}
