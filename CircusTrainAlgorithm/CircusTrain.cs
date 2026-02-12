using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace CircusTrainAlgorithm
{
    public class CircusTrain
    {
        public List<Wagon> Wagons { get; private set; } = new List<Wagon>();
        private const int MaxSpecialWagons = 4;

        public void OptimizeDistribution(List<Animal> animals)
        {
            Wagons.Clear();

            List<Animal> largeCarnivores = new List<Animal>();
            List<Animal> smallCarnivores = new List<Animal>();
            List<Animal> others = new List<Animal>();

            foreach (Animal a in animals)
            {
                if(a.diet == AnimalDiet.Carnivore && a.size == AnimalSize.Large)
                {
                    largeCarnivores.Add(a);
                }
                else if(a.diet == AnimalDiet.Carnivore && a.size == AnimalSize.Small)
                {
                    smallCarnivores.Add(a);
                }
                else
                {
                    others.Add(a);
                }
            }
            foreach(Animal lc in largeCarnivores)
            {
                Wagon w = new Wagon(false);
                w.TryAddAnimal(lc);
                Wagons.Add(w);
            }
        }
    }
}
