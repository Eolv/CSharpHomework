/*
Студент: Фишелев Олег AR/VR

3. Переделать программу Пример использования коллекций для решения следующих задач:

а) Подсчитать количество студентов учащихся на 5 и 6 курсах;
б) подсчитать сколько студентов в возрасте от 18 до 20 лет на каком курсе учатся (*частотный массив);
в) отсортировать список по возрасту студента;
г) *отсортировать список по курсу и возрасту студента; 
*/

using System;
using System.Collections.Generic;
using System.IO;

namespace Task3
{
    class Student
    {
        public string lastName;
        public string firstName;
        public string university;
        public string faculty;
        public string department;
        public int course;
        public int age;
        public int group;
        public string city;
        
        // Создаем конструктор
        public Student(string firstName, string lastName, string university, string faculty, string department, int age, int course, int group, string city)
        {
            this.lastName = lastName;
            this.firstName = firstName;
            this.university = university;
            this.faculty = faculty;
            this.department = department;
            this.course = course;
            this.age = age;
            this.group = group;
            this.city = city;
        }
    }
    class Program
    {
        /// <summary>
        /// Метод для сравнения по возрасту
        /// </summary>
        /// <param name="st1"></param>
        /// <param name="st2"></param>
        /// <returns></returns>
        static int MyDelegat(Student st1, Student st2) // Создаем метод для сравнения для экземпляров
        {
            if (st1.age > st2.age) return 1;
            if (st1.age < st2.age) return -1;
            return 0;
        }

        /// <summary>
        /// Метод для сравнения по курсу и возрасту
        /// </summary>
        /// <param name="st1"></param>
        /// <param name="st2"></param>
        /// <returns></returns>
        static int MyDelegat2(Student st1, Student st2) // Создаем метод для сравнения для экземпляров
        {
            if (st1.course > st2.course) return 1;
            if (st1.course < st2.course) return -1;
            if (st1.course == st2.course)
            {
                if (st1.age > st2.age) return 1;
                if (st1.age < st2.age) return -1;
            }
            return 0;
        }

        static void Main(string[] args)
        {
            int bakalavr = 0;
            int magistr = 0;
            List<Student> list = new List<Student>(); // Создаем список студентов
            DateTime dt = DateTime.Now;
            StreamReader sr = new StreamReader("students.csv");
            while (!sr.EndOfStream)
            {
                try
                {
                    string[] s = sr.ReadLine().Split(';');                    
                    list.Add(new Student(s[0], s[1], s[2], s[3], s[4], int.Parse(s[5]), int.Parse(s[6]), int.Parse(s[7]), s[8]));
                    if (int.Parse(s[6]) < 5) bakalavr++; else magistr++;
                }
                catch (Exception e)

                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Ошибка!ESC - прекратить выполнение программы");
                    // Выход из Main
                    if (Console.ReadKey().Key == ConsoleKey.Escape) return;
                }
            }
            sr.Close();

            
            Console.WriteLine("Всего студентов: " + list.Count);
            Console.WriteLine("Магистров:{0}", bakalavr);
            Console.WriteLine($"Бакалавров:{magistr}");

            int n = 0;
            foreach (Student student in list) if (student.course == 5) n++;
            Console.WriteLine($"\nСтудентов 5 курса: {n}");

            n = 0;
            foreach (Student student in list) if (student.course == 6) n++;
            Console.WriteLine($"Студентов 6 курса: {n}\n");

            int[] ICourse = new int[7];            
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].age >= 18 && list[i].age <= 20) ICourse[list[i].course]++;
            }

            Console.WriteLine("Распределение студентов 18-20 лет по курсам:");
            n = 0;
            for (int i = 0; i < ICourse.Length; i++)
                if (ICourse[i] != 0)
                {
                    Console.WriteLine($"{i} курс: {ICourse[i]}");
                    n += ICourse[i];
                }
            Console.WriteLine("\nВсего студентов 18-20 лет: " + n);

            list.Sort(new Comparison<Student>(MyDelegat));
            Console.WriteLine("\nСписок студентов, отсортированный по возрасту: ");
            foreach (var v in list) Console.WriteLine($"{v.firstName} {v.lastName} {v.age}");

            list.Sort(new Comparison<Student>(MyDelegat2));
            Console.WriteLine("\nСписок студентов, отсортированный по курсу и возрасту: ");
            foreach (var v in list) Console.WriteLine($"{v.firstName} {v.lastName} {v.course} {v.age}");
            Console.WriteLine("\nВремя выполнения программы " + (DateTime.Now - dt));
            Console.ReadKey();
        }
    }
}