/*
Студент: Фишелев Олег AR/VR

Домашнее задание к уроку #4

1. Дан  целочисленный  массив  из 20 элементов. 
Элементы  массива  могут принимать  целые  значения  от –10 000 до 10 000 включительно. Заполнить случайными числами.
Написать программу, позволяющую найти и вывести количество пар элементов массива, в которых только одно число делится на 3.
В данной задаче под парой подразумевается два подряд идущих элемента массива.
Например, для массива из пяти элементов: 6; 2; 9; –3; 6 ответ — 2.

2. Реализуйте задачу 1 в виде статического класса StaticClass;
а) Класс должен содержать статический метод, который принимает на вход массив и решает задачу 1;
б) *Добавьте статический метод для считывания массива из текстового файла. Метод должен возвращать массив целых чисел;
в)**Добавьте обработку ситуации отсутствия файла на диске.

3.
а) Дописать класс для работы с одномерным массивом.
Реализовать конструктор, создающий массив определенного размера и заполняющий массив числами от начального значения с заданным шагом.
Создать свойство Sum, которое возвращает сумму элементов массива, метод Inverse, возвращающий новый массив с измененными знаками у всех элементов массива (старый массив, остается без изменений),  метод Multi, умножающий каждый элемент массива на определённое число, свойство MaxCount, возвращающее количество максимальных элементов. 
б)** Создать библиотеку содержащую класс для работы с массивом. Продемонстрировать работу библиотеки
в)*** Подсчитать частоту вхождения каждого элемента в массив (коллекция Dictionary<int,int>)

4. Решить задачу с логинами из урока 2, только логины и пароли считать из файла в массив.
Создайте структуру Account, содержащую Login и Password.

5.
*а) Реализовать библиотеку с классом для работы с двумерным массивом. Реализовать конструктор, заполняющий массив случайными числами.
Создать методы, которые возвращают сумму всех элементов массива, сумму всех элементов массива больше заданного,
свойство, возвращающее минимальный элемент массива, свойство, возвращающее максимальный элемент массива,
метод, возвращающий номер максимального элемента массива (через параметры, используя модификатор ref или out).
**б) Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.
**в) Обработать возможные исключительные ситуации при работе с файлами.

 */

using System;
using System.IO;
using System.Linq;
using MyLib;
using System.Collections.Generic;

namespace ConsoleApp
{
    static class StaticClass
    {
        public static void Solver(int[] arr)
        {
            int PairCounter = 0;
            for (int i = 0; i < (arr.Length - 1); i++)
            {
                if ((arr[i] % 3 == 0 && arr[i + 1] % 3 != 0) || (arr[i] % 3 != 0 && arr[i + 1] % 3 == 0))
                {
                    PairCounter++;
                    Console.WriteLine($"Пара #{PairCounter}: {arr[i]} и {arr[i + 1]}");
                }
            }
            Console.WriteLine("Всего пар: " + PairCounter);
        }

        public static int[] LoadFromFile(string filename)
        {
            //Если файл существует
            if (File.Exists(filename))
            {
                //Считываем все строки в файл 
                string[] LoadedString = File.ReadAllLines(filename);
                int[] LoadedArr = new int[LoadedString.Length];
                //Переводим данные из строкового формата в числовой
                for (int i = 0; i < LoadedString.Length; i++) LoadedArr[i] = int.Parse(LoadedString[i]);
                Console.WriteLine($"В массив загружено из файла {LoadedString.Length} элементов\n");
                return LoadedArr;
            }
            else Console.WriteLine("Ошибка загрузки файла");
            return (null);
        }
    }
    
    class MyArray
    {
        private int[] arr;

        public MyArray(int size, int start, int step)
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
                for (int i = 0; i < arr.Length; i++) if(arr[i] > max) max = arr[i];
                return max;
            }
        }

        public void Print()
        {
            for (int i = 0; i < arr.Length; i++) Console.WriteLine($"{i} {arr[i]}"); ;
        }

        public int[] Inverse()
        {
            int[] InputArray = new int[arr.Length];
            arr.CopyTo(InputArray, 0);
            for (int i = 0; i < InputArray.Length; i++) InputArray[i] *= - 1;
            return InputArray;
        }

        public void Multi(int x)
        {
            for (int i = 0; i < arr.Length; i++) arr[i] *= x;
        }

    }

    struct Account
    {
        private string login;
        private string password;
        private int PasswordEntryAttempt;

        public void EnterPassword()
        {
            string loginEnter, passwordEnter;
            Console.WriteLine("Введите логин и пароль для входа в систему.");
            do
            {
                Console.WriteLine("\nОсталось попыток ввода #{0}", PasswordEntryAttempt);
                PasswordEntryAttempt--;

                Console.Write("Введите логин: ");
                loginEnter = Console.ReadLine();

                Console.Write("Введите пароль: ");
                passwordEnter = Console.ReadLine();                

                if (CheckPassword(loginEnter, passwordEnter))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\n::::: Логин и пароль верный, вы зашли в систему :::::");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                }
                else
                {
                    if (PasswordEntryAttempt > 0) Console.WriteLine("Ошибка при вводе логина или пароля, вы можете попробовать еще " + PasswordEntryAttempt + " раз.");
                    else Console.WriteLine("Вы исчерпали количество попыток ввода.");
                }
            } while (PasswordEntryAttempt > 0);            
        }

        private bool CheckPassword(string loginEnter, string passwordEnter)
        {
            return (loginEnter == login && passwordEnter == password) ? true : false;
        }

        public bool AccountFromFile(string fileName, int attempts)
        {
            if (File.Exists(fileName))
            {                
                StreamReader sr = new StreamReader(fileName);
                this.login = sr.ReadLine();
                this.password = sr.ReadLine();
                PasswordEntryAttempt = attempts;
                sr.Close();
                return true;
            }            
            return false;
        }
    }

    class Program
    {
        static void Main()
        {
            #region Инициализация переменных
            Random rnd = new Random();            
            bool KeepMenu = true;
            #endregion

            while (KeepMenu)
            {
                #region Инициализация меню
                Console.Clear();
                Console.Write("Введитие номер задания от 1 до 5, для выхода введите 0: ");
                int SelectMenu = int.Parse(Console.ReadLine());                                
                Console.Clear();
                #endregion

                switch (SelectMenu)
                {
                    #region Задача 1
                    case 1:
                        
                        int[] arr = new int[20];
                        for (int i = 0; i < arr.Length; i++) arr[i] = rnd.Next(-10000, 10001);
                        Console.WriteLine("Массив сгенерирован через класс random\n");

                        int PairCounter = 0;
                        for (int i = 0; i < (arr.Length - 1); i++)
                        {
                            if ((arr[i] % 3 == 0 && arr[i + 1] % 3 != 0) || (arr[i] % 3 != 0 && arr[i + 1] % 3 == 0))
                            {
                                PairCounter++;
                                Console.WriteLine($"Пара #{PairCounter}: {arr[i]} и {arr[i+1]}");
                            }
                        }
                        Console.WriteLine("Всего пар: " + PairCounter);
                        
                        Pause();
                        break;
                    #endregion

                    #region Задача 2
                    case 2:

                        int[] arr02 = new int[20];
                        arr02 = StaticClass.LoadFromFile(AppDomain.CurrentDomain.BaseDirectory + "MyArray.txt");
                        if (arr02 != null) StaticClass.Solver(arr02);                        

                        Pause();
                        break;
                    #endregion

                    #region Задача 3
                    case 3:                        
                        MyArray myarray01 = new MyArray(9, -15, 3);
                        Console.WriteLine("Сгенерирован массив:");
                        myarray01.Print();
                        Console.WriteLine($"Сумма элементов массива = {myarray01.Sum}\n");
                        
                        int[] myarray02 = myarray01.Inverse();
                        Console.WriteLine("Новый массив, полученный методом Inverse:");
                        for (int i = 0; i < myarray02.Length; i++) Console.WriteLine($"{i} {myarray02[i]}");

                        Console.Write("\nВведитие число на которое умножить массив: ");
                        int x = int.Parse(Console.ReadLine());
                        myarray01.Multi(x);
                        Console.WriteLine("\nМассив после умножения:");
                        myarray01.Print();
                        Console.WriteLine("Максимальный элемент массива: " + myarray01.GetMax);
                        Console.WriteLine("Количество максимальных элементов в массиве: " + myarray01.MaxCount);
                        Console.WriteLine("Чтобы перейти к демонстрации работы собственной библиотеки нажмите любую клавишу");
                        Console.ReadKey();
                        Console.Clear();
                        
                        Console.WriteLine($"Демонстрация работы собственной библиотеки");                        
                        MyLibArray DemoLibArray = new MyLibArray(5, -2, 4);
                        DemoLibArray.Print();
                        
                        
                        Console.WriteLine("\nРешение задачи 3в ***. Сгенерируем массив:");                        
                        //Генерируем массив со случайными числами от 1 до 10 для демонстрации, так как в массиве из задания #3
                        //все элементы встречаются только один раз (если шаг генерации !=0);
                        int[] DemoArray = new int[200];
                        for (int i = 0; i < DemoArray.Length; i++)
                        {
                            DemoArray[i] = rnd.Next(1,11);
                            Console.Write($"{DemoArray[i]} ");
                        }
                        Console.WriteLine("\n");

                        //Создаем объект словаря
                        Dictionary<int, int> DemoDict = new Dictionary <int, int>();

                        //Заносим все возможные значения элементов массива как ключи словаря
                        for (int i = 1;i <= 10; i++) DemoDict.Add(i, 0);

                        //Для каждого элемента массива увеличиваем значение соответсвуюбещго ему ключа в словаре на один
                        foreach (int el in DemoArray) DemoDict[el]++;

                        //Для каждого ключа в словаре выводим соответсвующее ему значение,
                        //оно и является количеством вхождений этого ключа в массив DemoArray
                        foreach (int el in DemoDict.Keys) Console.WriteLine($"{el} встречается {DemoDict[el]} раз");
                        
                        Pause();
                        break;
                    #endregion

                    #region Задача 4
                    case 4:
                        Account account = new Account();
                        if (account.AccountFromFile(AppDomain.CurrentDomain.BaseDirectory + "Account.txt", 3) == true) Console.WriteLine("Файл с логином и паролем прочитан");
                        else Console.WriteLine("Ошибка загрузки логина и пароля из файла");

                        account.EnterPassword();
                                               
                        Pause();
                        break;
                    #endregion

                    #region Задача 5
                    case 5:

                        MyLib2DArray TDArray = new MyLib2DArray(4, 3, -100, 100);
                        Console.WriteLine("Сгенерирован массив:");
                        TDArray.Print();
                        Console.WriteLine($"\nСумма элементов массива: {TDArray.Sum()}");
                        Console.WriteLine($"Сумма элементов массива больше 50: {TDArray.SumGraterThan(75)}");
                        Console.WriteLine($"Минимальный элемент массива: {TDArray.Min}");
                        Console.WriteLine($"Максимальный элемент массива: {TDArray.Max}");                     
                        TDArray.MaxIndex(out int MaxI, out int MaxJ);
                        Console.WriteLine($"Индекс элемента (первого найденного, если таких несколько) с максимальным значением: [{MaxI},{MaxJ}]\n");

                        Console.WriteLine("Чтобы перейти к демонстрации работы с файлами нажмите любую клавишу");
                        Console.ReadKey();
                        Console.Clear();

                        Console.WriteLine("Демонстрация записи массива в файл");
                        TDArray.Print();                        
                        TDArray.WriteToFile(AppDomain.CurrentDomain.BaseDirectory + "My2DArrayOutput.txt");

                        Console.WriteLine("\nДемонстрация загрузки массива из файла");
                        MyLib2DArray TDArray02 = new MyLib2DArray(3, 3, 0, 0);
                        TDArray02.LoadFromFile(AppDomain.CurrentDomain.BaseDirectory + "My2DArrayInput.txt", 5, 3);
                        TDArray02.Print();

                        Pause();
                        break;
                    #endregion

                    #region Функции меню
                    case 0:
                        KeepMenu = false;
                        Console.WriteLine("Выход из программы");
                        break;

                    default:
                        Console.WriteLine("Ошибка ввода, попробуйте снова");
                        Pause();
                        break;
                    #endregion
                }
            }
        }

        static void Pause()
        {
            Console.Write("\nНажмите любую клавишу чтобы вернуться в меню...");
            Console.ReadKey();
        }
    }
}