using System;

namespace MatrixCalculate
{
    public class Rules
    {
        public static void ShowRules()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("# Ограничения:");
            Console.ResetColor();
            Console.WriteLine("  Для рандомного ввода матрицы коэффициенты берутся целые");
            Console.WriteLine("  Максимальное количество строк и столбцов - 10");
            Console.WriteLine("  Коэффициенты матрицы в диапазоне [-1000, 1000]");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("# Правила");
            Console.ResetColor();
            Console.WriteLine("  След матрицы считается только для квадратных");
            Console.WriteLine("  В файл достаточно написать только матрицу. Без размерности");
            Console.WriteLine("  Чтение матрицы происходит из файлов формата txt");
            Console.WriteLine("  Для операций с двумя матрицами необходимо использовать два разных файла");
            Console.WriteLine("  СЛАУ решается только для квадратных матриц коэффициентов, так как через Крамера");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("* Назад в меню (Нажмите Enter)");
            Console.ResetColor();
            // Пока не нажат Enter меню не запустится.
            while (Console.ReadKey().Key != ConsoleKey.Enter)
            {
            }
        }
    }
}