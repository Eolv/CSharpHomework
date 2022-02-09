using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib
{
    public class MyLibArray
    {
        private int[] arr;

        public MyLibArray(int size, int start, int step)
        {
            arr = new int[size];
            for (int i = 0; i < size; i++) arr[i] = start + i * step;
        }

        public int Sum
        {
            get
            {
                int sum = 0;
                for (int i = 0; i < arr.Length; i++) sum += arr[i];
                return sum;
            }
        }

        public int MaxCount
        {
            get
            {
                int max = GetMax;
                int maxcount = 0;
                for (int i = 0; i < arr.Length; i++) if (arr[i] == max) maxcount++;
                return maxcount;
            }
        }

        public int GetMax
        {
            get
            {
                int max = arr[0];
                for (int i = 0; i < arr.Length; i++) if (arr[i] > max) max = arr[i];
                return max;
            }
        }

        public void Print()
        {
            Console.WriteLine("Это метод Print() для вывода массива, он вызван из класса MyLibArray библиотеки MyLibrary:");
            for (int i = 0; i < arr.Length; i++) Console.WriteLine($"{i} {arr[i]}"); ;
        }

        public int[] Inverse()
        {
            int[] InputArray = new int[arr.Length];
            arr.CopyTo(InputArray, 0);
            for (int i = 0; i < InputArray.Length; i++) InputArray[i] *= -1;
            return InputArray;
        }

        public void Multi(int x)
        {
            for (int i = 0; i < arr.Length; i++) arr[i] *= x;
        }

    }

    public class MyLib2DArray
    {
        private int[,] arr;

        public MyLib2DArray(int x, int y, int min, int max)
        {
            arr = new int[x,y];
            Random rnd = new Random();
            for (int i = 0; i < x; i++)
                for (int j = 0; j < y; j++)
                    arr[i,j] = rnd.Next(min, max);
        }

        public void LoadFromFile(string filename, int x, int y)
        {
            try
            {
                string[] LoadedString = File.ReadAllLines(filename);
                int[,] LoadedArr = new int[x, y];

            //Переводим данные из строкового формата в числовой
                for (int i = 0; i < x; i++)
                    for (int j = 0; j < y; j++)
                        LoadedArr[i, j] = int.Parse(LoadedString[i * y + j]);
            Console.WriteLine($"В массив загружено {LoadedString.Length} элементов из файла \n{filename}");
            arr = LoadedArr;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}\nЗагрузка данных в массив не выполнена.");
            }            
        }

        public void WriteToFile(string filename)
        {
            try
            {
                string[] TextToFile = new string[arr.GetLength(0) * arr.GetLength(1)];
                for (int i = 0; i < arr.GetLength(0); i++)
                    for (int j = 0; j < arr.GetLength(1); j++)
                    {
                        TextToFile[i * arr.GetLength(1) + j] = (arr[i, j]).ToString();
                    }
                StreamWriter sw = new StreamWriter(filename);
                for (int i = 0; i < TextToFile.Length - 1; i++)
                {
                    sw.WriteLine(TextToFile[i]);
                }
                //используем команду Write в конце, чтобы не получить пустую строку от WriteLine
                sw.Write(TextToFile[TextToFile.Length - 1]);
                sw.Close();
                Console.WriteLine("Поток закрыт, массив записан в файл:\n" + filename);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}\nЗапись данных в массив не выполнена.");
            }
        }

        public void Print()
        {            
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                for (int i = 0; i < arr.GetLength(0); i++) Console.Write($"{arr[i, j], 5} ");
                Console.WriteLine();
            }
                
        }
        public int Sum()
        {
                int sum = 0;
                for (int i = 0; i < arr.GetLength(0); i++)
                    for (int j = 0; j < arr.GetLength(1); j++) 
                        sum += arr[i,j];
                return sum;
        }

        public int SumGraterThan(int x)
        {
            int sum = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
                for (int j = 0; j < arr.GetLength(1); j++)
                    if (arr[i, j] > x) sum += arr[i, j];
            return sum;
        }

        public int Min
        {
            get
            {
                int min = arr[0, 0];
                for (int i = 0; i < arr.GetLength(0); i++)
                    for (int j = 0; j < arr.GetLength(1); j++)
                        if (arr[i, j] < min) min = arr[i, j];
                return min;
            }
        }

        public int Max
        {
            get
            {
                int max = arr[0, 0];
                for (int i = 0; i < arr.GetLength(0); i++)
                    for (int j = 0; j < arr.GetLength(1); j++)
                        if (arr[i, j] > max) max = arr[i, j];
                return max;
            }
        }

        public void MaxIndex(out int MaxI, out int MaxJ)
        {            
            {
                int max = Max;
                for (int i = 0; i < arr.GetLength(0); i++)
                    for (int j = 0; j < arr.GetLength(1); j++)
                        if (arr[i, j] == max)
                        {                            
                            MaxI = i; MaxJ = j;
                            return;
                        }
                MaxI = -1; MaxJ = -1;
            }
        }


    }
}

