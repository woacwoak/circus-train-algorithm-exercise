public enum AnimalDiet { Carnivore, Herbivore}

public enum AnimalSize
{
    Small = 1,
    Medium = 3,
    Large = 5
}

namespace CircusTrainAlgorithm.Domain
{
    public class Animal
    {
        public AnimalDiet Diet { get; set; }

        public AnimalSize Size { get; set; }

        public int SizePoints { get { return (int)Size; } }

        public Animal(AnimalDiet diet, AnimalSize size)
        {
            this.Diet = diet;
            this.Size = size;
        }
    }
}
