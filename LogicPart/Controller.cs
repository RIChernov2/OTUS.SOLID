using LogicPart.Interfaces;
using System;

namespace LogicPart
{
    public class Controller
    {
        private IAttemptsCounter _counter;
        private IDigitChecker _checker;


        public event Action<int> OnMatch;
        public event Action<int> OnLower;
        public event Action<int> OnHigher;
        public event Action OnNoAttemptsLeft;

        public Controller(IAttemptsCounter counter, IDigitChecker checker)
        {
            _counter = counter;
            _checker = checker;
            _counter.OnNoAttemptsLeft += () => OnNoAttemptsLeft();
        }
  
        public void DoIteration(int currentAttempt)
        {
            int result = _checker.ChechValue(currentAttempt);


            if ( result == 0 ) OnMatch(currentAttempt);
            else if ( result == - 1 ) OnLower(currentAttempt);
            else OnHigher(currentAttempt);

            _counter.AttemptsDecrease();
        }
    }
}
