using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Utils
{
    public class UserMenu
    {
        public static void DisplayMenu()
        {

            bool exitMenu = false;

            while (!exitMenu)
            {
                int selector = int.Parse(Console.ReadLine());
                switch (selector)
                {
                    case 1:
                        Console.WriteLine("1");
                        break;

                    case 2:
                        Console.WriteLine("2");
                        break;

                    case 3:
                        Console.WriteLine("3");
                        break;

                    case 0:
                        Console.WriteLine("Выход из меню");
                        exitMenu = true;
                        break;

                    default:
                        Console.WriteLine("Ошибка ввода, попробуйте снова");
                        break;

                }
            }

        }

        public static void Pause()
        {
            Console.WriteLine("Нажмите любую клавишу чтобы продолжить");
            Console.ReadKey();
        }

    }
}
