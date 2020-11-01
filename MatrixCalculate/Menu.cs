using System;

namespace MatrixCalculate
{
    public class Menu
    {
        
        private static bool flagExit = true;
        private static int position = 1;
        public static bool FlagExit
        {
            get => flagExit;
            set => flagExit = value;
        }

        public static int Position
        {
            get => position;
            set => position = value;
        }

        public static void ShowMenu(int position, bool flag)
        {
            Position = position;
            Console.Clear();
            Console.WriteLine("Какое действие с матрицей вы хотите совершить?");
            Console.WriteLine($"{(position == 1 ? "*" : "")}  Посчитать след матрицы");
            Console.WriteLine($"{(position == 2 ? "*" : "")}  Транспонировать матрицу");
            Console.WriteLine($"{(position == 3 ? "*" : "")}  Посчитать сумму двух матриц");
            Console.WriteLine($"{(position == 4 ? "*" : "")}  Посчитать разность двух матриц");
            Console.WriteLine($"{(position == 5 ? "*" : "")}  Посчитать произведение двух матриц");
            Console.WriteLine($"{(position == 6 ? "*" : "")}  Умножить матрицу на число");
            Console.WriteLine($"{(position == 7 ? "*" : "")}  Посчитать определитель матрицы");
            Console.WriteLine($"{(position == 8 ? "*" : "")}  Выйти");
            if (flag)
            {
                Processing(position);
            }
            
        }
        
        
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
                            position = 8;
                        }
                        break;
                     case "DownArrow":
                        position += 1;
                        if (position == 9)
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

        public static void Processing(int position)
        {
            switch (position)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    break;
                case 7:
                    break;
                case 8:
                    FlagExit = false;
                    break;
            }
            
        }

        
    }
}