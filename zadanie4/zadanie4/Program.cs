using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace zadanie4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool stop = true;
            Console.Write("Введите размер массива: ");
            int array_size = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine(array_size);
            int[] array = new int[array_size];
            List<int> arrayList = new List<int>();
            Random random = new Random();

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(101);
            }
            arrayList.AddRange(array);

            Console.WriteLine("Сгенерированный массив: ");
            foreach (var v in array)
                Console.Write(v + " ");
            Console.WriteLine("");
            Console.WriteLine("//////////");
            Console.WriteLine("Сгенерированный список: ");
            foreach (var v in arrayList)
                Console.Write(v + " ");
            Console.WriteLine("");

            Console.WriteLine("Поменять элементы местами в массиве или списке? или не менять ничего 1/2/3");
            int otvet = Convert.ToInt32(Console.ReadLine());
            if (otvet == 1)
            {
                Console.WriteLine("Введите значение первого элемента: ");
                int first = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите значение второго элемента: ");
                int second = Convert.ToInt32(Console.ReadLine());
                var first_index = Search(array, first);
                var second_index = Search(array, second);
                array[first_index] = second;
                array[second_index] = first;
                foreach (var v in array)
                    Console.Write(v + " ");
            }
            else if(otvet == 2)
            {
                Console.WriteLine("Введите значение первого элемента: ");
                int first = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите значение второго элемента: ");
                int second = Convert.ToInt32(Console.ReadLine());
                int first_index = arrayList.IndexOf(first);
                int second_index = arrayList.IndexOf(second);
                arrayList[first_index] = second;
                arrayList[second_index] = first;
                foreach (var v in arrayList)
                    Console.Write(v + " ");
                Console.WriteLine("");
            }

            Console.WriteLine("Выберите какой тип списка создать?");
            Console.WriteLine("1 - Связный");
            Console.WriteLine("2 - Двусвязный");
            Console.WriteLine("3 - двусторонний");
            int otvet_2 = Convert.ToInt32(Console.ReadLine());
            if (otvet_2 == 1)
            {
                int ot = 0;
                int elem = 0;
                LinkedList<int> numbersList = new LinkedList<int>();
                numbersList.PrintList(numbersList);
                foreach(int v in arrayList)
                {
                    numbersList.Add(v);
                }
                numbersList.PrintList(numbersList);
                while (stop) { 
                    Console.WriteLine("Выберете какое действие сделать со списокм");
                    Console.WriteLine("1 - вставить элемент");
                    Console.WriteLine("2 - удалить элемент");
                    Console.WriteLine("3 - найти элемент");
                    Console.WriteLine("4 - движение по списку");
                    Console.WriteLine("5 - отсортировать список");
                    int s = Convert.ToInt32(Console.ReadLine());


                    if(s == 1)
                    {
                        Console.WriteLine("Введите элемент, который хотите вставить: ");
                        elem = Convert.ToInt32(Console.ReadLine());
                        numbersList.Add(elem);
                        numbersList.PrintList(numbersList);
                    }
                    else if(s == 2)
                    {
                        Console.WriteLine("Введите элемент, который хотите удалить: ");
                        elem = Convert.ToInt32(Console.ReadLine());
                        numbersList.Remove(numbersList.Find(elem));
                        Console.WriteLine();
                        numbersList.PrintList(numbersList);
                    }
                    else if(s == 3)
                    {
                        Console.WriteLine("Найти элемент по индексу или по значению? 1/2");
                        ot = Convert.ToInt32(Console.ReadLine());
                        if(ot == 1)
                        {
                            Console.WriteLine("Введите индекс элемента который вы ищите: ");
                            elem = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine(numbersList.FindFromIndex(elem));
                        }
                        else if(ot == 2)
                        {
                            Console.WriteLine("Введите значение элемента который вы ищите: ");
                            elem = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine(numbersList.FindFromValue(elem));
                        }
                    }
                    else if(s == 4)
                    {
                        Console.WriteLine("Введите с какой позиции вы хотите начать движение");
                        Console.WriteLine("1 - С начала списка");
                        Console.WriteLine("2 - С выбранного элемента");
                        ot = Convert.ToInt32(Console.ReadLine());
                        if( ot == 1)
                        {
                            Console.WriteLine("Введите сколько раз перейти к следующему элементу: ");
                            elem = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine(numbersList.MoveNextStart(elem));
                        }
                        else if( ot == 2)
                        {
                            int shag = 0;
                            Console.WriteLine("Введите начальный элемент: ");
                            elem = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Введите шаг: ");
                            shag = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine(numbersList.MoveNext(numbersList.Find(elem), shag));
                        }
                    }
                    else if(s == 5)
                    {
                        Console.WriteLine("Список до сортировки: ");
                        numbersList.PrintList(numbersList);
                        Console.WriteLine("Список после сортировки: ");
                        numbersList = numbersList.Sort(numbersList);
                        numbersList.PrintList(numbersList);
                    }

                    Console.WriteLine("Продолжить действия с связным списком? 1/0");
                    ot = Convert.ToInt32(Console.ReadLine());
                    if(ot == 0)
                    {
                        stop = false;
                    }

                }
            }
            else if(otvet_2 == 2)
            {
                int element = 0;
                int s = 0;
                int ot = 0;
                DoublyLinkedList<int> linkedList = new DoublyLinkedList<int>();
                foreach (int v in arrayList)
                {
                    linkedList.Add(v);
                }
                linkedList.Print(linkedList);
                Console.WriteLine("");
                while (stop)
                {
                    Console.WriteLine("Выберете какое действие сделать со списокм");
                    Console.WriteLine("1 - вставить элемент");
                    Console.WriteLine("2 - удалить элемент");
                    Console.WriteLine("3 - найти элемент");
                    Console.WriteLine("4 - движение по списку");
                    Console.WriteLine("5 - отсортировать список");
                    s = Convert.ToInt32(Console.ReadLine());
                    if(s == 1)
                    {
                        Console.WriteLine("Вставить элемент в начало списка или в конец? 1/2");
                        ot = Convert.ToInt32(Console.ReadLine());
                        if( ot == 1)
                        {
                            Console.WriteLine("Введите элемент для вставки: ");
                            element = Convert.ToInt32(Console.ReadLine());
                            linkedList.AddFirst(element);
                            linkedList.Print(linkedList);
                        }
                        else if(s == 2)
                        {
                            Console.WriteLine("Введите элемент для вставки: ");
                            element = Convert.ToInt32(Console.ReadLine());
                            linkedList.Add(element);
                            linkedList.Print(linkedList);
                        }
                    }
                    else if(s == 2)
                    {
                        Console.WriteLine("Введите элемент, который хотите удалить: ");
                        element = Convert.ToInt32(Console.ReadLine());
                        linkedList.Remove(element);
                        linkedList.Print(linkedList);
                    }
                    else if( s == 3)
                    {
                        Console.WriteLine("Найти по индексу или по значению 1/2");
                        ot = Convert.ToInt32(Console.ReadLine());
                        if(ot == 1)
                        {
                            Console.WriteLine("Введите индекс: ");
                            element = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine(linkedList.FindFromIndex(element, linkedList));
                        }
                        else if(ot == 2)
                        {
                            Console.WriteLine("Введите элемент: ");
                            element = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine(linkedList.FindFromValue(element, linkedList));
                        }
                    }
                    else if(s == 4)
                    {
                        Console.WriteLine("Выберите вид движения по списку: ");
                        Console.WriteLine("1 - Вперед по списку");
                        Console.WriteLine("2 - Назад");
                        Console.WriteLine("3 - В конец");
                        ot = Convert.ToInt32(Console.ReadLine());
                        if( ot == 1)
                        {
                            Console.WriteLine("Введите на сколько шагов продвинутся по списку: ");
                            element = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine(linkedList.MoveNext(element, linkedList));
                        }
                        else if( ot == 2)
                        {
                            Console.WriteLine("Введите на сколько шагов продвинутся по списку: ");
                            element = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine(linkedList.MovePrev(element, linkedList));
                        }
                        else if( ot == 3)
                        {
                            Console.WriteLine(linkedList.MoveLast(linkedList));
                        }

                    }
                    else if(s == 5)
                    {
                        Console.WriteLine("Список до сортировки: ");
                        linkedList.Print(linkedList);
                        Console.WriteLine("Список после сортировки: ");
                        linkedList = linkedList.Sort(linkedList);
                        linkedList.Print(linkedList);
                    }
                    

                    Console.WriteLine("Продолжить действия с связным списком? 1/0");
                    s = Convert.ToInt32(Console.ReadLine());
                    if (s == 0)
                    {
                        stop = false;
                    }
                }

            }
            else if(otvet_2 == 3)
            {
                int element = 0;
                int s = 0;
                int ot = 0;
                LastLinkedList<int> linkedList = new LastLinkedList<int>();
                foreach (int v in arrayList)
                {
                    linkedList.Add(v);
                }
                linkedList.Print(linkedList);
                Console.WriteLine("");
                while (stop)
                {
                    Console.WriteLine("Выберете какое действие сделать со списокм");
                    Console.WriteLine("1 - вставить элемент");
                    Console.WriteLine("2 - удалить элемент");
                    Console.WriteLine("3 - найти элемент");
                    Console.WriteLine("4 - движение по списку");
                    Console.WriteLine("5 - отсортировать список");
                    s = Convert.ToInt32(Console.ReadLine());
                    if(s == 1)
                    {
                        Console.WriteLine("Введите элемент, который хотите вставить: ");
                        element = Convert.ToInt32(Console.ReadLine());
                        linkedList.Add(element);
                        linkedList.Print(linkedList);
                    }
                    else if(s == 2)
                    {
                        Console.WriteLine("Введите элемент, который хотите удалить: ");
                        element = Convert.ToInt32(Console.ReadLine());
                        linkedList.Remove(element);
                        linkedList.Print(linkedList);
                    }
                    else if(s == 3)
                    {
                        Console.WriteLine("Поиск элемента по индексу или значению 1/2");
                        ot = Convert.ToInt32(Console.ReadLine());
                        if(ot == 1)
                        {
                            Console.WriteLine("Введите индекс, который хотите найти: ");
                            element = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine(linkedList.IndexSearch(element));
                        }
                        else if(ot == 2)
                        {
                            Console.WriteLine("Введите элемент: ");
                            element = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine(linkedList.Contains(element));
                        }
                    }
                    else if(s == 4)
                    {
                        Console.WriteLine("Движение в конец или по элементу 1/2");
                        ot = Convert.ToInt32(Console.ReadLine());
                        if (ot == 1)
                        {
                            Console.WriteLine(linkedList.MoveEnd(linkedList));
                        }
                        else if (ot == 2)
                        {
                            Console.WriteLine("Введите кол-во шагов: ");
                            element = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine(linkedList.Move(element, linkedList));
                        }
                    }
                    else if(s == 5)
                    {
                        Console.WriteLine("Список до сортировки: ");
                        linkedList.Print(linkedList);
                        Console.WriteLine("Список после сортировки: ");
                        linkedList = linkedList.Sort(linkedList);
                        linkedList.Print(linkedList);
                    }

                    Console.WriteLine("Продолжить действия с связным списком? 1/0");
                    s = Convert.ToInt32(Console.ReadLine());
                    if (s == 0)
                    {
                        stop = false;
                    }
                }
            }
        }

        //**используемые методы**///
        public static int Search(int[] ar, int value)
        {
            int s = 0;
            for (int i = 0; i < ar.Length; i++)
            {
                if (ar[i] == value)
                {
                    s = i;
                }
            }
            return s;
        }
    }
}
