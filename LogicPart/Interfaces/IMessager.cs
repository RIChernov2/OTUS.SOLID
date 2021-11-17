using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicPart.Interfaces
{
    public interface IMessager
    {
        public void PrintRangeValue(int minRangValue, int maxRangeValue);
        public void PrintWrongInputValue();
        public void PrintNumberRequest(int attemptsLeft);
        public void PrintMatchMessage(int currentAttempt);
        public void PrintHigherMessage(int currentAttempt);
        public void PrintLowerMessage(int currentAttempt);
        public void PrintOneMoreAttemptMessage(int attemptsLeft);
        public void PrintNoAttemptsLeftMessage(int answerValue);
    }
}
