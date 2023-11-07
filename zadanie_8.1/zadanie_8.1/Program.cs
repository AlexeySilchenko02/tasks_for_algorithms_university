using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace zadanie_8._1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Перевод римских чисел в арабские или наоборот 1/2");
            int otvet = Convert.ToInt32(Console.ReadLine());
            if(otvet == 1)
            {
                bool stop = true;
                while (stop)
                {
                    Console.WriteLine("Введите римское число: ");
                    string rim = Console.ReadLine();
                    string pattern = @"^M{0,4}(CM|CD|D?C{0,3})(XC|XL|L?X{0,3})(IX|IV|V?I{0,3})$";
                    Regex regex = new Regex(pattern);
                    bool found = regex.IsMatch(rim);
                    if (found)
                    {
                        Console.WriteLine(ConvertArab(rim));
                    }
                    else
                    {
                        Console.WriteLine("Вы ввели некоректное римское число!");
                    }
                    Console.WriteLine("Перевести еще какие-то числа 1/2");
                    otvet = Convert.ToInt32(Console.ReadLine());
                    if(otvet == 2)
                    {
                        stop = false;
                    }
                }
            }
            else if(otvet == 2)
            {
                int[] arab = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
                string[] rim = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };

                Console.WriteLine("Введите арабское число: ");
                int input = Convert.ToInt32(Console.ReadLine());
                int i = 0;
                string output = "";
                while (input > 0)
                {
                    if (arab[i] <= input) //если число из массива арабских меньше или равно введенному
                    {
                        input = input - arab[i];
                        output = output + rim[i];
                    }
                    else i++;

                }

                Console.WriteLine("Римское число = " + output);
            }
           

        }
        public static int ConvertArab(string s)
        {
            int result = 0;
            int cur = 0;
            Dictionary<int, char> ra = new Dictionary<int, char>
            { { 1000, 'M' },  { 500, 'D' },  { 100, 'C' },
                            { 50 , 'L' },    { 10 , 'X' },
                           { 5  , 'V' },   { 1  , 'I' } };
            int prev = 0;
            for(int i = s.Length - 1; i >= 0; i--)
            {
                cur = ra.Where(x => x.Value == s[i]).FirstOrDefault().Key;
                if (cur < prev)
                {
                    result -= cur;
                }
                else
                {
                    result += cur;
                }
                prev = cur;
            }
            return result;
        }
    }
}
