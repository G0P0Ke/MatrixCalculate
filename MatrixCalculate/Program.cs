using System;

namespace MatrixCalculate
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstPosition = 1;
            bool flag = true;
            Greeting();
            while (flag == true)
            {
                Menu.ShowMenu(firstPosition, false);
                Menu.ControlByArrows();
                flag = Menu.FlagExit;
                firstPosition = Menu.Position;
            }
        }

        /// <summary>
        /// Приветственный метод.
        /// </summary>
        static void Greeting()
        {
            // Меняю цвет текста в консоли.
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Добро пожаловать в калькулятор для матриц");
            Console.WriteLine(
                "Правила и ограничения на ввод (в процессе работы Вы сможете с ними ознакомиться еще раз):");
            // Стандартный цвет консоли.
            Console.ResetColor();
            Rules.ShowRules();
            Console.WriteLine("Чтобы начать, нажмите \"Enter\"");
            // Пока не нажат Enter меню не запустится.
            while (Console.ReadKey().Key != ConsoleKey.Enter)
            {
            }
        }
    }
}