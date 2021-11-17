using LogicPart.Interfaces;
using System;

namespace LogicPart.Entities
{
    public class DigitChecker: IDigitChecker
    {
        protected int _hiddenNumber;

        public int ChechValue(int inputValue)
        {
            return inputValue.CompareTo(_hiddenNumber);
        }

        public void SetHiddenNumber(int hiddenNumber)
        {
            _hiddenNumber = hiddenNumber;
        }
    }
}
