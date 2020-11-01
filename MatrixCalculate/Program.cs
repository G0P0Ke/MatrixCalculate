using System;

namespace MatrixCalculate
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstPosition = 1;
            bool flag = true;
            while (flag == true)
            {
                Menu.ShowMenu(firstPosition, false);
                Menu.ControlByArrows();
                flag = Menu.FlagExit;
                firstPosition = Menu.Position;
            } 
        }
    }
}