using System;
using LogicPart.Interfaces;

namespace LogicPart.Entities
{
    public class Settings : ISettings
    {
        public Settings(int minRangeValue, int maxRangeValue, int maxAttemptsCount)
        {
            MaxAttemptsCount = maxAttemptsCount;
            MinRangeValue = minRangeValue;
            MaxRangeValue = maxRangeValue;
        }

        public int MaxAttemptsCount { get; set; }
        public int MinRangeValue { get; set; }
        public int MaxRangeValue { get; set; }
    }
}
