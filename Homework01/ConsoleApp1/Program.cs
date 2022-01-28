/// <summary>
/// Студент: Фишелев Олег AR/VR
/// </summary>

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
        /// Точка входа в программу
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {

            /* Задание 1
            Написать программу «Анкета». Последовательно задаются вопросы (имя, фамилия, возраст, рост, вес).
            В результате вся информация выводится в одну строчку:
            а) используя склеивание;
            б) используя форматированный вывод;
            в) используя вывод со знаком $.
            */
            Questionnaire();

            /* Задание 2
            Ввести вес и рост человека.
            Рассчитать и вывести индекс массы тела(ИМТ) по формуле I=m/(h* h);
            где m — масса тела в килограммах, h — рост в метрах.
            */
            MassIndex();

            /* Задание 3 
            а) Написать программу, которая подсчитывает расстояние между точками с координатами x1, y1 и x2,y2
            по формуле r = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2).
            Вывести результат, используя спецификатор формата .2f(с двумя знаками после запятой);
            б) *Выполнить предыдущее задание, оформив вычисления расстояния между точками в виде метода.
            */

            //Представлено решение только варианта "б", т.к. вариант "а" простой.
            //Вызываем метод для рассчета расстояния, запрашиваем координаты точек прямо в метод, выводим результат работы метода.
            Console.WriteLine("\nВведите последовательно координаты x1, y1, x2, y2 для рассчета расстояния между точками: ");
            Console.WriteLine("Расстояние между точками {0:F2}", CountDistance(
                    double.Parse(Console.ReadLine()),
                    double.Parse(Console.ReadLine()),
                    double.Parse(Console.ReadLine()),
                    double.Parse(Console.ReadLine()))
            );

            /* Задание 4
            Написать программу обмена значениями двух переменных:
            а) с использованием третьей переменной;
            б) *без использования третьей переменной.
             */

            //Вариант "а"
            //Объявляем переменные
            int x = 3, y = 7 , z;
            Console.WriteLine($"\nИсходные значения переменных x = {x}, y = {y}");
            
            //Сохраняем значение x в переменную z
            z = x;
            //Меняем х и у местами
            x = y; y = z;
            Console.WriteLine($"Значения переменных после обмена x = {x}, y = {y}");

            //Вариант "б" (решение только для числовых значений, для неисловых нагуглил (x, y) = (y, x), но мы это пока не проходили :)
            //Возвращаем значения переменных к исходным
            x = 3; y = 7;
            Console.WriteLine($"\nИсходные значения переменных x = {x}, y = {y}");

            //Меняем х и у местами
            x += y;
            y = x - y;
            x -= y;
            Console.WriteLine($"Значения переменных после обмена x = {x}, y = {y}");

            /* Задание 5
            а) Написать программу, которая выводит на экран ваше имя, фамилию и город проживания.
            б) *Сделать задание, только вывод организовать в центре экрана.
            в) **Сделать задание б с использованием собственных методов(например, Print(string ms, int x, int y).
            */

            string msg = "Студент: Фишелев Олег, город: Екатеринбург";
            //Вариант "а"
            Console.WriteLine("\n" + msg);
            Pause();

            //Вариант "б" и "в"
            //Очищаем консоль
            Console.Clear();

            //используем собственный метод для вывода текста на экран, центр определяем поделив длину консоли пополам и вычитаем половину длины печатаемой строки
            Print(msg, Console.WindowWidth/2 - msg.Length/2, Console.WindowHeight / 2);

            /* Задание 6
            Создать класс с методами, которые могут пригодиться в вашей учебе(Print, Pause).
            */
            
            //Метод print создан и использован для задания 5
            Pause();

        }
                 
        /// <summary>
        /// Запрашивает параметры пользователя и выводит их в одну строку разными способами
        /// </summary>
        static void Questionnaire()
        {
            String name, surname;
            int age, height, weight;
            
            //запрашиваем параметры
            Console.Write("Введите ваше имя: ");
            name = Console.ReadLine();

            Console.Write("Введите вашу фамилию: ");
            surname = Console.ReadLine();

            Console.Write("Введите ваш возраст, полных лет: ");
            age = int.Parse(Console.ReadLine());

            Console.Write("Введите ваш рост в см.: ");
            height = int.Parse(Console.ReadLine());

            Console.Write("Введите ваш вес в кг.: ");
            weight = int.Parse(Console.ReadLine());

            Console.WriteLine("\nСводная информация о вас:");
            Console.WriteLine(name + " " + surname +", " + age + " лет, рост " + height + " см., вес " + weight + " кг.");
            Console.WriteLine("{0} {1}, {2} лет, рост {3} см., вес {4} кг.", name, surname, age, height, weight);
            Console.WriteLine($"{name} {surname}, {age} лет, рост {height} см., вес {weight} кг.");
        }
                
        /// <summary>
        /// Запрашивает параметры и рассчитывает по ним индекс массы тела
        /// </summary>
        static void MassIndex()
        {
            double weight, height;
            
            Console.Write("\nВведите вес в кг. (m): ");
            weight = double.Parse(Console.ReadLine());

            Console.Write("Введите рост в м. (h): ");
            height = double.Parse(Console.ReadLine());

            Console.WriteLine($"Индекс массы тела (ИМТ) по формуле I=m/(h*h) равняется {weight / (height * height)}");
            
        }

        /// <summary>
        /// Рассчитывает расстояния по координатам двух точек
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <returns></returns>
        static double CountDistance(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }

        /// <summary>
        /// Переносит курсор на заданную позицию и печатает текст, переданный в метод
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        static void Print(string msg, int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(msg);
        }

        /// <summary>
        /// Метод для остановки программы и ожидания нажатия пользователем любой клавиши
        /// </summary>
        static void Pause()
        {
            Console.Write("\nНажмите любую клавишу чтобы продолжить");
            Console.ReadKey();
        }

    }
}

