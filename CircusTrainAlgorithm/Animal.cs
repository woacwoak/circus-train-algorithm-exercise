using System;
using System.Collections.Generic;
using System.Text;

namespace CircusTrainAlgorithm
{
    public class Animal
    {
        public string diet;
        public int sizeInPoints;

        public Animal(string diet, int sizeInPoints)
        {
            this.diet = diet;
            this.sizeInPoints = sizeInPoints;
        }
    }
}
