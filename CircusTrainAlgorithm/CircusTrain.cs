using System;
using System.Collections.Generic;
using System.Text;

namespace CircusTrainAlgorithm
{
    public class CircusTrain
    {
        public List<Wagon> Wagons { get; set; } = new List<Wagon>();
        private const int MaxSpecialWagons = 4;
    }
}
