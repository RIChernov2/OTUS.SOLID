using LogicPart.Entities;
using LogicPart.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicPart
{
    public class NumberGuesser
    {
        private readonly ISettings _settings;
        private readonly IMessager _messager;
        private readonly IDigitGenerator _generator;
        private readonly IDigitChecker _digitChecker;

        public NumberGuesser(ISettings settings, IMessager messager,
                                IDigitGenerator generator, IDigitChecker digitChecker)
        {
            _settings = settings;
            _messager = messager;
            _generator = generator;
            _generator.SetNewRangeLimits(settings.MinRangeValue, _settings.MaxRangeValue);
            _generator.GenerateNewValue();
            _digitChecker = digitChecker;
            _digitChecker.SetHiddenNumber(_generator.Value);
        }

        public void Start()
        {
            int attemptsCounter = _settings.MaxAttemptsCount;

            if ( !CheckWhetherSettingsCorrect(attemptsCounter) ) return;


            AttemptsCounter counter = new AttemptsCounter();
            counter.SetAttemptsCount(attemptsCounter);

            Controller controller = new Controller(counter, _digitChecker);

            controller.OnMatch += Controller_OnMatch;
            controller.OnLower += Controller_OnLower;
            controller.OnHigher += Controller_OnHigher;
            controller.OnNoAttemptsLeft += Controller_OnNoAttemptsLeft;

            string input;
            int attemptValue;
            _operationFinishFlag = false;

            for ( ; ; )
            {
                
                _messager.PrintRangeValue(_settings.MinRangeValue, _settings.MaxRangeValue);
                _messager.PrintNumberRequest(attemptsCounter);

                input = Console.ReadLine();

                // проверяем, что можно запарсить
                if ( !Helper.TryParse(input) )
                {
                    _messager.PrintWrongInputValue();
                    continue;
                }

                attemptValue = int.Parse(input);
                controller.DoIteration(attemptValue);

                if ( _operationFinishFlag ) break;
                attemptsCounter--;
            }
        }

        private bool _operationFinishFlag;

        private void Controller_OnMatch(int currentAttempt)
        {
            _messager.PrintMatchMessage(currentAttempt);
            _operationFinishFlag = true;
        }

        private void Controller_OnLower(int currentAttempt)
        {
            _messager.PrintLowerMessage(currentAttempt);
        }

        private void Controller_OnHigher(int currentAttempt)
        {
            _messager.PrintHigherMessage(currentAttempt);
        }

        private void Controller_OnNoAttemptsLeft()
        {
            // костыль конечно, но что поделать ))
            if ( _operationFinishFlag == true ) return;


            _messager.PrintNoAttemptsLeftMessage(_generator.Value);
            _operationFinishFlag = true;
        }

        private bool CheckWhetherSettingsCorrect(int attemptsCounter)
        {
            if ( attemptsCounter < 1 )
            {
                Console.WriteLine($"Введено неверное значение попыток ({attemptsCounter})\n." +
                                    "Количество попыток должно быть больше 0. Программа завершает работу");
                return false;
            }

            return true;
        }
    }
}
