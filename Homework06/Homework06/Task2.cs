/*
Студент: Фишелев Олег AR/VR

2. Модифицировать программу нахождения минимума функции так,
чтобы можно было передавать функцию в виде делегата.

а) Сделать меню с различными функциями и представить пользователю выбор,
для какой функции и на каком отрезке находить минимум.

Использовать массив (или список) делегатов, в котором хранятся различные функции.
б)* Переделать функцию Load, чтобы она возвращала массив считанных значений.
Пусть она возвращает минимум через параметр (с использованием модификатора out). 
*/

using System;
using System.Collections.Generic;
using System.IO;

namespace Task2
{
    /// <summary>
    /// Делегат, используемый для вызова математических функций
    /// </summary>
    /// <param name="x"></param>
    /// <returns></returns>
    public delegate double Func(double x);

    /// <summary>
    /// Класс для хранения списка математических функций, используемых с делегатом Func, и их названий
    /// </summary>
    class MyDelegateFunc
    {
        public string Name { get; set; }
        public Func Func { get; set; }
        public MyDelegateFunc(string Name, Func Func)
        {
            this.Name = Name;
            this.Func = Func;
        }
    }

    class Program
    {
        /// <summary>
        /// Метод для вызова делегата типа Func
        /// </summary>
        /// <param name="function"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public static double ProcessFunc(Func function, double x) 
        {
            return function(x);
        }
        
        #region Математические функции
        public static double F1(double x)
        {
            return x * x - 50 * x + 10;
        }

        public static double F2(double x)
        {
            return x;
        }

        public static double F3(double x)
        {
            return -x*x/3;
        }
        #endregion

        public static void SaveFunc(Func function, string fileName, double a, double b, double h)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            double x = a;
            while (x <= b)
            {                
                bw.Write(ProcessFunc(function, x));
                x += h;
            }
            bw.Close();
            fs.Close();
        }

        public static double[] Load(string fileName, out double Min)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader bw = new BinaryReader(fs);            
            double[] ReadArr = new double[fs.Length];
            Min = double.MaxValue;
            for (int i = 0; i < fs.Length / sizeof(double); i++)
            {
                ReadArr[i] = bw.ReadDouble(); // Считываем значение и переходим к следующему
                if (ReadArr[i] < Min) Min = ReadArr[i];
            }
            bw.Close();
            fs.Close();            
            return ReadArr;
        }

        static void Main(string[] args)
        {
            double Min;

            List<MyDelegateFunc> FuncList = new List<MyDelegateFunc>{
                new MyDelegateFunc("x * x - 50 * x + 10 ", F1),
                new MyDelegateFunc("x", F2),
                new MyDelegateFunc("-x*x/3", F3)};

            bool KeepMenu = true;
            while (KeepMenu)
            {                
                Console.WriteLine("Список функций:");
                for (int i = 0;i < FuncList.Count;i++) Console.WriteLine($"{i + 1}: {FuncList[i].Name}");
                Console.Write("\nВведите номер желаемой функции: ");

                int Selector = int.Parse(Console.ReadLine());                
                Func function = null;
                if (Selector >= 1 && Selector <= 3) function = FuncList[Selector-1].Func;
                else Console.WriteLine("Ошибка ввода");

                if (function != null)
                {
                    Console.Write("введите a: ");
                    double a = double.Parse(Console.ReadLine());
                    Console.Write("введите b: ");
                    double b = double.Parse(Console.ReadLine());
                    double h = 0.5;

                    SaveFunc(function, "data.bin", a, b, h);
                    double[] ReadArr = Load("data.bin", out Min);
                    Console.WriteLine($"Для функция {FuncList[Selector-1].Name} на промежутке от {a} до {b} с шагом {h}\nМинимум функции = {Min}");
                }
                Console.WriteLine("\nНажмите любую клавишу чтобы продолжить");                
                Console.ReadKey(); 
                Console.Clear();
            }            
        }
    }
}
