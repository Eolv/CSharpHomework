﻿/*
Фишелев Олег AR/VR

1. С помощью рефлексии выведите все свойства структуры DateTime
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{ 
    class Program
    {
        static void Main()
        {
            DateTime now = DateTime.Now;
            Console.WriteLine($"Все свойства структуры DateTime\n----------------------------------------------\n{"Название свойства", 20}{"Значение для now", 25}");

            //Получаем список всех свойств структуры DateTime с помощью метода GetProperties()
            foreach (var property in typeof(DateTime).GetProperties())
                //Для каждого свойства выводим его название и значение этого свойства в переменной now
                Console.WriteLine($"{property.Name, 20}{property.GetValue(now), 25}");            
            
            Console.ReadKey();
        }
    }
}