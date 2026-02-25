namespace CircusTrainAlgorithm.Domain
{
    public class Wagon
    {
        private bool isSpecial;
        public bool IsSpecial { get { return isSpecial; } }

        public List<Animal> Animals { get; private set; }

        public Wagon(bool isSpecial)
        {
            this.isSpecial = isSpecial;
            this.Animals = new List<Animal>();
        }
        
    }
}
