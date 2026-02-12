using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace CircusTrainAlgorithm
{
    public class Wagon
    {
        public const int MaxCapacity = 10;
        public bool isSpecial;

        public List<Animal> Animals { get; set; }

        public Wagon(bool isSpecial)
        {
            this.isSpecial = isSpecial;
            this.Animals = new List<Animal>();
        }
        public int CurrentPoints()
        {
            int total = 0;
            foreach (Animal Animal in Animals)
            {
                total += (int)Animal.size;
            }
            return total;
        }

        public bool CanAdd(Animal animal)
        {
            if(CurrentPoints() + (int)animal.size <= MaxCapacity)
                return false;

            if(isSpecial)
            {
                if (Animals.Count > 2) return false;
                if (animal.size == AnimalSize.Large) return false;
                return true;
            }
            if(animal.diet == AnimalDiet.Carnivore)
            {
                foreach(Animal existing in Animals)
                {
                    if((int)existing.size <= (int)animal.size)
                    {
                        return false;
                    }
                }
            }
            foreach(Animal existing in Animals)
            {
                if(existing.diet == AnimalDiet.Carnivore)
                {
                    if((int)existing.size >= (int)animal.size)
                    {
                        return false;
                    }
                }
            }
            //Add additional checks
            return true;
        }
        public void TryAddAnimal(Animal animal)
        {
            if (!CanAdd(animal))
                Message.Error("Unsafe move. You can't add the animal due to the violation of the rules!");
            else
                Animals.Add(animal);
        }
    }
}
