/*
Студент: Фишелев Олег AR/VR

1. Создать программу, которая будет проверять корректность ввода логина. Корректным логином будет строка от 2 до 10 символов, содержащая только буквы латинского алфавита или цифры, при этом цифра не может быть первой:
а) без использования регулярных выражений;
б) **с использованием регулярных выражений.

2. Разработать статический класс Message, содержащий следующие статические методы для обработки текста:
а) Вывести только те слова сообщения, которые содержат не более n букв.
б) Удалить из сообщения все слова, которые заканчиваются на заданный символ.
в) Найти самое длинное слово сообщения.
г) Сформировать строку с помощью StringBuilder из самых длинных слов сообщения.
д) ***Создать метод, который производит частотный анализ текста. В качестве параметра в него передается массив слов и текст, в качестве результата метод возвращает сколько раз каждое из слов массива входит в этот текст. Здесь требуется использовать класс Dictionary.

3. *Для двух строк написать метод, определяющий, является ли одна строка перестановкой другой.
Например: badc являются перестановкой abcd.

4. *Задача ЕГЭ.
На вход программе подаются сведения о сдаче экзаменов учениками 9-х классов некоторой средней школы. В первой строке сообщается количество учеников N, которое не меньше 10,
но не превосходит 100, каждая из следующих N строк имеет следующий формат:
<Фамилия> <Имя> <оценки>,

где <Фамилия> — строка, состоящая не более чем из 20 символов, <Имя> — строка, состоящая не более чем из 15 символов, <оценки> — через пробел три целых числа,
соответствующие оценкам по пятибалльной системе. <Фамилия> и <Имя>, а также <Имя> и <оценки> разделены одним пробелом. 

Пример входной строки:
Иванов Петр 4 5 3

Требуется написать как можно более эффективную программу, которая будет выводить на экран фамилии и имена трёх худших по среднему баллу учеников.
Если среди остальных есть ученики, набравшие тот же средний балл, что и один из трёх худших, следует вывести и их фамилии и имена.

 */

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp
{
    public static class Message
    {
        private static string[] separators = { ",", ".", "!", "?", ";", ":", " ", "—", "-" };

        public static void GetWordsOfLength(string text, int length)
        {
            string[] words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            foreach (string word in words) if (word.Length <= length) Console.Write(word + " ");
        }

        
        public static void RemoveWords(string text, char ending)
        {
            StringBuilder sb = new StringBuilder(text.Length);
            string[] words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            //Реализация с помощью stringbuilder - режем на слова и пропускаем не нужные, проблема возникает со знаками препинания,
            //т.к. split их убирает, ищем другое решение
            //foreach (string word in words) if (word[word.Length - 1] != ending) sb.Append(word + " ");
            //Console.WriteLine(sb);

            //Реализация через regex - OK!            
            Regex regex = new Regex("\\w+" + ending + "\\b");            
            text = regex.Replace(text, "");
            Console.WriteLine(text);
        }

        public static string GetLongestWord(string text)
        {
            string LongestWord = "";            
            string[] words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            foreach (string word in words) if (word.Length > LongestWord.Length) LongestWord = word;
            return LongestWord;
        }

        public static void GetAllLongestWords(string text)
        {
            StringBuilder sb = new StringBuilder(text.Length);
            string LongestWord = GetLongestWord(text);
            string[] words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);            
            foreach (string word in words) if (word.Length == LongestWord.Length) sb.Append(word + " ");
            Console.WriteLine("Строка из самых длинных слов в сообщения (из одного слова, если оно единственное):\n" + sb);
        }

        public static void FrequencyAnalysis(string text, string[] sample_words)
        {
            /*БЕЗ использования RegEx, через словарь (как требует методичка)
            //сравниваем каждое слово предложения с каждым элементом словаря, увеличиваем счетчик, если есть совпадение            
            string[] words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, int> dict = new Dictionary<string, int>();
            foreach (string sample in sample_words) dict.Add(sample, 0); //формируем словарь из массива слов
            foreach (string sample in sample_words)
                foreach (string word in words) if (sample == word) dict[sample]++;
            foreach (string sample in dict.Keys) Console.WriteLine(sample + " " + dict[sample]);
            */

            //Через Regex коротко :)
            Console.WriteLine("Частотный анализ текста по словарю:");
            foreach (string sample in sample_words)
                Console.WriteLine($"{sample} - {Regex.Matches(text, "\\W*" + sample + "\\W+", RegexOptions.IgnoreCase).Count} раз");
        }
    }

    internal class Program
    {

        static void Main()
        {
            #region Инициализация переменных
            bool KeepMenu = true;
            #endregion

            while (KeepMenu)
            {
                #region Инициализация меню
                Console.Clear();
                Console.Write("Введитие номер задания от 1 до 4, для выхода введите 0: ");
                int SelectMenu = int.Parse(Console.ReadLine());
                Console.Clear();
                #endregion

                switch (SelectMenu)
                {
                    #region Задача 1
                    case 1:
                        //Проверка корректности логина
                        //от 2 до 10 символов, буквы латинского алфавита или цифры, цифра не может быть первой
                        Console.WriteLine("Введите логин");
                        string login = Console.ReadLine();

                        bool flag1 = false;
                        if (Char.IsDigit(login[0]) == false && login.Length <= 10 && login.Length >= 2)
                        {
                            foreach (char ch in login)
                                if (Char.IsDigit(ch) == true || ch >= 'a' && ch <= 'z' || ch >= 'A' && ch <= 'Z') flag1 = true;
                                else
                                {
                                    flag1 = false;
                                    break;
                                }                            
                        }

                        bool flag2 = false;
                        flag2 = Regex.IsMatch(login, "^[A-Za-z]{1}[0-9A-Za-z]{1,9}$");

                        Console.WriteLine("\nПроверка без использования регулярных выражений");
                        if (flag1) Console.WriteLine("Введенный логин корректен");
                        else Console.WriteLine("Ошибка ввода!");

                        Console.WriteLine("\nПроверка c использованием регулярных выражений");
                        if (flag2) Console.WriteLine("Введенный логин корректен");
                        else Console.WriteLine("Ошибка ввода!");

                        Pause();
                        break;
                    #endregion

                    #region Задача 2
                    case 2:                        
                        string text = "Посадил дед репку. Выросла репка большая-пребольшая. Стал дед репку из земли тянуть: тянет - потянет, вытянуть не может. Позвал дед на помощь бабку. Бабка за дедку, дедка за репку — тянут - потянут, вытянуть не могут. Позвала бабка внучку. Внучка за бабку, бабка за дедку, дедка за репку — тянут - потянут, вытянуть не могут.";

                        Console.WriteLine("Наше сообщение:\n" + text + "\n");
                        Console.WriteLine("Вывод слов, содаржащих не более 4 букв: ");
                        Message.GetWordsOfLength(text, 4);


                        Console.WriteLine("\n\nУдаляем из сообщения слова, заканчивающиеся на а:");
                        Message.RemoveWords(text, 'а');
                        Console.WriteLine();

                        Console.WriteLine("Самое длинное слово в сообщении:\n" + Message.GetLongestWord(text) + "\n");

                        Message.GetAllLongestWords(text);
                        Console.WriteLine();

                        String[] Dictionary = { "дед", "деда", "репка", "реп", "самолет", "тянут", "потянет" };                        
                        Message.FrequencyAnalysis(text, Dictionary);

                        Pause();
                        break;
                    #endregion

                    #region Задача 3
                    case 3:
                        CheckInclusion("trqqq", "qrqqt");
                        Console.WriteLine();
                        CheckInclusion("trqqq", "qrqzqt");
                        Console.WriteLine();
                        CheckInclusion("bloomzzzzz", "ttattta");

                        Pause();
                        break;
                    #endregion

                    #region Задача 4
                    case 4:                        
                        int n = 30; //количество студентов                        
                        string[] students = new string[n];
                        Random random = new Random();

                        //Генерируем ФИО студентов и их оценки
                        Console.WriteLine("Список студентов с оценками:");
                        for (int i = 0; i < n; i++)
                        {
                            students[i] = $"Фамилия{i+1} Имя{i+1} {random.Next(1,6)} {random.Next(1, 6)} {random.Next(1, 6)}";                                                        
                        }

                        //Создаем массивы для парсинга туда информации о студентах
                        string[] name = new string[n];
                        double[] average = new double[n];

                        string[] StudentSplit = new string[5];
                        int j = 0;

                        //парсим информацию
                        foreach (string student in students)
                        {
                            StudentSplit = student.Split(new[] { ' ' });
                            name[j] = StudentSplit[0] + " " + StudentSplit[1];
                            average[j] = (Double.Parse(StudentSplit[2]) + Double.Parse(StudentSplit[3])+ Double.Parse(StudentSplit[4]))/3;                            
                            Console.WriteLine($"{student, -25}    ср. балл {average[j]:N2}");
                            j++;
                        }
                        
                        //копируем массив и сортируем для поиска 3 последних значений
                        double[] averageCopy = new double[n];
                        average.CopyTo(averageCopy, 0);                       
                        Array.Sort(averageCopy);

                        double minimal = averageCopy[0];
                        int results = 1;            
                        for (int i = 1;i < n; i++)
                        {
                            if (results < 3)
                            {
                                minimal = averageCopy[i];
                                results++;
                            }
                            else break;                            
                        }
                        
                        Console.WriteLine("\nХудшие студенты:");
                        for (int i = 0; i < n; i++)
                            if (average[i] <= minimal) Console.WriteLine($"{name[i]} средний балл {average[i]:N2}");

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

        static void CheckInclusion(string a, string b)
        {            
            Dictionary<char, int> dictA = new Dictionary<char, int>();
            foreach (char ch in a)
            {
                if (dictA.ContainsKey(ch)) dictA[ch]++;
                else dictA.Add(ch, 1);               
            }
            

            Dictionary<char, int> dictB = new Dictionary<char, int>();
            foreach (char ch in b)
            {
                if (dictB.ContainsKey(ch)) dictB[ch]++;
                else dictB.Add(ch, 1);                
            }
            Console.Write($"Состав букв слова {a}:\n");
            foreach (char ch in dictA.Keys) Console.Write(ch + ": " + dictA[ch] + "  ");            
            Console.Write($"\nСостав букв слова {b}:\n");
            foreach (char ch in dictB.Keys) Console.Write(ch + ": " + dictB[ch]+ "  ");

            //два флаг, что словарь a входит в b, и что b входит в a
            bool flag1 = false;
            bool flag2 = false;

            foreach (char ch in dictA.Keys)
            {
                if (dictB.ContainsKey(ch))
                {
                    if (dictA[ch] == dictB[ch]) flag1 = true;
                    else
                    {
                        flag1 = false;
                        break;
                    }
                }
                else
                {
                    flag1 = false;
                    break;
                }
            }

            foreach (char ch in dictB.Keys)
            {
                if (dictA.ContainsKey(ch))
                {
                    if (dictA[ch] == dictB[ch]) flag2 = true;
                    else
                    {
                        flag2 = false;
                        break;
                    }
                }
                else
                {
                    flag2 = false;
                    break;
                }
            }

            if (flag1 && flag2) Console.WriteLine($"\n{a} явлется перестановкой {b}.");
            else Console.WriteLine($"\n{a} НЕ являюется перестановкой {b}.");
        }

    }
}
