using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicPart.Entities
{
    public class DigitGeneratorLiskov : DigitGenerator
    {
        public DigitGeneratorLiskov(int minValue = 0, int maxValue = 500)
            : base(minValue, maxValue)
        {
            _random = new Random();
        }
        private Random _random;
        public int GenerateRandomValue(int minValue,int maxValue)
            => _random.Next(minValue, maxValue + 1);
  
        public override void GenerateNewValue()
        {
            Value = GenerateRandomValue(_minValue, _maxValue);
        }
    }
}
