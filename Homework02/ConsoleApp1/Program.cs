/* 
Студент: Фишелев Олег AR/VR

Домашнее задание к уроку #2
1. Написать метод, возвращающий минимальное из трёх чисел.
2. Написать метод подсчета количества цифр числа.
3. С клавиатуры вводятся числа, пока не будет введен 0. Подсчитать сумму всех нечетных положительных чисел.
4. Реализовать метод проверки логина и пароля. На вход метода подается логин и пароль.
На выходе истина, если прошел авторизацию, и ложь, если не прошел (Логин: root, Password: GeekBrains).
Используя метод проверки логина и пароля, написать программу: пользователь вводит логин и пароль, программа пропускает его дальше или не пропускает.
С помощью цикла do while ограничить ввод пароля тремя попытками.
5. а) Написать программу, которая запрашивает массу и рост человека, вычисляет его индекс массы и сообщает, нужно ли человеку похудеть, набрать вес или всё в норме.
5. б) *Рассчитать, на сколько кг похудеть или сколько кг набрать для нормализации веса.
6. *Написать программу подсчета количества «хороших» чисел в диапазоне от 1 до 1 000 000 000.
«Хорошим» называется число, которое делится на сумму своих цифр. Реализовать подсчёт времени выполнения программы, используя структуру DateTime.
7. a) Разработать рекурсивный метод, который выводит на экран числа от a до b(a<b).
7. б) *Разработать рекурсивный метод, который считает сумму чисел от a до b.

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /// <summary>
    /// Основной класс
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Метод main - точка старта программы
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {   

            bool keepMenu = true;
            while (keepMenu)
            {
                Console.Clear(); //при входе в меню очищаем экран

                Console.Write("Введитие номер задания от 1 до 7, длля выхода введите 0: ");
                int selector = int.Parse(Console.ReadLine());
                switch (selector)
                {   
                    //Задача 1
                    case 1:
                        Console.WriteLine("\nВведите три числа, программа выведет минимальное из них: ");
                        Console.WriteLine("Минимальное число: " + GetMinOfThreeNumbers(double.Parse(Console.ReadLine()), double.Parse(Console.ReadLine()), double.Parse(Console.ReadLine())));                        
                        Pause();
                        break;

                    //Задача 2
                    case 2:
                        Console.WriteLine("\nВведите целое положительное или отрицательное число: ");
                        Console.WriteLine("Количество цифр введенного числа: {0}", GetNumberLength(long.Parse(Console.ReadLine())));
                        Pause();
                        break;

                    //Задача 3
                    case 3:
                        Console.WriteLine("\nВводите целые числа, при вводе 0 программа подсчитает кол-во введенных нечетных положительных чисел");
                        Console.WriteLine("Количество введенных нечетных положительных чисел: {0}", GetOddPositive());
                        Pause();
                        break;

                    //Задача 4
                    case 4:
                        string login, password;
                        int PasswordEntryAttempt = 0;
                        Console.WriteLine("Введите логин и пароль для входа в систему.");
                        

                        do
                        {
                            PasswordEntryAttempt++;
                            Console.WriteLine("\nПопытка ввода пароля #{0}" , PasswordEntryAttempt);
                            Console.Write("Введите логин: ");
                            login = Console.ReadLine();

                            Console.Write("Введите пароль: ");
                            password = Console.ReadLine();

                            if (CheckPassword(login, password)) 
                            {   
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("Логин и пароль верный, вы зашли в систему");
                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                            }
                            else
                            {
                                if (PasswordEntryAttempt < 3)
                                {
                                    Console.WriteLine("Ошибка при вводе логина или пароля, вы можете попробовать еще " + (3 - PasswordEntryAttempt) + " раз.");

                                }
                                else Console.WriteLine("Вы исчерпали количество попыток ввода.");

                            }
                            
                        }
                        while (CheckPassword(login, password) == false && PasswordEntryAttempt < 3);

                        Pause();
                        break;

                    //Задача 5
                    case 5:
                        MassIndexAnalysis();
                        Pause();
                        break;

                    //Задача 6
                    case 6:
                        DateTime runTimeStart = DateTime.Now;
                        Console.WriteLine("Идет расчет...");

                        long sumNumbers = 0;
                        for (long i = 1; i <= 1000000000; i++) if (i % RecursiveDigitSum(i) == 0) sumNumbers++;
                        
                        DateTime runTimeFinish = DateTime.Now;
                        Console.WriteLine("Программа выполнялась " + (runTimeFinish - runTimeStart));
                        Console.WriteLine($"{sumNumbers:N0} \"хороших\" числа в диапазоне от 1 до 1 000 000 000.");                               
                        
                        Pause();
                        break;

                    //Задача 7
                    case 7:
                        int a, b;
                        Console.WriteLine("Введите число а: ");
                        a = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите число b, где b > a: ");
                        b = int.Parse(Console.ReadLine());

                        Console.WriteLine("\nВыводим на экран все числа от a до b при помощи рекурсивного метода:");
                        RecursiveWriteAtoB(a, b);
                        Console.WriteLine("\nСумируем числа от a до b при помощи рекурсивного метода: " + RecursiveSumAtoB(a, b));

                        Pause();
                        break;
                    
                    //Выход из программы
                    case 0:
                        keepMenu = false;
                        Console.WriteLine("Выход из программы");
                        break;

                    //Отрабатываем ошибку при вводе пункта меню
                    default:
                        Console.WriteLine("Ошибка ввода, попробуйте снова");
                        Pause();
                        break;
                }
            }
        }

        /// <summary>
        /// Возвращает минимальное из 3 чисел
        /// </summary>
        /// <param name="x">Число 1</param>
        /// <param name="y">Число 2</param>
        /// <param name="z">Число 3</param>
        /// <returns></returns>
        static double GetMinOfThreeNumbers(double x, double y, double z)
        {
            if (x <= y || x <= z) return x;
            else
            {
                if (y <= z) return y;
                else return z;
            }
        }

        /// <summary>
        /// 2Возвращает количество
        /// </summary>
        /// <param name="number">Число для анализа</param>
        /// <returns>Возвращает количество цифрв положительного или отрицательного целого числа</returns>
        static int GetNumberLength(long number)
        {
            int digits = 1;
            long treshold = 10;
            
            while (number >= treshold || number <= -treshold)
            {
                digits++;
                treshold = treshold * 10;                
            }
            return digits;
        }

        /// <summary>
        /// Запрашивает ввод чисел. При вводе нуля подсчитывает количество введенных положительных нечетных чисел.
        /// </summary>
        /// <returns></returns>
        static int GetOddPositive()
        {
            int counter = 0;
            int input;
            
            do
            {
                input = int.Parse(Console.ReadLine());
                if (input > 0 && input % 2 == 1) counter++;
            }
            while (input!=0);
            return counter;
        }

        /// <summary>
        /// Возвращает информацию о том, корректны или нет введенные логин и пароль
        /// </summary>
        /// <param name="login">Логин</param>
        /// <param name="password">Пароль</param>
        /// <returns></returns>
        static bool CheckPassword(string login, string password)
        {
           return (login == "root" && password == "GeekBrains") ? true : false;
        }

        /// <summary>
        /// Запрашивает данные о человеке, рассчитывает индекс массы тела и выводит рекомендации по диете.
        /// </summary>
        static void MassIndexAnalysis()
        {
            double mass, height, massIndex;
            Console.WriteLine("Введите массу человека в килограммах: ");
            mass = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите рост человека в сантиметрах: ");
            height = double.Parse(Console.ReadLine())/100;
            massIndex = mass / (height * height);
            Console.Write("Индекс массы тела = {0:F2}. ", massIndex);

            if (massIndex < 18.5) Console.Write("Выраженный дефицит массы тела, ешь котлеты и пюре.\nДля нормализации нужно набрать минимум {0:F2} кг.", 18 * (height * height) - mass );
            else
            {
                if (massIndex < 25) Console.Write("Масса тела в норме.");
                else
                {
                    if (massIndex < 30) Console.Write("Избыточная масса тела, пора худеть.\nДля нормализации нужно сбросить минимум {0:F2} кг.", mass - 25 * (height * height));
                    else
                    {
                        Console.Write("Жирный как поезд пассажирный, срочно на диету.\nДля нормализации нужно сбросить минимум {0:F2} кг.", mass - 25 * (height * height));
                    }
                }
            }            
        }

        /// <summary>
        /// Возвращает сумму цифр числа, рекурсивный метод
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        static long RecursiveDigitSum(long number)
        {
            if (number == 0) return 0;
            else return (number % 10 + RecursiveDigitSum(number / 10));
        }

        /// <summary>
        /// Выводит на экран числа от a до b через рекурсию
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        static void RecursiveWriteAtoB(int a, int b)
        {
            if (a <= b)
            {
                Console.WriteLine(a);
                RecursiveWriteAtoB(a + 1, b);
            }
        }

        /// <summary>
        /// Возвращает сумму всех чисел между a и b включительно
        /// </summary>
        /// <param name="a">Число a</param>
        /// <param name="b">Число b</param>
        /// <returns></returns>
        static int RecursiveSumAtoB(int a, int b)
        {
            if (a <= b) return (a + RecursiveSumAtoB(a + 1, b));
            else return 0;
        }

        /// <summary>
        /// Запрашивает нажатие любой клавиши для возврата в меню
        /// </summary>
        static void Pause()
        {
            Console.WriteLine("\nНажмите любую клавишу чтобы вернуться в меню");
            Console.ReadKey();        
        }

        

    }

}

