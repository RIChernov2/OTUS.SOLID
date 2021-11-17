using LogicPart;
using LogicPart.Entities;
using System;

namespace UserPart
{
    class Program
    {
        // Пояснение по использованию солид см. в ReadMe.txt
        static void Main(string[] args)
        {
            Settings settings = null;
            do
            {
                Console.WriteLine("Введите через запятую: \n - минимальное значение числа" +
                                "\n - максимальное значение числа\n - максимальное количество попыток\n" +
                                $"Например \"10, 25, 5\". Или нажмите Enter, чтобы принять значения по умолчанию {Helper.DefaultValues}.\n");
                string input = Console.ReadLine();


                settings = Helper.ParseSettingsOrNull(input);
                if ( settings == null ) Console.WriteLine("\n >>> Введены некорректные значения. Повторите ввод.\n ");
            }
            while ( settings == null );

            Messager messager = new Messager();

            NumberGuesser guesser = new NumberGuesser(settings, messager, new DigitGenerator(), new DigitChecker());
            guesser.Start();
            Console.WriteLine("Нажмите Enter, чтобы завершить работу программы.");
            Console.ReadLine();
        }

    }
}
