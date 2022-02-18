/*
Студент: Фишелев Олег AR/VR

1.Изменить программу вывода таблицы функции так, чтобы можно было передавать функции типа double (double, double).
Продемонстрировать работу на функции с функцией a*x^2 и функцией a*sin(x).
*/

using System;

namespace Task1
{
    // Описываем делегат. В делегате описывается сигнатура методов, на
    // которые он сможет ссылаться в дальнейшем (хранить в себе)
    public delegate double Fun(double a, double x);

    class Program
    {
        // Создаем метод, который принимает делегат
        // На практике этот метод сможет принимать любой метод
        // с такой же сигнатурой, как у делегата
        public static void Table(Fun F, double a, double x, double b)
        {
            Console.WriteLine("----- A ----- X ----- Y -----");
            while (x <= b)
            {
                Console.WriteLine("| {0,8:0.000} | {1,8:0.000} | {2,8:0.000} |", a, x, F(a, x));
                x += 1;
            }
            Console.WriteLine("---------------------");
        }
        // Создаем метод для передачи его в качестве параметра в Table
        public static double MyFunc(double a, double x)
        {
            return a * Math.Pow(x, 2);
        }
        public static double ASinXFunc(double a, double x)
        {
            return a * Math.Sin(x);
        }

        static void Main()
        {
            Console.WriteLine("Таблица функции MyFunc a*x^2:");
            Table(MyFunc, 4, -2, 2);

            Console.WriteLine("Таблица функции a*sin(x):");
            Table(ASinXFunc, 3.5, -2, 2);

            Console.WriteLine("Использование анонимного метода для вывода таблицы функции a*sin(x):");
            Table(delegate (double a, double x) { return a * Math.Sin(x); }, 3.5, -2, 2);

            Console.WriteLine("Использование лямбда-выражения для вывода таблицы функции a*sin(x):");
            Table((a, x) => a * Math.Sin(x), 3.5, -2, 2);

            Console.ReadKey();
        }
    }
}

