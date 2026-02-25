using CircusTrainAlgorithm.Domain;

namespace CircusTrainAlgorithm.Business
{
    public class CircusTrainService
    {
        private CircusTrain _train;
        private const int MaxSpecialWagons = 4;

        public CircusTrainService(CircusTrain train)
        {
            _train = train;
        }

        public void ListAllWagons()
        {
            for (int i = 0; i < _train.Wagons.Count; i++)
            {
                string isWagonSpecial = _train.Wagons[i].IsSpecial ? "Special" : "Normal";
                Message.Success($"--- Wagon #{i + 1} ({isWagonSpecial}) ---");
                Message.Success("Animals:");
                if (_train.Wagons[i].Animals.Count == 0)
                    Message.Error("Empty");


                for (int j = 0; j < _train.Wagons[i].Animals.Count; j++)
                {
                    Message.Success($"{j + 1}) {_train.Wagons[i].Animals[j].Diet} {_train.Wagons[i].Animals[j].Size}");
                }
            }
        }

        public void OptimizeDistribution(List<Animal> animals)
        {
            _train.Wagons.Clear();

            List<Animal> largeCarnivores = new List<Animal>();
            List<Animal> mediumAndSmallCarnivores = new List<Animal>();
            List<Animal> others = new List<Animal>();

            foreach (Animal a in animals)
            {
                if (a.Diet == AnimalDiet.Carnivore && a.Size == AnimalSize.Large)
                {
                    largeCarnivores.Add(a);
                }
                else if (a.Diet == AnimalDiet.Carnivore && a.Size != AnimalSize.Large)
                {
                    mediumAndSmallCarnivores.Add(a);
                }
                else
                {
                    others.Add(a);
                }
            }
            foreach (Animal lc in largeCarnivores)
            {
                Wagon w = new Wagon(false);
                WagonService ws = new WagonService(w);
                ws.TryAddAnimal(lc);
                _train.Wagons.Add(w);
            }
            int specialWagonsUsed = 0;

            while (mediumAndSmallCarnivores.Count >= 2 && specialWagonsUsed < MaxSpecialWagons)
            {
                Wagon w = new Wagon(true);
                WagonService ws = new WagonService(w);
                ws.TryAddAnimal(mediumAndSmallCarnivores[0]);
                mediumAndSmallCarnivores.RemoveAt(0);
                ws.TryAddAnimal(mediumAndSmallCarnivores[0]);
                mediumAndSmallCarnivores.RemoveAt(0);
                _train.Wagons.Add(w);
                specialWagonsUsed++;
            }
            while (mediumAndSmallCarnivores.Count > 0 && specialWagonsUsed < MaxSpecialWagons)
            {
                Wagon w = new Wagon(true);
                WagonService ws = new WagonService(w);
                ws.TryAddAnimal(mediumAndSmallCarnivores[0]);
                mediumAndSmallCarnivores.RemoveAt(0);
                Animal companion = null;
                foreach (Animal o in others)
                {
                    if (o.Size != AnimalSize.Large)
                    {
                        companion = o;
                        break;
                    }
                }
                if (companion != null)
                {
                    _train.Wagons.Add(w);
                    specialWagonsUsed++;
                }
            }

            List<Animal> remaining = new List<Animal>();
            remaining.AddRange(mediumAndSmallCarnivores);
            remaining.AddRange(others);

            //remaining.Sort((x, y) => y.Size.CompareTo(x.Size));

            for (int i = 0; i < remaining.Count - 1; i++)
            {
                for (int j = i + 1; j < remaining.Count; j++)
                {
                    if (remaining[i].Size < remaining[j].Size)
                    {
                        Animal temp = remaining[i];
                        remaining[i] = remaining[j];
                        remaining[j] = temp;
                    }
                }
            }

            foreach (var animal in remaining)
            {
                bool placed = false;
                foreach (Wagon wagon in _train.Wagons)
                {
                    if (wagon.IsSpecial)
                        continue;
                    WagonService ws = new WagonService(wagon);
                    if (ws.CanAdd(animal))
                    {
                        ws.TryAddAnimal(animal);
                        placed = true;
                        break;
                    }
                }
                if (!placed)
                {
                    Wagon newWagon = new Wagon(false);
                    WagonService ws = new WagonService(newWagon);
                    ws.TryAddAnimal(animal);
                    _train.Wagons.Add(newWagon);
                }
            }
        }
    }
}
