using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie4
{
    public class LinkedList<T> where T : IComparable
    {
        public LinkedListNode<T> _head;
        private LinkedListNode<T> _tail;
        //private LinkedListNode<int> sorted;

        private int _count;

        public int Count
        {
            get { return _count; }
        }

        public bool IsEmpty //проверка на пустоту
        {
            get { return _count == 0; }
        }

        public LinkedListNode<T> First //возвращает ссылку на голову
        {
            get { return _head; }
        }

        public LinkedList()
        {

        }

        public void AddAfter(LinkedListNode<T> node, T value)
        {
            LinkedListNode<T> newNode = new LinkedListNode<T>(value, node.Next); //создаем новый узел в памяти
            node.Next = newNode;

            _count++;
        }

        public void RemoveAfter(LinkedListNode<T> node) //удаляет элемент после элемента нод
        {
            LinkedListNode<T> removedNode = node.Next;

            node.Next = removedNode.Next;
            removedNode.Next = null;

            if (removedNode == _tail)
            {
                _tail = node;
            }

            _count--;
        }

        public void Remove(LinkedListNode<T> node)//удаляет сам элемент нод
        {
            //Если у элемента есть указатель на следующий элемент, то можем быстро его удалить
            if (node.Next != null)
            {
                node.Value = node.Next.Value;
                RemoveAfter(node.Next);
            }
            else
            {
                // удаляем хвост
                if (_head == _tail)
                {
                    _head = _tail = null;
                    _count--;
                }
                else
                {
                    RemoveAfter(FindPrevNode(node));
                }

            }
        }

        public LinkedListNode<T> FindPrevNode(LinkedListNode<T> node) //поиск предыдущего элемента
        {
            LinkedListNode<T> prevNode = null;
            LinkedListNode<T> currentNode = _head;
            while (currentNode != null)
            {
                prevNode = currentNode;
                currentNode = currentNode.Next;
            }
            return prevNode;
        }

        public void Add(T value) //добавление элемента в конец списка
        {
            if (_head == null)
            {
                _head = _tail = new LinkedListNode<T>(value, null);
                _count++;
            }
            else
            {
                AddAfter(_tail, value);
                _tail = _tail.Next;
            }
        }

        public LinkedListNode<T> Find(T value) // поиск элемента
        {
            LinkedListNode<T> ptr = _head;
            while (ptr != null)
            {
                if (ptr.Value.CompareTo(value) == 0)
                    return ptr;

                ptr = ptr.Next;
            }

            return null;
        }
        public string FindFromIndex(int a) // найти элемент по индексу
        {
            string s = "Данный элемент отсутствует в списке / вы ввели большое число";
            LinkedListNode<T> ptr = _head;
            for (int i = 0; i < a; i++)
            {
                if (ptr != null)
                {
                    ptr = ptr.Next;
                }
                else
                    return s;
            }
            s = "Данный элемент: ";
            s += ptr.Value;
            return s;
        }

        public string FindFromValue(int a) // найти элемент по значению
        {
            string s = "Данный элемент отсутствует в списке / вы ввели большое число";
            int count = 0;
            LinkedListNode<T> ptr = _head;
            while (ptr != null)
            {
                if (ptr.Value.CompareTo(a) == 0)
                {
                    s = "Индекс данного элемента: ";
                    s += count;
                    return s;
                }
                count++;
                ptr = ptr.Next;
            }
            return s;

        }

        public void Clean() // очистить список
        {
            _head = null;
            _tail = null;
            _count = 0;
        }

        public string MoveNextStart(int a) //движение с начала списка
        {
            Stopwatch clock = new Stopwatch();
            string b = "В списке не достаточно чисел";
            LinkedListNode<T> ptr = _head;
            clock.Start();
            for (int i = 0; i < a; i++)
            {
                if (ptr != null)
                {
                    ptr = ptr.Next;
                }
                else
                    return b;
            }
            clock.Stop();
            b = "Значение числа = ";
            b += ptr.Value;
            b += " Время затрачено на выполнение = ";
            b += clock.Elapsed;
            clock.Reset();
            return b;
        }
        public string MoveNext(LinkedListNode<T> ptr, int a)
        {
            Stopwatch clock = new Stopwatch();
            string b = "В списке не достаточно чисел";
            LinkedListNode<T> ptv = ptr;
            clock.Start();
            for (int i = 0; i < a; i++)
            {
                if (ptr != null)
                {
                    ptr = ptr.Next;
                }
                else
                    return b;
            }
            clock.Stop();
            b = "Значение числа = ";
            b += ptr.Value;
            b += " Время затрачено на выполнение = ";
            b += clock.Elapsed;
            clock.Reset();
            return b;
        }

        public void PrintList(LinkedList<int> list) //распечатоть список
        {
            var node = list.First;
            while(node != null)
            {
                Console.Write(node.Value + " ");
                node = node.Next;
            }
            Console.WriteLine();
        }

        public LinkedList<int> Sort(LinkedList<int> list)
        {
            LinkedList<int> result = new LinkedList<int>();
            int b = 0;
            int[] nums = new int[_count];
            var current = list.First;
            while (current != null)
            {
                nums[b] = current.Value;
                b++;
                current = current.Next;
            }
            InsertionSort(nums);
            for (int i = 0; i < nums.Length; i++)
            {
                result.Add(nums[i]);
            }
            return result;
        }
        static void Swap(int[] array, int i, int j)
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

        /*// function to sort a singly
        // linked list using insertion sort
        public void insertionSort(LinkedListNode<int> _head)
        {
            // Инициализировать отсортированный связанный список
            sorted = null;
            LinkedListNode<int> current = _head;

            // Пересечь заданный
            // связанный список и вставьте каждый
            // узел в отсортированный
            while (current != null)
            {
                // Сохраните next для следующей итерации
                LinkedListNode<int> next = current.Next;

                // вставить текущий в отсортированный связанный список
                sortedInsert(current);

                // Update current
                current = next;
            }

            // Обновите head_ref, чтобы указать на отсортированный связанный список
            _head = sorted;
        }
        void sortedInsert(LinkedListNode<int> newnode)
        {
            if (sorted == null || sorted.Value >= newnode.Value)
            {
                newnode.Next = sorted;
                sorted = newnode;
            }
            else
            {
                LinkedListNode<int> current = sorted;

                *//* Найдите узел перед точкой вставки *//*
                while (current.Next != null &&
                        current.Next.Value < newnode.Value)
                {
                    current = current.Next;
                }
                newnode.Next = current.Next;
                current.Next = newnode;
            }
        }*/
    }
}
