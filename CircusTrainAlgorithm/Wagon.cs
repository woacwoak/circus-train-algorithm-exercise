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
                total += Animal.sizeInPoints;
            }
            return total;
        }

        public bool CanAdd(Animal animal)
        {
            if(CurrentPoints() + animal.sizeInPoints <= MaxCapacity)
                return false;

            if(isSpecial)
            {
                if (Animals.Count >= 2) return false;
                if (animal.sizeInPoints == 5) return false;

                return true;
            }
            //Add additional checks
            return true;
        }
        public bool TryAddAnimal(Animal animal)
        {
            if (CanAdd(animal))
            {
                Animals.Add(animal);
                return true;
            }
            return false;
        }
    }
}
