using LogicPart.Interfaces;
using System;


namespace LogicPart.Entities
{
    public class DigitGenerator: IDigitGenerator
    {
        protected int _minValue;
        protected int _maxValue;

        public DigitGenerator(int minValue = 0, int maxValue = 1000)
        {
            _minValue = minValue;
            _maxValue = maxValue;
            GenerateNewValue();
        }

        public int Value { get; protected set; }
        public virtual void GenerateNewValue()
        {
            Random random = new Random();
            Value = random.Next(_minValue, _maxValue + 1);
        }
        public void SetNewRangeLimits(int newMinValue, int newMaxValue)
        {
            _minValue = newMinValue;
            _maxValue = newMaxValue;
        }

    }
}
