using LogicPart.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicPart.Entities
{
    public class AttemptsCounter: IAttemptsCounter
    {
        private int _attemptsLeft;

        public void SetAttemptsCount(int currentAttempts)
            => _attemptsLeft = currentAttempts;

        public void AttemptsDecrease()
        {
            _attemptsLeft -= 1;
            if ( _attemptsLeft < 1 ) OnNoAttemptsLeft();
        }

        public event Action OnNoAttemptsLeft;
    }   
}

