using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie4
{
    public class DoublyLinkedList<T>  // двусвязный список
    {
        DoublyNode<T> head; // головной/первый элемент
        DoublyNode<T> tail; // последний/хвостовой элемент
        int count;  // количество элементов в списке

        // добавление элемента
        public void Add(T data)
        {
            DoublyNode<T> node = new DoublyNode<T>(data);

            if (head == null)
                head = node;
            else
            {
                tail.Next = node;
                node.Previous = tail;
            }
            tail = node;
            count++;
        }
        public void AddFirst(T data)
        {
            DoublyNode<T> node = new DoublyNode<T>(data);
            DoublyNode<T> temp = head;
            node.Next = temp;
            head = node;
            if (count == 0)
                tail = head;
            else
                temp.Previous = node;
            count++;
        }
        // удаление
        public bool Remove(T data)
        {
            DoublyNode<T> current = head;

            // поиск удаляемого узла
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    break;
                }
                current = current.Next;
            }
            if (current != null)
            {
                // если узел не последний
                if (current.Next != null)
                {
                    current.Next.Previous = current.Previous;
                }
                else
                {
                    // если последний, переустанавливаем tail
                    tail = current.Previous;
                }

                // если узел не первый
                if (current.Previous != null)
                {
                    current.Previous.Next = current.Next;
                }
                else
                {
                    // если первый, переустанавливаем head
                    head = current.Next;
                }
                count--;
                return true;
            }
            return false;
        }

        public int Count { get { return count; } }
        public bool IsEmpty { get { return count == 0; } }

        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public bool Contains(T data)
        {
            DoublyNode<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }
            return false;
        }

        public void Print(DoublyLinkedList<T> list)
        {
            var current = list.head;
            while(current != null)
            {
                Console.Write(current.Data + " ");
                current = current.Next;
            }
        }
        public string FindFromIndex(int a, DoublyLinkedList<T> list) // найти элемент по индексу
        {
            string s = "Данный элемент отсутствует в списке / вы ввели большое число";
            var current = list.head;
            for (int i = 0; i < a; i++)
            {
                if (current != null)
                {
                    current = current.Next;
                }
                else
                    return s;
            }
            s = "Данный элемент: ";
            s += current.Data;
            return s;
        }

        public string FindFromValue(int a, DoublyLinkedList<int> list) // найти элемент по значению
        {
            string s = "Данный элемент отсутствует в списке / вы ввели большое число";
            int count = 0;
            var current = list.head;
            while (current != null)
            {
                if (current.Data.CompareTo(a) == 0)
                {
                    s = "Индекс данного элемента: ";
                    s += count;
                    return s;
                }
                count++;
                current = current.Next;
            }
            return s;

        }
        public string MoveLast(DoublyLinkedList<T> list)
        {
            string s = "";
            Stopwatch clock = new Stopwatch();
            var current = list.head;
            clock.Start();
            while (current != null)
            {
                if (current == list.tail)
                {
                    s = "Этот элемент: ";
                    s += current.Data;
                }
                current = current.Next;
            }
            clock.Stop();
            s += "  Время затрачено: ";
            s += clock.Elapsed;
            clock.Reset();
            return s;
        }

        public string MoveNext(int a, DoublyLinkedList<T> list)
        {
            string s = "";
            Stopwatch clock = new Stopwatch();
            var current = list.head;
            clock.Start();
            while (current != null && a>0)
            {
                current = current.Next;
                a--;
            }
            clock.Stop();
            s += "Значение: ";
            s += current.Data;
            s += " Время: ";
            s += clock.Elapsed;
            clock.Reset();
            return s;
        }
        public string MovePrev(int a, DoublyLinkedList<T> list)
        {
            string s = "";
            Stopwatch clock = new Stopwatch();
            var current = list.tail;
            clock.Start();
            while (current != null && a>0)
            {
                current = current.Previous;
                a--;
            }
            clock.Stop();
            s += "Значение: ";
            s += current.Data;
            s += " Время: ";
            s += clock.Elapsed;
            clock.Reset();
            return s;
        }

        public DoublyLinkedList<int> Sort (DoublyLinkedList<int> list)
        {
            DoublyLinkedList<int> result = new DoublyLinkedList<int>();
            int b = 0;
            int[] nums = new int[count];
            var current = list.head;
            while (current != null)
            {
                nums[b] = current.Data;
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

    }
}
