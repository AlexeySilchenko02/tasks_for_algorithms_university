using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie7_1
{
    public class Program
    {
        static void Main(string[] args)
        {
            // задаем начальные данные:
            int size = 0;
            bool stop = true;
            int vibor = 0;
            Console.WriteLine("Задайте размер для пирамиды");
            size = Convert.ToInt32(Console.ReadLine());
            Heap heap = new Heap(size+5);
            Random random = new Random();
            for (int i = 0; i < size; i++)
            {
                heap.insertNode(random.Next(101));
            }
            heap.printHeap();
            while (stop)
            {
                Console.WriteLine("Введите действие, которое хотите выполнить: ");
                Console.WriteLine("1 - вставить элемент в пирамиду");
                Console.WriteLine("2 - удалить элемент");
                Console.WriteLine("3 - замена элемента");
                Console.WriteLine("4 - вывести пирамиду");
                vibor = Convert.ToInt32(Console.ReadLine());
                if(vibor == 1)
                {
                    Console.WriteLine("введите элемент: ");
                    heap.insertNode(Convert.ToInt32(Console.ReadLine()));
                    heap.printHeap();
                }
                else if(vibor == 2)
                {
                    Console.WriteLine("введите индекс элемента: ");
                    heap.removeNode(Convert.ToInt32(Console.ReadLine()));
                    heap.printHeap();
                }
                else if(vibor == 3)
                {
                    int index = 0;
                    int value = 0;
                    Console.WriteLine("введите индекс элемента ");
                    index = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("введите значение ");
                    value = Convert.ToInt32(Console.ReadLine());
                    heap.changeNode(index, value);
                    heap.printHeap();
                }
                else if(vibor == 4)
                {
                    heap.printHeap();
                }
                Console.WriteLine("Продолжить действия с пирамидой? 1/0");
                vibor = Convert.ToInt32(Console.ReadLine());
                if(vibor != 1)
                {
                    stop = false;
                }
            }

            Console.Write("Введите размер массива: ");
            int array_size = Convert.ToInt32(Console.ReadLine());
            int[] array = new int[array_size];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(101);
            }

            Console.WriteLine("Сгенерированный массив: ");
            foreach (var v in array)
                Console.Write(v + " ");
            Console.WriteLine("");

            HeapSort ob = new HeapSort();
            ob.sort(array);

            Console.WriteLine("Сортированный массив");
            ob.printArray(array);

        }
    }
}
