using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace CircusTrainAlgorithm
{
    public class Wagon
    {
        private const int MaxCapacity = 10;
        private bool isSpecial;
        public bool IsSpecial { get { return isSpecial; } }

        public List<Animal> Animals { get; private set; }

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
                total += Animal.SizePoints;
            }
            return total;
        }

        public bool CanAdd(Animal animal)
        {
            if(CurrentPoints() + animal.SizePoints > MaxCapacity)
                return false;

            if(isSpecial)
            {
                if (Animals.Count > 2) return false;
                if (animal.Size == AnimalSize.Large) return false;
                return true;
            }
            if(animal.Diet == AnimalDiet.Carnivore)
            {
                foreach(Animal existing in Animals)
                {
                    if(existing.SizePoints <= animal.SizePoints)
                    {
                        return false;
                    }
                }
            }
            foreach(Animal existing in Animals)
            {
                if(existing.Diet == AnimalDiet.Carnivore)
                {
                    if(existing.SizePoints >= animal.SizePoints)
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
