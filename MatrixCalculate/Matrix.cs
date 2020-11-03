using System;
using System.IO;

namespace MatrixCalculate
{
    public class Matrix
    {
        /// <summary>
        /// Метод ввода размеров матрицы. 
        /// </summary>
        /// <returns> Массив с размерами матрицы. </returns>
        static int[] MatrixSizes()
        {
            Console.WriteLine("Введите размеры матрицы (кол-во строк, столбцов) через пробел.");
            // В sizes[2] лежит флаг, оповещающий о корректности введенных размеров.
            int[] sizes = new int[3];
            string[] input = Console.ReadLine().Trim(' ').Split(" ");
            if ((input.Length == 2) && int.TryParse(input[0], out int lines) && int.TryParse(input[1], out int columns))
            {
                if ((lines <= 10) && (lines >= 0) && (columns <= 10) && (columns >= 0))
                {
                    sizes[0] = lines;
                    sizes[1] = columns;
                    sizes[2] = 1;
                }
                else
                {
                    Console.WriteLine("Одна из введенных размерностей не удовлетворяет ограничениям");
                    sizes[2] = 0;
                }
            }
            else
            {
                Console.WriteLine("Ошибка ввода. Один из введенных элементов невозможно преобразовать в число");
                sizes[2] = 0;
            }

            return sizes;
        }

        /// <summary>
        /// Метод ввода одной матрицы.
        /// </summary>
        /// <param name="line"> Количество строк в матрице. </param>
        /// <param name="column"> Количетсво столбцов в матрице. </param>
        /// <returns> Введенная матрица. </returns>
        static double[,] MatrixInput(int line, int column)
        {
            Console.WriteLine("Введите матрицу (числа вводятся через пробел):");
            double[,] matrix = new double[line, column];
            for (int i = 0; i < line; i++)
            {
                string[] matrixArr;
                string input = Console.ReadLine();
                // Убираю все начальные и конечные пробелы из введенной строки.
                input = input.Trim(' ');
                matrixArr = input.Split(" ");
                if (matrixArr.Length >= column)
                {
                    for (int j = 0; j < column; j++)
                    {
                        if (double.TryParse(matrixArr[j], out double result))
                        {
                            matrix[i, j] = result;
                        }
                        else
                        {
                            Console.WriteLine(
                                "Один из введенных элементов невозможно преобразовать в число. Теперь он равен 0");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Ошибка. В строке меньше элементов, чем стобцов в матрице");
                    Console.WriteLine("Продолжайте ввод матрицы, однако данная строка будет нулевой");
                }
            }

            return matrix;
        }


        /// <summary>
        /// Задание матрицы и использование методов на ней.
        /// </summary>
        /// <param name="position"> Номер метода. </param>
        public static void OneMatrixProcessing(int position)
        {
            int[] sizes = MatrixSizes();
            if (sizes[2] == 0)
            {
                Menu.Processing(position);
            }
            else
            {
                double[,] matrix = MatrixInput(sizes[0], sizes[1]);
                Console.WriteLine("Введенная матрица: ");
                for (int i = 0; i < sizes[0]; i++)
                {
                    for (int j = 0; j < sizes[1]; j++)
                    {
                        Console.Write(matrix[i, j] + "\t");
                    }

                    Console.Write(Environment.NewLine);
                }

                Choice(position, matrix, sizes[0], sizes[1]);
            }
        }

        public static double[,] MatrixIn(int line, int column, int count)
        {
            double[,] matrix = MatrixInput(line, column);
            Console.WriteLine($"{count}-ая введенная матрица: ");
            for (int i = 0; i < line; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }

                Console.Write(Environment.NewLine);
            }

            return matrix;
        }

        /// <summary>
        /// Задание двух матриц и использование методов на них.
        /// </summary>
        /// <param name="position"> Номер метода. </param>
        public static void TwoMatrixProcessing(int position)
        {
            int[] sizes = MatrixSizes();
            if (sizes[2] == 0)
            {
                Menu.Processing(position);
            }
            else
            {
                double[,] matrix = MatrixIn(sizes[0], sizes[1], 1);
                int[] sizes1 = MatrixSizes();
                if (sizes1[2] == 0)
                {
                    Menu.Processing(position);
                }
                else
                {
                    double[,] matrix2 = MatrixIn(sizes1[0], sizes1[1], 2);
                    Choice2(position, matrix, matrix2, sizes[0], sizes[1], sizes1[0], sizes1[1]);
                }
            }
        }

        /// <summary>
        /// Метод подсчета следа матрицы.
        /// </summary>
        /// <param name="arr"> Матрица. </param>
        /// <param name="lines"> Количество строк в матрице. </param>
        /// <param name="columns"> Количество столбцов в матрице. </param>
        public static void MatrixTrace(double[,] arr, int lines, int columns)
        {
            double trace = 0;
            if (lines != columns)
            {
                Console.WriteLine("След нельзя высчитать для прямоугольной матрицы");
            }
            else
            {
                for (int i = 0; i < lines; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        if (i == j)
                        {
                            trace += arr[i, j];
                        }
                    }
                }

                Console.WriteLine($"След матрицы: {trace}");
            }

            BackToMenu();
        }

        /// <summary>
        /// Метод транспонирования матрицы.
        /// </summary>
        /// <param name="arr"> Матрица. </param>
        /// <param name="lines"> Количество строк в матрице. </param>
        /// <param name="columns"> Количество столбцов в матрице. </param>
        static void MatrixTransposition(double[,] arr, int lines, int columns)
        {
            for (int i = 0; i < lines; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    double elem = arr[i, j];
                    arr[i, j] = arr[j, i];
                    arr[j, i] = elem;
                }
            }

            Console.WriteLine("Транспонированная матрица: ");
            for (int i = 0; i < lines; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(arr[i, j] + "\t");
                }

                Console.Write(Environment.NewLine);
            }

            BackToMenu();
        }

        static void MatrixMultiNum(double[,] arr, int lines, int columns)
        {
            Console.WriteLine("Введите число в диапазоне [-1000, 1000]");
            string input = Console.ReadLine();
            if (double.TryParse(input, out double number) && number >= -1000 && number <= 1000)
            {
                for (int i = 0; i < lines; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        arr[i, j] = number * arr[i, j];
                    }
                }

                MatrixOut(arr);
                BackToMenu();
            }
            else
            {
                Console.WriteLine("Ошибка ввода. Введенный элемент не число");
                MatrixMultiNum(arr, lines, columns);
            }
        }

        /// <summary>
        /// Обработчик выбранного метода для одной матрицы.
        /// </summary>
        /// <param name="position"> Номер дейстивия с матрицей в меню. </param>
        /// <param name="arr"> Матрица. </param>
        /// <param name="lines"> Количество строк в матрице. </param>
        /// <param name="columns">Количество столбцов в матрице. </param>
        static void Choice(int position, double[,] arr, int lines, int columns)
        {
            switch (position)
            {
                case 1:
                    try
                    {
                        MatrixTrace(arr, lines, columns);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Произошла Ошибка" + e.Message);
                    }
                    break;
                case 2:
                    try
                    {
                        MatrixTransposition(arr, lines, columns);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Произошла Ошибка" + e.Message);
                    }
                    break;
                case 6:
                    try
                    {
                        MatrixMultiNum(arr, lines, columns);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Произошла Ошибка" + e.Message);
                    }
                    break;
                case 7:
                    try
                    {
                        Determinant(arr, lines, columns);
                        BackToMenu();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Произошла Ошибка" + e.Message);
                    }
                    break;
                case 8:
                    try
                    {
                        Kramer(arr, lines, columns);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Произошла Ошибка" + e.Message);
                    }
                    break;
            }
        }

        /// <summary>
        /// Метод выбора операции над двумя матрицами.
        /// </summary>
        /// <param name="position"> Номер метода. </param>
        /// <param name="arr1"> Первая матрица. </param>
        /// <param name="arr2"> Вторая матрица. </param>
        /// <param name="line1"> Кол-во строк в 1-ой матрице. </param>
        /// <param name="column1"> Кол-во столбцов во 2-ой матрице. </param>
        /// <param name="line2"> Кол-во строк в 1-ой матрице. </param>
        /// <param name="column2"> Кол-во столбцов во 2-ой матрице. </param>
        static void Choice2(int position, double[,] arr1, double[,] arr2, int line1, int column1, int line2,
            int column2)
        {
            switch (position)
            {
                case 3:
                    try
                    {
                        MatrixSum(arr1, arr2, line1, column1, line2, column2);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Произошла Ошибка" + e.Message);
                    }

                    break;
                case 4:
                    try
                    {
                        MatrixSub(arr1, arr2, line1, column1, line2, column2);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Произошла Ошибка" + e.Message);
                    }

                    break;
                case 5:
                    try
                    {
                        MatrixComposition(arr1, arr2, line1, column1, line2, column2);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Произошла Ошибка" + e.Message);
                    }

                    break;
            }
        }

        /// <summary>
        /// Чтение файла.
        /// </summary>
        /// <returns> Строки файла. </returns>
        static string[] ReadFromFile()
        {
            string[] file = {"0"};
            Console.WriteLine("Введите путь к файлу");
            string startPath = Directory.GetCurrentDirectory();
            string Filepath = Console.ReadLine();
            // На случай, если пользователь ввел только имя файла, в надежде найти его в текущей директории.
            string NewPath = Path.Combine(startPath, Filepath);
            try
            {
                if (File.Exists(NewPath))
                {
                    file = File.ReadAllLines(NewPath);
                }
                else if (File.Exists(Filepath))
                {
                    file = File.ReadAllLines(Filepath);
                }
                else
                {
                    Console.WriteLine("Файла по заданному пути найти не удалось");
                    file[0] = "0";
                }
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine("Недостаточно прав для доступа к директории: \n" + e.Message);
                file[0] = "0";
            }

            return file;
        }


        /// <summary>
        /// Вызов методов для матрицы из файла.
        /// </summary>
        /// <param name="position"> Номер метода. </param>
        public static double[,] MatrixFromFile(int position, int count)
        {
            // Нужна лишь для того, чтобы метод возвращал хоть что-нибудь в случае ошибки.
            double[,] fakeMatrix = {{1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}};
            // Читаем файл и получаем матрицу.
            string[] file = ReadFromFile();
            if (file.Length == 0)
            {
                Console.WriteLine("Файл пустой");
            }
            else if (file[0] == "0")
            {
                Console.WriteLine("Произошла ошибка при чтении файла");
            }
            else
            {
                // Проверка на корректность данных матрицы.
                if (CorrectMatrix(file))
                {
                    double[,] matrix = ReadMatrix(file);
                    int lines = matrix.GetLength(0);
                    int columns = matrix.Length / lines;
                    Console.WriteLine(columns);
                    Console.WriteLine(lines);
                    Console.WriteLine("Матрица в файле: ");
                    for (int i = 0; i < lines; i++)
                    {
                        for (int j = 0; j < columns; j++)
                        {
                            Console.Write(matrix[i, j] + "\t");
                        }

                        Console.Write(Environment.NewLine);
                    }

                    if (columns <= 10 && lines <= 10)
                    {
                        if (count == 1)
                        {
                            Choice(position, matrix, lines, columns);
                        }
                        else
                        {
                            return matrix;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Введенные размерности не удовлетворяют ограничениям");
                    }
                }
                else
                {
                    Console.WriteLine("Матрица в файле имеет некорректный вид");
                    BackToMenu();
                }
            }

            return fakeMatrix;
        }


        /// <summary>
        /// Проверка корректности коэффициентов и размеров матрицы.
        /// </summary>
        /// <param name="file"> Строки матрицы. </param>
        /// <returns> True - корректно, False - нет</returns>
        static bool CorrectMatrix(string[] file)
        {
            bool flag = true;
            int lines = 0, columns = 0;
            for (int i = 0; i < file.Length; i++)
            {
                lines += 1;
                int k = 0;
                string[] input = file[i].Trim(' ').Split(" ");
                for (int j = 0; j < input.Length; j++)
                {
                    if (i == 0)
                    {
                        columns += 1;
                    }

                    k += 1;
                    if (!double.TryParse(input[j].ToString(), out double result))
                    {
                        flag = false;
                    }
                }

                if (k != columns)
                {
                    Console.WriteLine("Ошибка в размерах матрицы");
                    flag = false;
                    break;
                }
            }

            return flag;
        }

        /// <summary>
        /// Создание матрицы на основе данных из файла.
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        static double[,] ReadMatrix(string[] file)
        {
            int lines = 0, columns = 0;
            // Рассчет размерности матрицы.
            for (int i = 0; i < file.Length; i++)
            {
                lines += 1;
                string[] input = file[i].Trim(' ').Split(" ");
                columns = input.Length;
            }

            double[,] matrix = new double[lines, columns];
            // Создание матрицы на основе данных из файла.
            for (int i = 0; i < file.Length; i++)
            {
                string[] input = file[i].Trim(' ').Split(" ");
                for (int j = 0; j < input.Length; j++)
                {
                    matrix[i, j] = Convert.ToDouble(input[j]);
                }
            }

            return matrix;
        }


        /// <summary>
        /// Сумма двух матриц.
        /// </summary>
        /// <param name="arr1"> Первая матрица. </param>
        /// <param name="arr2"> Вторая матрица. </param>
        /// <param name="line1"> Кол-во строк в 1-ой матрице. </param>
        /// <param name="column1"> Кол-во столбцов во 2-ой матрице. </param>
        /// <param name="line2"> Кол-во строк в 1-ой матрице. </param>
        /// <param name="column2"> Кол-во столбцов во 2-ой матрице. </param>
        static void MatrixSum(double[,] arr1, double[,] arr2, int line1, int column1, int line2, int column2)
        {
            if ((line1 == line2) && (column1 == column2))
            {
                double[,] matrix = new double[line1, column1];
                for (int i = 0; i < line1; i++)
                {
                    for (int j = 0; j < column1; j++)
                    {
                        matrix[i, j] = arr1[i, j] + arr2[i, j];
                    }
                }

                MatrixOut(matrix);
            }
            else
            {
                Console.WriteLine("Матрицы разных типов складывать нельзя");
            }

            BackToMenu();
        }

        /// <summary>
        /// Разность матриц.
        /// </summary>
        /// <param name="arr1"> Первая матрица. </param>
        /// <param name="arr2"> Вторая матрица. </param>
        /// <param name="line1"> Кол-во строк в 1-ой матрице. </param>
        /// <param name="column1"> Кол-во столбцов во 2-ой матрице. </param>
        /// <param name="line2"> Кол-во строк в 1-ой матрице. </param>
        /// <param name="column2"> Кол-во столбцов во 2-ой матрице. </param>
        static void MatrixSub(double[,] arr1, double[,] arr2, int line1, int column1, int line2, int column2)
        {
            if ((line1 == line2) && (column1 == column2))
            {
                double[,] matrix = new double[line1, column1];
                for (int i = 0; i < line1; i++)
                {
                    for (int j = 0; j < column1; j++)
                    {
                        matrix[i, j] = arr1[i, j] - arr2[i, j];
                    }
                }

                MatrixOut(matrix);
            }
            else
            {
                Console.WriteLine("Разность матриц разных типов нельзя высчитать");
            }

            BackToMenu();
        }


        /// <summary>
        /// Метод вызова метода для двух матриц из файлов.
        /// </summary>
        /// <param name="position"> Номер метода. </param>
        public static void TwoMatrixFromFile(int position)
        {
            double[,] arr1 = MatrixFromFile(position, 2);
            double[,] arr2 = MatrixFromFile(position, 2);
            int lines1 = arr1.GetLength(0);
            int columns1 = arr1.Length / lines1;
            int lines2 = arr2.GetLength(0);
            int columns2= arr2.Length / lines2;
            Choice2(position, arr1, arr2, lines1, columns1, lines2, columns2);
        }

        /// <summary>
        /// Умножение матриц.
        /// </summary>
        /// <param name="arr1"> Первая матрица. </param>
        /// <param name="arr2"> Вторая матрица. </param>
        /// <param name="line1"> Кол-во строк в 1-ой матрице. </param>
        /// <param name="column1"> Кол-во столбцов во 2-ой матрице. </param>
        /// <param name="line2"> Кол-во строк в 1-ой матрице. </param>
        /// <param name="column2"> Кол-во столбцов во 2-ой матрице. </param>
        static void MatrixComposition(double[,] arr1, double[,] arr2, int line1, int column1, int line2, int column2)
        {
            if (column1 == line2)
            {
                double[,] matrix = new double[line1, column2];
                for (int i = 0; i < line1; i++)
                {
                    for (int j = 0; j < column2; j++)
                    {
                        matrix[i, j] = 0;
                        for (int k = 0; k < column1; k++)
                        {
                            matrix[i, j] += arr1[i, k] * arr2[k, j];
                        }
                    }
                }

                MatrixOut(matrix);
            }
            else
            {
                Console.WriteLine("Данные матрицы нельзя умножать");
            }

            BackToMenu();
        }

        /// <summary>
        /// Возвращение к меню.
        /// </summary>
        static void BackToMenu()
        {
            Console.WriteLine("* Назад в меню (Нажмите Enter)");
            // Пока не нажат Enter меню не запустится.
            while (Console.ReadKey().Key != ConsoleKey.Enter)
            {
            }
        }

        /// <summary>
        /// Обработка методов для рандомных матриц.
        /// </summary>
        /// <param name="position"> Номер метода. </param>
        /// <param name="count"> Кол-во матриц. </param>
        public static void MatrixRandom(int position, int count)
        {
            if (count == 1)
            {
                double[,] matrix = MatrixRanIn();
                int lines1 = matrix.GetLength(0);
                int columns1 = matrix.Length / lines1;
                if (columns1 == 11)
                {
                    Console.WriteLine("Произошла ошибка");
                }
                else
                {
                    Choice(position, matrix, lines1, columns1);
                }
            }
            else
            {
                double[,] arr1 = MatrixRanIn();
                double[,] arr2 = MatrixRanIn();
                int lines1 = arr1.GetLength(0);
                int columns1 = arr1.Length / lines1;
                int lines2 = arr2.GetLength(0);
                int columns2 = arr2.Length / lines2;
                Choice2(position, arr1, arr2, lines1, columns1, lines2, columns2);
            }
        }

        /// <summary>
        /// Метод для вывод матрицы.
        /// </summary>
        /// <param name="matrix"> Матрица, которую надо вывести. </param>
        static void MatrixOut(double[,] matrix)
        {
            int line1 = matrix.GetLength(0);
            int column1 = matrix.Length / line1;
            Console.WriteLine("Конечная матрица: ");
            for (int i = 0; i < line1; i++)
            {
                for (int j = 0; j < column1; j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }

                Console.Write(Environment.NewLine);
            }
        }

        /// <summary>
        /// Создание матрицы с рандомными коэффициентами.
        /// </summary>
        /// <returns> Созданная матрица. </returns>
        static double[,] MatrixRanIn()
        {
            int[] size = MatrixSizes();
            if (size[2] == 1)
            {
                int line = size[0], column = size[1];
                Random rand = new Random();
                double[,] matrix = new double[line, column];
                for (int i = 0; i < line; i++)
                {
                    for (int j = 0; j < column; j++)
                    {
                        matrix[i, j] = rand.Next(-1000, 1000);
                    }
                }

                Console.WriteLine("Cозданная матрица: ");
                for (int i = 0; i < line; i++)
                {
                    for (int j = 0; j < column; j++)
                    {
                        Console.Write(matrix[i, j] + "\t");
                    }

                    Console.Write(Environment.NewLine);
                }

                return matrix;
            }
            else
            {
                double[,] fakeMatrix = {{1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}};
                return fakeMatrix;
            }
        }

        /// <summary>
        /// Подсчет определителя матрицы. (На основе Гаусса)
        /// </summary>
        /// <param name="arr"> Матрица. </param>
        /// <param name="line"> Кол-во строк в матрице. </param>
        /// <param name="column"> Кол-во столбцов в матрице. </param>
        static double Determinant(double[,] arr, int line, int column)
        {
            const double EPS = 1E-9;
            double det = 1;
            if (line == column)
            {
                for (int i= 0; i < line; ++i)
                {
                    int d = i;
                    for (int j = i + 1; j < line; ++j)
                    {
                        if (Math.Abs(arr[j, i]) > Math.Abs(arr[d,i]))
                            d = j;
                    }
                    if (Math.Abs(arr[d,i]) < EPS) {
                        det = 0;
                        break;
                    }
                    // Меняем строки местами.
                    for (int l = 0; l < line; l++)
                    {
                        double elem = arr[i, l];
                        arr[i, l] = arr[d, l];
                        arr[d, l] = elem;
                    }
                    if (i != d)
                    {
                        det = -det;
                    }
                    det *= arr[i,i];
                    for (int j = i + 1; j < line; ++j)
                    {
                        arr[i,j ] /= arr[i, i];
                    }
                    for (int j = 0; j < line; ++j)
                    {
                        if (j != i && Math.Abs(arr[j, i]) > EPS)
                        {
                            for (int k = i + 1; k < line; ++k)
                            {
                                arr[j,k] -= arr[i,k] * arr[j,i];
                            }
                        }
                    }
                }
                Console.WriteLine($"Определитель матрицы: {det}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Определитель можно считать только для квадтратных матриц.");
                Console.ResetColor();
            }
            return det;
        }

        /// <summary>
        /// Создание матрицы без правого столбца.
        /// </summary>
        /// <param name="matrix"> СЛАУ. </param>
        /// <param name="line"> Кол-во строк в СЛАУ. </param>
        /// <param name="column"> Кол-во столбцов в СЛАУ. </param>
        /// <returns> Матрица без правого столбца СЛАУ. </returns> 
        static double[,] CreateA(double[,] matrix, int line, int column)
        {
            double[,] A = new double[line,column-1];
            for (int i = 0; i < line; i++)
            {
                for (int j = 0; j < column - 1; j++)
                {
                    A[i, j] = matrix[i, j];
                }
            }

            return A;
        }

        /// <summary>
        /// Создание матрицы из столбцов коэффициентов и правого столбца. 
        /// </summary>
        /// <param name="matrix"> Матрица СЛАУ. </param>
        /// <param name="line"> Кол-во строк в матрице. </param>
        /// <param name="column"> Кол-во столбцов в матрице. </param>
        /// <param name="numberColumn"> Номер столбца, который надо заменить на правыц столбец. </param>
        /// <returns> Новая матрица. </returns>
        /// <returns> Новая матрица. </returns>
        static double[,] CreateDeltaI(double[,] matrix, int line, int column, int numberColumn)
        {
            double[,] deltaI = new double[line, column-1];
            for (int i = 0; i < line; i++)
            {
                for (int j = 0; j < column - 1; j++)
                {
                    if (j == numberColumn)
                    {
                        deltaI[i, j] = matrix[i, column - 1];
                    }
                    else
                    {
                        deltaI[i, j] = matrix[i, j];
                    }
                }
            }

            return deltaI;
        }
        
        /// <summary>
        /// Решение СЛАУ методом Крамера.
        /// </summary>
        /// <param name="matrix"> Матрица коэффициентов и правого столбца. </param>
        /// <param name="line"> Кол-во строк в матрице. </param>
        /// <param name="column"> Кол-во столбцов в матрице. </param>
        static void Kramer(double[,] matrix, int line, int column)
        {
            if (line != column - 1)
            {
                Console.WriteLine("Введенная СЛАУ противоречит правилам");
            }
            else
            {
                bool flag = true;
                int decision = 1;
                double[,] A = CreateA(matrix, line, column);
                double detA = Determinant(A, line, column-1);
                double[] roots = new double[column - 1];
                if (detA != 0)
                {
                    for (int j = 0; j < column - 1; j++)
                    {
                        double[,] deltaI = CreateDeltaI(matrix, line, column, j);
                        Console.WriteLine($"Определитель матрицы Дельта{j}");
                        double detDeltaI = Determinant(deltaI, line, column - 1);
                        double x = detDeltaI / detA;
                        roots[j] = x;
                    }
                }
                else
                {
                    for (int j = 0; j < column - 1; j++)
                    {
                        double[,] deltaI = CreateDeltaI(matrix, line, column, j);
                        double detDeltaI = Determinant(deltaI, line, column - 1);
                        if (detDeltaI != 0)
                        {
                            flag = false;
                        }
                    }
                    if (flag)
                    {
                        decision = 0;
                    }
                }
                RootsOut(roots, flag, decision);
            }
            BackToMenu();
        }

        /// <summary>
        /// Вывод корней.
        /// </summary>
        /// <param name="roots"> Массив корней. </param>
        /// <param name="flag"> Флаг, показывающий, есть ли корни. </param>
        /// <param name="decision"> Флаг, показывающий не бесконенчо ли кол-во корней. </param>
        static void RootsOut(double[] roots, bool flag, int decision)
        {
            if (!flag)
            {
                Console.WriteLine("СЛАУ не имеет решений");
            }
            else if(decision == 0)
            {
                Console.WriteLine("СЛАУ имеет бесконечно много решений");
            }
            else
            {
                Console.WriteLine("Корни СЛАУ: ");
                for (int j = 0; j < roots.Length; j++)
                {
                    Console.WriteLine($"X{j}: {roots[j]}");
                }
            }
        }
    }
}