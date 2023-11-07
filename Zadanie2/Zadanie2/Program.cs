using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Zadanie2
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
            int[] copy = new int[array.Length];
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
                Console.WriteLine("Введите номер, какую сортировку применить: ");
                Console.WriteLine("1 - Сортировка вставками");
                Console.WriteLine("2 - Сортировка выбором");
                Console.WriteLine("3 - Сортировка слиянием");
                Console.WriteLine("4 - Быстрая сортировка");
                int choose = Convert.ToInt32(Console.ReadLine());

                array.CopyTo(copy, 0);

                if (choose == 1)
                {
                    clock.Start();
                    InsertionSort(copy);
                    clock.Stop();

                    Console.WriteLine("Сортированный массив: ");
                    foreach (var v in copy)
                        Console.Write(v + " ");
                    Console.WriteLine("");

                    Console.WriteLine("Время выполнения: " + clock.Elapsed);
                    clock.Reset();
                }
                else if (choose == 2)
                {
                    clock.Start();
                    copy = ViborSort(copy);
                    clock.Stop();

                    Console.WriteLine("Сортированный массив: ");
                    foreach (var v in copy)
                        Console.Write(v + " ");
                    Console.WriteLine("");

                    Console.WriteLine("Время выполнения: " + clock.Elapsed);
                    clock.Reset();
                }
                else if (choose == 3)
                {
                    clock.Start();
                    copy = MergeSort(copy);
                    clock.Stop();

                    Console.WriteLine("Сортированный массив: ");
                    foreach (var v in copy)
                        Console.Write(v + " ");
                    Console.WriteLine("");

                    Console.WriteLine("Время выполнения: " + clock.Elapsed);
                    clock.Reset();
                }
                else if(choose == 4)
                {
                    clock.Start();
                    copy = QuickSort(copy);
                    clock.Stop();

                    Console.WriteLine("Сортированный массив: ");
                    foreach (var v in copy)
                        Console.Write(v + " ");
                    Console.WriteLine("");

                    Console.WriteLine("Время выполнения: " + clock.Elapsed);
                    clock.Reset();
                }
                else
                {
                    Console.WriteLine("Вы ввели некоректное значение");
                }

                Console.WriteLine("Продолжить действия с массивом? Введите yes/no");
                string otvet = Console.ReadLine();    
                if(otvet == "no")
                {
                    s = false;
                }
            }
        }

        /*Использованные методы*/
        static void Swap(int[] array, int i, int j) //меняет 2 элемента массива местами
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
        static void InsertionSort(int[] inArray)
        {
            int x;
            int j;
            for (int i = 1; i < inArray.Length; i++)
            {
                x = inArray[i];
                j = i;
                while (j > 0 && inArray[j - 1] > x)
                {
                    Swap(inArray, j, j - 1);
                    j -= 1;
                }
                inArray[j] = x;
            }
        }

        static int[] ViborSort(int[] mas) //сортировка выбором
        {
            for(int i = 0; i < mas.Length - 1; i++)
            {
                /*поиск минимального числа*/
                int min = i;
                for(int j = i + 1; j < mas.Length; j++)
                {
                    if (mas[j] < mas[min])
                    {
                        min = j;
                    }
                }
                /*обмен элементов*/
                int temp = mas[min];
                mas[min] = mas[i];
                mas[i] = temp;
            }
            return mas;
        }

        //метод для слияния массивов
        static void Merge(int[] array, int lowIndex, int middleIndex, int highIndex)
        {
            var left = lowIndex;
            var right = middleIndex + 1;
            var tempArray = new int[highIndex - lowIndex + 1];
            var index = 0;

            while ((left <= middleIndex) && (right <= highIndex))
            {
                if (array[left] < array[right])
                {
                    tempArray[index] = array[left];
                    left++;
                }
                else
                {
                    tempArray[index] = array[right];
                    right++;
                }

                index++;
            }

            for (var i = left; i <= middleIndex; i++)
            {
                tempArray[index] = array[i];
                index++;
            }

            for (var i = right; i <= highIndex; i++)
            {
                tempArray[index] = array[i];
                index++;
            }

            for (var i = 0; i < tempArray.Length; i++)
            {
                array[lowIndex + i] = tempArray[i];
            }
        }

        //сортировка слиянием
        static int[] MergeSort(int[] array, int lowIndex, int highIndex)
        {
            if (lowIndex < highIndex)
            {
                var middleIndex = (lowIndex + highIndex) / 2;
                MergeSort(array, lowIndex, middleIndex);
                MergeSort(array, middleIndex + 1, highIndex);
                Merge(array, lowIndex, middleIndex, highIndex);
            }

            return array;
        }

        static int[] MergeSort(int[] array)
        {
            return MergeSort(array, 0, array.Length - 1);
        }

        //метод для обмена элементов массива
        static void Swap(ref int x, ref int y)
        {
            var t = x;
            x = y;
            y = t;
        }

        //метод возвращающий индекс опорного элемента
        static int Partition(int[] array, int minIndex, int maxIndex)
        {
            var pivot = minIndex - 1;
            for (var i = minIndex; i < maxIndex; i++)
            {
                if (array[i] < array[maxIndex])
                {
                    pivot++;
                    Swap(ref array[pivot], ref array[i]);
                }
            }

            pivot++;
            Swap(ref array[pivot], ref array[maxIndex]);
            return pivot;
        }

        //быстрая сортировка
        static int[] QuickSort(int[] array, int minIndex, int maxIndex)
        {
            if (minIndex >= maxIndex)
            {
                return array;
            }

            var pivotIndex = Partition(array, minIndex, maxIndex);
            QuickSort(array, minIndex, pivotIndex - 1);
            QuickSort(array, pivotIndex + 1, maxIndex);

            return array;
        }

        static int[] QuickSort(int[] array)
        {
            return QuickSort(array, 0, array.Length - 1);
        }

    }
}
