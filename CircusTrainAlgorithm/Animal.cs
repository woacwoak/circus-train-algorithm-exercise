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
        public AnimalSize size;

        public Animal(AnimalDiet diet, AnimalSize size)
        {
            this.diet = diet;
            this.size = size;
        }
    }
}
