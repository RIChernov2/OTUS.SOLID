using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicPart.Interfaces
{
    public interface IDigitGenerator
    {
        public int Value { get;}
        public void GenerateNewValue();
        public void SetNewRangeLimits(int newMinValue, int newMaxValue);
    }
}
