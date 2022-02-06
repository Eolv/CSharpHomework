/*
Студент: Фишелев Олег AR/VR

Домашнее задание к уроку #2
1.
а) Дописать структуру Complex, добавив метод вычитания комплексных чисел. Продемонстрировать работу структуры.
б) Дописать класс Complex, добавив методы вычитания и произведения чисел. Проверить работу класса.
в) Добавить диалог с использованием switch демонстрирующий работу класса.

2.
а) С клавиатуры вводятся числа, пока не будет введён 0 (каждое число в новой строке). Требуется подсчитать сумму всех нечётных положительных чисел. Сами числа и сумму вывести на экран, используя tryParse.

3. *Описать класс дробей — рациональных чисел, являющихся отношением двух целых чисел. Предусмотреть методы сложения, вычитания, умножения и деления дробей. Написать программу, демонстрирующую все разработанные элементы класса.

Добавить свойства типа int для доступа к числителю и знаменателю;
Добавить свойство типа double только на чтение, чтобы получить десятичную дробь числа;
**Добавить проверку, чтобы знаменатель не равнялся 0. Выбрасывать исключение ArgumentException("Знаменатель не может быть равен 0");
***Добавить упрощение дробей.

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    /// <summary>
    /// Структура комплексное число
    /// </summary>
    struct ComplexStruct
    {
        /// <summary>
        /// Действительная часть
        /// </summary>
        public double re;

        /// <summary>
        /// Мнимая часть
        /// </summary>
        public double im;

        /// <summary>
        /// Конструктор комплексного числа
        /// </summary>
        /// <param name="inp_re"></param>
        /// <param name="inp_im"></param>
        public ComplexStruct(double inp_re, double inp_im)
        {
            this.re = inp_re;
            this.im = inp_im;
        }

        /// <summary>
        /// Вывод комплексного чесла в виде строки
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string representation = "";
            if (re != 0) representation += re;
            else
            {
                if (im == 0) return "0";
            }

            switch (im)
            {
                case -1:
                    representation += "-i";
                    break;
                case 0:
                    break;
                case 1:
                    representation += "+i";
                    break;
                default:
                    //убираем действительную часть, если она 0
                    //если мнимая часть больше 0, выводим "+" перед ней, минус же выводится по умолчанию
                    representation += ((im > 0) ? "+" : "") + im + "i";
                    break;
            }
            return representation;
        }

        /// <summary>
        /// Сложение комплесных чисел
        /// </summary>
        /// <param name="secondNum"></param>
        /// <returns></returns>        
        public ComplexStruct Plus(ComplexStruct secondNum)
        {
            ComplexStruct output;
            output.im = im + secondNum.im;
            output.re = re + secondNum.re;
            return output;
        }

        /// <summary>
        /// Разность комплесных чисел
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>        
        public ComplexStruct Minus(ComplexStruct secondNum)
        {
            ComplexStruct output;
            output.im = im - secondNum.im;
            output.re = re - secondNum.re;
            return output;            
            
            //Можно вывести так без промежуточной переменной?
            //return new ComplexStruct(re - secondNum.re, im - secondNum.im);
        } 
    }

    /// <summary>
    /// Класс комплексное число
    /// </summary>
    class ComplexClass
    {
        /// <summary>
        /// Поле: действительная часть комплексного числа
        /// </summary>
        private double re;

        /// <summary>
        /// Поле: мнимая часть комплексного числа
        /// </summary>
        private double im;

        /// <summary>
        /// Свойство: действительная часть комплексного числа
        /// </summary>
        public double Re
        {
            get
            {
                return re;
            }
            set
            {
                re = value;
            }
        }
        /// <summary>
        /// Свойство: мнимая часть комплексного числа
        /// </summary>
        public double Im
        {
            get
            {
                return im;
            }
            set
            {
                im = value;
            }
        }

        /// <summary>
        /// Конструктор класса комплексное число
        /// </summary>
        /// <param name="re"></param>
        /// <param name="im"></param>
        public ComplexClass(double re, double im)
        {            
            this.re = re;
            this.im = im;
        }

        /// <summary>
        /// Перегрузка метода вывода комплексного числа в виде строки
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string representation = "";
            if (re != 0) representation += re;
            else
            {
                if (im == 0) return "0";
            }

            switch (im)
            {
                case -1:
                    representation += "-i";
                    break;
                case 0:
                    break;
                case 1:
                    representation += "+i";
                    break;
                default:
                    //убираем действительную часть, если она 0
                    //если мнимая часть больше 0, выводим "+" перед ней, минус же выводится по умолчанию
                    representation += ((im > 0) ? "+" : "") + im + "i";
                    break;
            }
            return representation;
        }

        /// <summary>
        /// Сложение комплексных чисел
        /// </summary>
        /// <param name="secondNum"></param>
        /// <returns></returns>
        public ComplexClass Plus(ComplexClass secondNum)
        {
            return new ComplexClass(re + secondNum.re, im + secondNum.im);
        }

        /// <summary>
        /// Разность комплексных чисел
        /// </summary>
        /// <param name="secondNum"></param>
        /// <returns></returns>
        public ComplexClass Minus(ComplexClass secondNum)
        {
            return new ComplexClass(re - secondNum.re, im - secondNum.im);
        }

        /// <summary>
        /// Умножение комплексных чисел
        /// </summary>
        /// <param name="secondNum"></param>
        /// <returns></returns>
        public ComplexClass Multi(ComplexClass secondNum)
        {
            return new ComplexClass(re * secondNum.re - im * secondNum.im, re * secondNum.im + im * secondNum.re);
        }
    }

    /// <summary>
    /// Класс дробей
    /// </summary>
    class Fraction
    {
        private int numerator, denominator;

        public int Numerator
        {
            get
            {
                return numerator;
            }
            set
            {
                numerator = value;
            }
        }

        public int Denominator
        {
            get
            {
                return denominator;
            }
            set
            {
                if (value <= 0)
                {
                    throw new Exception("Знаменатель не может равняться нулю или быть меньше нуля!");
                }
                denominator = value;
            }
        }

        public double DecimalValue
        {
            get
            {
                return (double) numerator / denominator;
            }
        }

        public Fraction(int numerator, int denominator)
        {
            if (denominator <= 0)
            {
                throw new Exception("Знаменатель не может равняться нулю или быть меньше нуля!");
            }
            this.numerator = numerator;
            this.denominator = denominator;
        }

        public override string ToString()
        {
            if (numerator == 0) return "0";
            else
            {
                if (denominator == 1) return $"{numerator}";
                else
                {
                    return $"{numerator}/{denominator}";
                }
            }            
        }    

        public Fraction Plus(Fraction fraction2)
        {
            return new Fraction(numerator * fraction2.denominator + fraction2.numerator * denominator, denominator * fraction2.denominator);            
        }

        public Fraction Minus(Fraction fraction2)
        {
            return new Fraction(numerator * fraction2.denominator - fraction2.numerator * denominator, denominator * fraction2.denominator);
        }

        public Fraction Multi(Fraction fraction2)
        {
            return new Fraction(numerator * fraction2.numerator , denominator * fraction2.denominator);
        }
        public Fraction Devide(Fraction fraction2)
        {            
            return new Fraction(numerator * fraction2.denominator * (fraction2.numerator < 0 ? -1 : 1), denominator * fraction2.numerator * (fraction2.numerator < 0 ? -1 : 1));
        }

        //Метод упрощения дроби
        public void FractionReduction()
        {
            int r = FractionGCD();
            if (r > 1)
            {
                Console.Write($"упрощено до ");
                numerator /= r;
                denominator /= r;
                Console.Write($"{this}");
            }

        }

        //Алгоритм поиска наибольшего общего делителя нашел в интернете :)
        public int FractionGCD()
        {
            int a = Math.Abs(numerator);
            int b = Math.Abs(denominator);

            while (a != 0 && b != 0)
            {
                if (a > b)
                    a %= b;
                else
                    b %= a;
            }

            return a | b;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {

            bool KeepMenu = true;
            while (KeepMenu)
            {
                //иницилизируем переменные для ввода пользователем чисел
                double inpComplexIm = 0; double inpComplexRe = 0;
                int inpNumerator, inpDenominator;

                //при входе в меню очищаем экран
                Console.Clear();

                Console.Write("Введитие номер задания от 1 до 3, для выхода введите 0: ");
                
                int SelectMenu = int.Parse(Console.ReadLine());                
                switch (SelectMenu)
                {
                    //Задача 1
                    case 1:
                        Console.WriteLine("\nДемонстрация работы структуры комплексных чисел\n");

                        //Запрашиваем и инициализируем числа 1 и 2 через структуру
                        UserRequestComplex(out inpComplexRe, out inpComplexIm);
                        ComplexStruct complexS01 = new ComplexStruct(inpComplexRe, inpComplexIm);                                                
                        Console.WriteLine();
                        UserRequestComplex(out inpComplexRe, out inpComplexIm);
                        ComplexStruct complexS02 = new ComplexStruct(inpComplexRe, inpComplexIm);
                        
                        //Демонстрируем работу методов структуры
                        Console.Write($"\n{DisplayComplex(1, complexS01)}\n{DisplayComplex(2, complexS02)}" +
                        $"\nРазность чисел: {complexS01.Minus(complexS02)} \n\nНажмите любую клавишу чтобы продолжить...");

                        Console.ReadKey();
                        Console.Clear();

                        //Запрашиваем и инициализируем числа 1 и 2 через класс
                        Console.WriteLine("Демонстрация работы класса комплексных чисел\n");                                                
                        UserRequestComplex(out inpComplexRe, out inpComplexIm);
                        ComplexClass complexC01 = new ComplexClass(inpComplexRe, inpComplexIm);                                                                        
                        Console.WriteLine();
                        UserRequestComplex(out inpComplexRe, out inpComplexIm);
                        ComplexClass complexC02 = new ComplexClass(inpComplexRe, inpComplexIm);


                        //Демонстрируем работу методов класса через switch
                        Console.Write($"\n{DisplayComplex(1, complexC01)}\n{DisplayComplex(2, complexC02)} " +
                            $"\n\nДля демонстрации методов класса введите пункт меню:");
                            
                        //Меню для задания 1
                        bool KeepMenu2 = true;
                        while (KeepMenu2)
                        {
                            Console.Write($"\n1 - сложение, 2 - вычитание, 3 - умножение, 0 - выход в основное меню: ");
                            SelectMenu = int.Parse(Console.ReadLine());
                            switch (SelectMenu)
                            {
                                case 1:
                                    Console.WriteLine($"\nСумма чисел: {complexC01.Plus(complexC02)}");
                                    break;

                                case 2:
                                    Console.WriteLine($"\nРазность чисел: {complexC01.Minus(complexC02)}");
                                    break;

                                case 3:
                                    Console.WriteLine($"\nУмножение чисел: {complexC01.Multi(complexC02)}");
                                    break;

                                case 0:
                                    KeepMenu2 = false;
                                    break;
                            }
                        }

                        Pause();
                        break;

                    case 2:
                        Console.WriteLine("\nВводите целые числа, все нечетные положительные будут просуммированы.\nВвод нуля остановит программу:");
                        int totalSum = 0;
                        int parseNumber;                        
                        bool parseSuccessful;
                        do
                        {                            
                            parseSuccessful = int.TryParse(Console.ReadLine(), out parseNumber);
                            if (parseSuccessful == false) Console.WriteLine("Ошибка ввода");
                            else
                            {
                                if (parseNumber > 0 && parseNumber % 2 == 1)
                                {
                                    totalSum += parseNumber;
                                    Console.WriteLine("Сумма нарастающим итогом: " + totalSum);
                                }
                            }
                                
                        } while (parseNumber != 0 || parseSuccessful != true);
                        Console.WriteLine("===============\nИтоговая сумма: " + totalSum);

                        Pause();
                        break;

                    case 3:
                        Console.WriteLine("\nДемонстрация работы класса дробей\n");                        

                        UserRequestFraction(out inpNumerator, out inpDenominator);
                        Fraction fraction01 = new Fraction(inpNumerator, inpDenominator);
                        Console.WriteLine();
                        UserRequestFraction(out inpNumerator, out inpDenominator);
                        Fraction fraction02 = new Fraction(inpNumerator, inpDenominator);
                        Fraction fraction03 = new Fraction(1, 1);
                                                
                        Console.Write($"\nДробь 1: {fraction01} ");
                        fraction01.FractionReduction();
                        Console.Write($"\nДробь 2: {fraction02} ");
                        fraction02.FractionReduction();

                        Console.Write($"\n\nРезультат сложения дробей: ");
                        fraction03 = fraction01.Plus(fraction02);
                        Console.Write(fraction03 + " ");
                        fraction03.FractionReduction();

                        Console.Write("\nРезультат вычитания дробей: ");
                        fraction03 = fraction01.Minus(fraction02);
                        Console.Write(fraction03 + " ");
                        fraction03.FractionReduction();

                        Console.Write("\nРезультат умножения дробей: ");
                        fraction03 = fraction01.Multi(fraction02);
                        Console.Write(fraction03 + " ");
                        fraction03.FractionReduction();

                        Console.Write("\nРезультат деления дробей: ");
                        fraction03 = fraction01.Devide(fraction02);
                        Console.Write(fraction03 + " ");
                        fraction03.FractionReduction();

                        Console.WriteLine($"\n\nДемонстрация свойств класса для доступа к числителю и знаменателю дроби 1:\nЧислитель = {fraction01.Numerator}, знаменатель = {fraction01.Denominator}");
                        
                        Console.WriteLine($"\nДемонстрация свойства класса, доступного только на чтение, для получения дроби 1 в десятичном виде:\nДробь в десятичном виде = {fraction01.DecimalValue}");

                        Pause();
                        break;

                    //Выход из программы
                    case 0:
                        KeepMenu = false;
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
        
        static void UserRequestComplex(out double Im, out double Re)
        {
            Console.Write("Введите действительную часть комплексного числа: ");
            Im = double.Parse(Console.ReadLine());
            Console.Write("Введите мнимую часть комплексного числа: ");
            Re = double.Parse(Console.ReadLine());            
        }

        static void UserRequestFraction(out int Numerator, out int Denominator)
        {
            Console.Write("Введите числитель дроби (целое число): ");
            Numerator = int.Parse(Console.ReadLine());
            Console.Write("Введите Знаменатель дроби (натуральное число): ");
            Denominator = int.Parse(Console.ReadLine());
        }

        /// <summary>
        /// Запрос данных для инициализации комплесного числа
        /// </summary>
        /// <param name="i"></param>
        /// <param name="complex"></param>
        /// <returns></returns>
        static string DisplayComplex(int i, ComplexStruct complex)
        {
            return $"Комплексное число #{i}: {complex}";
        }

        /// <summary>
        /// Перегрузка метода для запроса данных для инициализации комплесного числа
        /// </summary>
        /// <param name="i"></param>
        /// <param name="complex"></param>
        /// <returns></returns>
        static string DisplayComplex(int i, ComplexClass complex)
        {
            return $"Комплексное число #{i}: {complex}";
        }

        static void Pause()
        {
            Console.Write("\nНажмите любую клавишу чтобы вернуться в меню...");
            Console.ReadKey();
        }
    }
}

        