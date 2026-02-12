using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Runtime.ExceptionServices;
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
            List<Animal> mediumAndSmallCarnivores = new List<Animal>();
            List<Animal> others = new List<Animal>();

            foreach (Animal a in animals)
            {
                if(a.diet == AnimalDiet.Carnivore && a.size == AnimalSize.Large)
                {
                    largeCarnivores.Add(a);
                }
                else if(a.diet == AnimalDiet.Carnivore && a.size != AnimalSize.Large)
                {
                    mediumAndSmallCarnivores.Add(a);
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
            int specialWagonsUsed = 0;

            while(mediumAndSmallCarnivores.Count >= 2 && specialWagonsUsed < MaxSpecialWagons)
            {
                Wagon w = new Wagon(true);
                w.TryAddAnimal(mediumAndSmallCarnivores[0]);
                mediumAndSmallCarnivores.RemoveAt(0);
                w.TryAddAnimal(mediumAndSmallCarnivores[0]);
                mediumAndSmallCarnivores.RemoveAt(0);
                Wagons.Add(w);
                specialWagonsUsed++;
            }
            while(mediumAndSmallCarnivores.Count > 0 && specialWagonsUsed < MaxSpecialWagons)
            {
                Wagon w = new Wagon(true);
                w.TryAddAnimal(mediumAndSmallCarnivores[0]);
                mediumAndSmallCarnivores.RemoveAt(0);
                Animal companion = null;
                foreach(Animal o in others)
                {
                    if(o.size != AnimalSize.Large)
                    {
                        companion = o;
                        break;
                    }
                }
                if(companion != null)
                {
                    Wagons.Add(w);
                    specialWagonsUsed++;
                }
            }

            List<Animal> remaining = new List<Animal>();
            remaining.AddRange(mediumAndSmallCarnivores);
            remaining.AddRange(others);
            remaining.Sort((x, y) => y.size.CompareTo(x.size));

            foreach (var animal in remaining)
            {
                bool placed = false;
                foreach(Wagon wagon in Wagons)
                {
                    if (wagon.isSpecial)
                        continue;
                    if (wagon.CanAdd(animal))
                    {
                        wagon.TryAddAnimal(animal);
                        placed = true;
                        break;
                    }
                }
                if(!placed)
                {
                    Wagon newWagon = new Wagon(false);
                    newWagon.TryAddAnimal(animal);
                    Wagons.Add(newWagon);
                }
            }
        }
    }
}
