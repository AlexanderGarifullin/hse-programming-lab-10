using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task10
{
    public class UI
    {
        public static double Input(double min, double max, string msg = "")
        {
            double number;
            bool isRead;
            do
            {
                Console.WriteLine(msg);
                isRead = double.TryParse(Console.ReadLine(), out number);
                if (!isRead)
                {
                    Console.WriteLine("Ошибка! Не правильно введено число!");
                }
                else
                {
                    if (number < min || number > max)
                    {
                        Console.WriteLine("Ошибка! Число не попадает в заданный диапазон!");
                        isRead = false;
                    }
                }
            } while (!isRead);
            return number;
        }
        public static int Input(int min, int max, string msg = "")
        {
            int number;
            bool isRead;
            do
            {
                Console.WriteLine(msg);
                isRead = int.TryParse(Console.ReadLine(), out number);
                if (!isRead)
                {
                    Console.WriteLine("Ошибка! Не правильно введено число!");
                }
                else
                {
                    if (number < min || number > max)
                    {
                        Console.WriteLine("Ошибка! Число не попадает в заданный диапазон!");
                        isRead = false;
                    }
                }
            } while (!isRead);
            return number;
        }
    }
}
