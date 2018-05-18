using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationalPratice_Task_10
{
    /*
      *  Шифровка текста с помощью решетки заключается в следующем
      *  1) Решетка, квадрат из клетчатой бумаги 10х10 клеток
      *  2) Некоторые клетки в котором вырезаны, совмещаются с целым квадратом 10х10 клеток
      *  3) Через прорези на бумагу наносятся первые буквы текста
      *  4) Затем решетка поворачивается на 90* и через прорези записываются следующие буквы.
      *  5) Это повторяется еще дважды
      *  6) Таким образом на бумагу наносятся 100 букв текста
      *  7) Решетку можно изобразить квадратной матрицей порядка 10 из нулей и едениц (нуль изображает прорезь)
      *  8) Доказать что матрица может ключом шифра , если из элементов a[i,j], a[10,-i+1j], a[i,100j+1], a[10-i+1], a[10-j+1] в точности один равен нулю
      *  Дано;
      *      Последовательность из 100 букв и матрица ключ
      *  а) Зашифровать данную последовательность
      * б) Расшифровать данную последовательность
      */
    class Program
    {
        /// <summary>
        /// Заполнение матрицы
        /// </summary>
        /// <param name="a">входной массив</param>
        /// <param name="size">Размер матрицы</param>
        static void FillMatrix(int[,] matrix, int size)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    matrix[i, j] = random.Next(2);
        }

        static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    Console.Write($" {matrix[i, j],2} ");
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static int[,] RotateMatrix(int[,] matrix)
        {
            int[,] rotated_matrix = new int[matrix.GetLength(1), matrix.GetLength(0)];

            for (int i = 0; i < matrix.GetLength(1); i++)
                for (int j = 0; j < matrix.GetLength(0); j++)
                    rotated_matrix[i, j] = matrix[matrix.GetLength(0) - j - 1, i];
            return rotated_matrix;
        }

        static void IncMatrix(int[,] defaut)
        {
            int[,] right = RotateMatrix(defaut);//Матрица справа
            int[,] down_right = RotateMatrix(right);//Матрица справа и снизу
            int[,] down = RotateMatrix(down_right);//Матрица снизу
            int[,] temp = new int[defaut.GetLength(1) * 2, defaut.GetLength(0) * 2];//Выходная матрица

            Console.WriteLine("Исходная матрицы");
            PrintMatrix(defaut);
            Console.WriteLine("Матрица справа");

            PrintMatrix(right);

            Console.WriteLine("Матрица справа и снизу");
            PrintMatrix(down_right);

            Console.WriteLine("Матрица снизу");
            PrintMatrix(down);
            /* Необходимо объеденить 4 матрицы в 1 выходную матрицу */

            #region FillMatrix

            try
            {
                for (int i = 0; i < defaut.GetLength(1); i++)
                    for (int j = 0; j < defaut.GetLength(0); j++)
                        temp[i, j] = defaut[i, j];
                PrintMatrix(temp);

                //Заполнение 2 матрицы справа
                for (int i = defaut.GetLength(1); i < defaut.GetLength(1) * 2; i++)
                {
                    for (int j = 0; j < right.GetLength(0); j++)
                    {
                        temp[i, j] = right[i - defaut.GetLength(1), j];
                    }
                }

                PrintMatrix(temp);
                //Заполнение 3 матрицы снизу
                for (int i = 0; i < defaut.GetLength(1); i++)
                    for (int j = defaut.GetLength(0); j < defaut.GetLength(0) + down.GetLength(0); j++)
                        temp[i, j] = down[i, j - defaut.GetLength(0)];
                PrintMatrix(temp);
                //Заполнение 4 матрицы справа снизу
                for (int i = defaut.GetLength(1); i < defaut.GetLength(1) + down_right.GetLength(1); i++)
                    for (int j = defaut.GetLength(0); j < defaut.GetLength(0) + down_right.GetLength(0); j++)
                        temp[i, j] = defaut[i - defaut.GetLength(1), j - defaut.GetLength(0)];
                PrintMatrix(temp);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

            }
            //Заполнение 1 матрицы 

            #endregion

            Console.WriteLine("Выходная матрица ");
            PrintMatrix(temp);
        }
        private static Random random = new Random();
        static void Main(string[] args)
        {
            const int N = 10;//Размер матрицы
            int[,] code_matrix = new int[N, N]; //Матрица для кодирования

            FillMatrix(code_matrix, N);//Заполнение матрицы
            IncMatrix(code_matrix);
            Console.ReadKey();
        }
    }
}
