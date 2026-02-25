using CircusTrainAlgorithm.Domain;

namespace CircusTrainAlgorithm.Business
{
    public class WagonService
    {
        private const int _maxCapacity = 10;
        private Wagon _wagon;
        public WagonService(Wagon wagon)
        {
            _wagon = wagon;
        }
        public int CurrentPoints()
        {
            int total = 0;
            foreach (Animal Animal in _wagon.Animals)
            {
                total += Animal.SizePoints;
            }
            return total;
        }

        public bool CanAdd(Animal animal)
        {
            if (CurrentPoints() + animal.SizePoints > _maxCapacity)
                return false;

            if (_wagon.IsSpecial)
            {
                if (_wagon.Animals.Count >= 2) return false;
                if (animal.Size == AnimalSize.Large) return false;
                return true;
            }
            if (animal.Diet == AnimalDiet.Carnivore)
            {
                foreach (Animal existing in _wagon.Animals)
                {
                    if (existing.SizePoints <= animal.SizePoints)
                    {
                        return false;
                    }
                }
            }
            foreach (Animal existing in _wagon.Animals)
            {
                if (existing.Diet == AnimalDiet.Carnivore)
                {
                    if (existing.SizePoints >= animal.SizePoints)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public void TryAddAnimal(Animal animal)
        {
            if (!CanAdd(animal))
                Message.Error("Unsafe move. You can't add the animal due to the violation of the rules!");
            else
                _wagon.Animals.Add(animal);
        }
    }
}
