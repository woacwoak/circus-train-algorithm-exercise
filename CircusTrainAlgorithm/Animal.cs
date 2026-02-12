using System;
using System.Collections.Generic;
using System.Text;

public enum AnimalDiet { Carnivore, Herbivore}

public enum AnimalSize
{
    Small = 1,
    Medium = 3,
    Large = 5
}

namespace CircusTrainAlgorithm
{
    public class Animal
    {
        public AnimalDiet diet;
        public int sizeInPoints;

        public Animal(AnimalDiet diet, int sizeInPoints)
        {
            this.diet = diet;
            this.sizeInPoints = sizeInPoints;
        }
    }
}
