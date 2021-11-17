using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicPart.Interfaces
{
    public interface IDigitChecker
    {
        public void SetHiddenNumber(int hiddenNumber);
        public int ChechValue(int inputValue);
    }
}
