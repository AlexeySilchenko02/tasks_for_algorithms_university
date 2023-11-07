using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Zadanie1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool s = true;
            Stopwatch clock = new Stopwatch();
            Console.Write("Введите размер массива: ");
            int array_size = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine(array_size);
            int[] array = new int[array_size];
            Random random = new Random();

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(101);
            }

            Console.WriteLine("Сгенерированный массив: ");
            foreach (var v in array)
                Console.Write(v + " ");
            Console.WriteLine("");

            while (s)
            {
                Console.WriteLine("Выберете что хотите сделать с массивом:");
                Console.WriteLine("Введите 1 - Если нужно найти элемент");
                Console.WriteLine("Введите 2 - Если нужно вставить элемент");
                Console.WriteLine("Введите 3 - Если нужно удалить элемент");
                int choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 1)
                {
                    Console.Write("Введите элемент, который мы будем искать: ");
                    int element = Convert.ToInt32(Console.ReadLine());
                    clock.Start();
                    Console.WriteLine("Индекс элемента: " + Search(array, element));
                    clock.Stop();
                    Console.WriteLine("Время выполнения: " + clock.Elapsed);
                    clock.Reset();
                    Console.WriteLine("Продолжить действия с несортированным массивом? Введите yes/no");
                    string otvet = Console.ReadLine();
                    if(otvet == "no")
                    {
                        s = false;
                    }
                }

                else if(choice == 2)
                {
                    Console.WriteLine("Выберете как хотите вставить элемент в массив");
                    Console.WriteLine("Введите 1 - по индексу");
                    Console.WriteLine("Введите 2 - в начало");
                    Console.WriteLine("Введите 3 - в конец");
                    int ch = Convert.ToInt32(Console.ReadLine());
                    if(ch == 1)
                    {
                        Console.Write("Введите желаемый индекс: ");
                        int index = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("");
                        Console.Write("Введите число: ");
                        int value = Convert.ToInt32(Console.ReadLine());
                        clock.Start();
                        Insert(ref array, value, index);
                        clock.Stop();

                    }
                    else if(ch == 2)
                    {
                        Console.Write("Введите число: ");
                        int value = Convert.ToInt32(Console.ReadLine());
                        clock.Start();
                        InsertFirs(ref array, value);
                        clock.Stop();
                    }
                    else if (ch == 3)
                    {
                        Console.Write("Введите число: ");
                        int value = Convert.ToInt32(Console.ReadLine());
                        clock.Start();
                        InsertLast(ref array, value);
                        clock.Stop();
                    }
                    else
                    {
                        Console.WriteLine("Вы ввели некоректное значение!");
                    }
                    Console.WriteLine("");
                    foreach (var v in array)
                        Console.Write(v + " ");
                    Console.WriteLine("");

                    Console.WriteLine("Время выполнения: " + clock.Elapsed);
                    clock.Reset();

                    Console.WriteLine("Продолжить действия с несортированным массивом? Введите yes/no");
                    string otvet = Console.ReadLine();
                    if (otvet == "no")
                    {
                        s = false;
                    }
                }

                else if (choice == 3)
                {

                    Console.WriteLine("Выберете как хотите удалить элемент из массива");
                    Console.WriteLine("Введите 1 - по индексу");
                    Console.WriteLine("Введите 2 - из начала");
                    Console.WriteLine("Введите 3 - из конца");
                    int ch = Convert.ToInt32(Console.ReadLine());
                    if (ch == 1)
                    {
                        Console.Write("Введите желаемый индекс: ");
                        int index = Convert.ToInt32(Console.ReadLine());
                        clock.Start();
                        RemoveAt(ref array, index);
                        clock.Stop();

                    }
                    else if (ch == 2)
                    {
                        clock.Start();
                        RemoveStart(ref array);
                        clock.Stop();
                    }
                    else if (ch == 3)
                    {
                        clock.Start();
                        RemoveEnd(ref array);
                        clock.Stop();
                    }
                    else
                    {
                        Console.WriteLine("Вы ввели некоректное значение!");
                    }
                    Console.WriteLine("");
                    foreach (var v in array)
                        Console.Write(v + " ");
                    Console.WriteLine("");

                    Console.WriteLine("Время выполнения: " + clock.Elapsed);
                    clock.Reset();

                    Console.WriteLine("Продолжить действия с несортированным массивом? Введите yes/no");
                    string otvet = Console.ReadLine();
                    if (otvet == "no")
                    {
                        s = false;
                    }
                }

                else
                {
                    Console.WriteLine("Вы ввели некоректное значение!");
                }
            }

            Console.WriteLine("Выполняем сортировку массива....");
            clock.Start();
            BubleSort(array);
            clock.Stop();

            Console.WriteLine("Сортированный массив: ");
            foreach (var v in array)
                Console.Write(v + " ");
            Console.WriteLine("");

            Console.WriteLine("Время выполнения: " + clock.Elapsed);
            clock.Reset();
            s = true;
            while (s) //действия с сортированным массивом
            {
                Console.WriteLine("Выберете что хотите сделать с сортированным массивом:");
                Console.WriteLine("Введите 1 - Функция поиска");
                Console.WriteLine("Введите 2 - Двоичный поиск");
                Console.WriteLine("Введите 3 - Вставка");
                Console.WriteLine("Введите 4 - Удаление");
                int choice = Convert.ToInt32(Console.ReadLine());
                if(choice == 1)
                {
                    Console.Write("Введите элемент, который мы будем искать: ");
                    int element = Convert.ToInt32(Console.ReadLine());
                    clock.Start();
                    Console.WriteLine("Индекс элемента: " + Search(array, element));
                    clock.Stop();
                    Console.WriteLine("Время выполнения: " + clock.Elapsed);
                    clock.Reset();
                    Console.WriteLine("Продолжить действия с несортированным массивом? Введите yes/no");
                    string otvet_1 = Console.ReadLine();
                    if (otvet_1 == "no")
                    {
                        s = false;
                    }
                }
                else if(choice == 2)
                {
                    Console.WriteLine("Введите число которое мы будем искать: ");
                    int k = Convert.ToInt32(Console.ReadLine());
                    clock.Start();
                    var searchResult = BinarySearch(array, k, 0, array.Length - 1);
                    if (searchResult < 0)
                    {
                        Console.WriteLine("Элемент со значением {0} не найден", k);
                    }
                    else
                    {
                        Console.WriteLine("Элемент найден. Индекс элемента со значением {0} равен {1}", k, searchResult);
                    }
                    clock.Stop();
                    Console.WriteLine("Время выполнения: " + clock.Elapsed);
                    clock.Reset();
                    Console.WriteLine("Продолжить действия с несортированным массивом? Введите yes/no");
                    string otvet_1 = Console.ReadLine();
                    if (otvet_1 == "no")
                    {
                        s = false;
                    }

                }
                else if(choice == 3)
                {
                    Console.WriteLine("Введите значение которое хотите вставить: ");
                    int vstav = Convert.ToInt32(Console.ReadLine());
                    clock.Start();
                    InsertLast(ref array, vstav);
                    array = BubleSort(array);
                    clock.Stop();

                    Console.WriteLine("");
                    foreach (var v in array)
                        Console.Write(v + " ");
                    Console.WriteLine("");

                    Console.WriteLine("Время выполнения: " + clock.Elapsed);
                    clock.Reset();

                    Console.WriteLine("Продолжить действия с сортированным массивом? Введите yes/no");
                    string otvet_1 = Console.ReadLine();
                    if (otvet_1 == "no")
                    {
                        s = false;
                    }

                }
                else if(choice == 4)
                {
                    Console.Write("Введите желаемый индекс: ");
                    int index = Convert.ToInt32(Console.ReadLine());
                    clock.Start();
                    RemoveAt(ref array, index);
                    clock.Stop();

                    Console.WriteLine("");
                    foreach (var v in array)
                        Console.Write(v + " ");
                    Console.WriteLine("");

                    Console.WriteLine("Время выполнения: " + clock.Elapsed);
                    clock.Reset();

                    Console.WriteLine("Продолжить действия с сортированным массивом? Введите yes/no");
                    string otvet_1 = Console.ReadLine();
                    if (otvet_1 == "no")
                    {
                        s = false;
                    }
                }
                else
                {
                    Console.WriteLine("Вы ввели некоректное значение!");
                }
            }

        }

        // использованные методы
        public static string Search(int[] ar, int value)
        {
            string s = "Данного элемнта в массиве не найдено";
            Stopwatch stopwatch = new Stopwatch();
            for (int i = 0; i < ar.Length; i++)
            {
                if (ar[i] == value)
                {
                    s = "";
                    s += i;
                    return s;
                }
            }
            return s;
        }

        public static void Insert(ref int[] ar, int value, int index)
        {
            int[] newArray = new int[ar.Length + 1];

            newArray[index] = value;

            for(int i = 0; i < index; i++) //переписываем элементы из старого масива в новый до индекса
            {
                newArray[i] = ar[i];
            }

            for(int i = index; i < ar.Length; i++) //переписываем после индекса
            {
                newArray[i + 1] = ar[i];
            }
            ar = newArray;
        }

        public static void InsertFirs(ref int[] ar, int value)
        {
            Insert(ref ar, value, 0); //вставляем в начало
        }

        public static void InsertLast(ref int[] ar, int value)
        {
            Insert(ref ar, value, ar.Length); //вставляем в конец
        }
        
        public static void RemoveAt(ref int[] ar, int index)
        {
            int[] newArray = new int[ar.Length - 1];

            for (int i = 0; i < index; i++) //переписываем элементы из старого масива в новый до индекса
            {
                newArray[i] = ar[i];
            }

            for (int i = index + 1; i < ar.Length; i++) //переписываем после индекса игнорируя сам индекс
            {
                newArray[i - 1] = ar[i]; // -, т.к. сдвигаются все элементы на 1
            }
            ar = newArray;
        }

        public static void RemoveStart(ref int[] ar) //удаление элемента в начале
        {
            RemoveAt(ref ar, 0);
        }

        public static void RemoveEnd(ref int[] ar) //удаление элемента в конце
        {
            RemoveAt(ref ar, ar.Length - 1);
        }

        public static int[] BubleSort(int[] mas) //сортировка пузырьком
        {
            int temp;
            for(int i = 0; i < mas.Length; i++)
            {
                for(int j = 0; j < mas.Length; j++)
                {
                    if(mas[i] < mas[j])
                    {
                        temp = mas[i];
                        mas[i] = mas[j];
                        mas[j] = temp;
                    }
                }
            }
            return mas;
        }

        static int BinarySearch(int[] array, int searchedValue, int first, int last)
        {
            //границы сошлись
            if (first > last)
            {
                //элемент не найден
                return -1;
            }

            //средний индекс подмассива
            var middle = (first + last) / 2;
            //значение в средине подмассива
            var middleValue = array[middle];

            if (middleValue == searchedValue)
            {
                return middle;
            }
            else
            {
                if (middleValue > searchedValue)
                {
                    //рекурсивный вызов поиска для левого подмассива
                    return BinarySearch(array, searchedValue, first, middle - 1);
                }
                else
                {
                    //рекурсивный вызов поиска для правого подмассива
                    return BinarySearch(array, searchedValue, middle + 1, last);
                }
            }
        }
    }
}
