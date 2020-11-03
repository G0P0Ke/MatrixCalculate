using System;

namespace MatrixCalculate
{
    public class Menu
    {
        // поле выхода из меню.
        private static bool flagExit = true;

        // поле номера текущего метода.
        private static int position = 1;

        // Свойство класса.
        public static bool FlagExit
        {
            get => flagExit;
            set => flagExit = value;
        }
        
        
        // Свойство класса.
        public static int Position
        {
            get => position;
            set => position = value;
        }

        /// <summary>
        /// Меню.
        /// </summary>
        /// <param name="position"> Номер метода. </param>
        /// <param name="flag"> Флаг, показывающий необходимость завершения программы. </param>
        public static void ShowMenu(int position, bool flag)
        {
            Position = position;
            Console.Clear();
            Console.WriteLine("Какое действие с матрицей вы хотите совершить?");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{(position == 1 ? "*" : "")}  Посчитать след матрицы");
            Console.WriteLine($"{(position == 2 ? "*" : "")}  Транспонировать матрицу");
            Console.WriteLine($"{(position == 3 ? "*" : "")}  Посчитать сумму двух матриц");
            Console.WriteLine($"{(position == 4 ? "*" : "")}  Посчитать разность двух матриц");
            Console.WriteLine($"{(position == 5 ? "*" : "")}  Посчитать произведение двух матриц");
            Console.WriteLine($"{(position == 6 ? "*" : "")}  Умножить матрицу на число");
            Console.WriteLine($"{(position == 7 ? "*" : "")}  Посчитать определитель матрицы");
            Console.WriteLine($"{(position == 8 ? "*" : "")}  Решить СЛАУ");
            Console.WriteLine($"{(position == 9 ? "*" : "")}  Правила и ограничения");
            Console.WriteLine($"{(position == 10 ? "*" : "")}  Выйти");
            Console.ResetColor();
            if (flag)
            {
                ReadMatrix(position);
            }
        }

        /// <summary>
        /// Управление стрелками в меню.
        /// </summary>
        public static void ControlByArrows()
        {
            int position = Position;
            ConsoleKeyInfo key;
            key = Console.ReadKey();

            while (key.Key.ToString() != "Enter")
            {
                string choice = key.Key.ToString();
                switch (choice)
                {
                    case "UpArrow":
                        position -= 1;
                        if (position == 0)
                        {
                            position = 10;
                        }

                        break;
                    case "DownArrow":
                        position += 1;
                        if (position == 11)
                        {
                            position = 1;
                        }

                        break;
                }

                ShowMenu(position, false);
                key = Console.ReadKey();
            }

            ShowMenu(position, true);
        }

        /// <summary>
        /// Выбор формата ввода матрицы. 
        /// </summary>
        /// <param name="position"> Номер метода. </param>
        static void ReadMatrix(int position)
        {
            if (position == 10)
            {
                FlagExit = false;
            }
            else if (position == 9)
            {
                Console.Clear();
                Rules.ShowRules();
            }
            else
            {
                Console.WriteLine("Как вы хотите задать матрицу:");
                Console.WriteLine("Из файла \"F\"; Рандомно \"R\"; С консоли \"C\"");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "F":
                        ProcessingF(position);
                        break;
                    case "C":
                        Processing(position);
                        break;
                    case "R":
                        ProcessingR(position);
                        break;
                    default:
                        Console.WriteLine("Вы ошиблись с вводом. Попробуйте еще раз");
                        ReadMatrix(position);
                        break;
                }
            }
        }

        /// <summary>
        /// Обработка методов для матриц, созданных из рандомных коэффициентов.
        /// </summary>
        /// <param name="position"> Номер метода. </param>
        public static void ProcessingR(int position)
        {
            switch (position)
            {
                case 6:
                case 7:
                case 8:
                case 1:
                case 2:
                    Matrix.MatrixRandom(position, 1);
                    break;
                case 3:
                case 4:
                case 5:
                    Matrix.MatrixRandom(position, 2);
                    break;
            }
        }

        /// <summary>
        /// Обработка методов для матриц из консоли.
        /// </summary>
        /// <param name="position"> Номер метода. </param>
        public static void Processing(int position)
        {
            switch (position)
            {
                case 6:
                case 7:
                case 8:
                case 1:
                case 2:
                    Matrix.OneMatrixProcessing(position);
                    break;
                case 3:
                case 4:
                case 5:
                    Matrix.TwoMatrixProcessing(position);
                    break;
                
            }
        }

        /// <summary>
        /// Обработка методов для матриц из файлов.
        /// </summary>
        /// <param name="position"> Номер метода. </param>
        public static void ProcessingF(int position)
        {
            switch (position)
            {
                case 6:
                case 7:
                case 8:
                case 1:
                case 2:
                    Matrix.MatrixFromFile(position, 1);
                    break;
                case 3:
                case 4:
                case 5:
                    Matrix.TwoMatrixFromFile(position);
                    break;
            }
        }
    }
}