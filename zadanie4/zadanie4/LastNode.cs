using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie4
{
    //первый элемент всегда указывает на последний
    public class LastNode<T>
    {
        public LastNode(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public LastNode<T> Next { get; set; }
    }
    public class LastHeadNode<T> : LastNode<T>
    {
        public LastHeadNode(LastNode<T> lastNode, T data) : base(data)
        {
            Last = lastNode;
        }
        public LastNode<T> Last { get; set; }
    }
    public class LastLinkedList<T>   // односвязный список
    {
        LastHeadNode<T> head; // головной/первый элемент
        LastNode<T> tail; // последний/хвостовой элемент
        int count;  // количество элементов в списке

        // добавление элемента
        public void Add(T data)
        {
            LastNode<T> node = new LastNode<T>(data);
            LastHeadNode<T> hnode = new LastHeadNode<T>(node, data);
            if (head == null)
            {
                head = hnode;
                //head.Next = node;
            }
            else
            {
                if (count == 1)
                {
                    head.Next = node;
                }
                tail.Next = node;
                head.Last = node;
            }
            tail = node;

            count++;
        }
        // удаление элемента
        public void Remove(T data)
        {
            LastNode<T> current = head;
            LastNode<T> previous = null;
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    // Если узел в середине или в конце
                    if (previous != null)
                    {
                        // убираем узел current, теперь previous ссылается не на current, а на current.Next
                        previous.Next = current.Next;

                        // Если current.Next не установлен, значит узел последний,
                        // изменяем переменную tail
                        if (current.Next == null)
                        {
                            tail = previous;
                        }
                    }
                    else
                    {
                        // если удаляется первый элемент
                        // переустанавливаем значение head
                        LastHeadNode<T> head1 = new LastHeadNode<T>(head.Last, head.Next.Data);
                        head1.Next = head.Next.Next;

                        head = head1;

                        // если после удаления список пуст, сбрасываем tail
                        if (head == null)
                        {
                            tail = null;
                        }
                    }
                    count--;
                    break;
                }
                previous = current;
                current = current.Next;
            }
        }

        // очистка списка
        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }
        // поиск элемента по значению
        public int Contains(T data)
        {
            int x = 0;
            LastHeadNode<T> current = head;
            LastNode<T> current1 = head.Next;
            if (current != null)
            {
                if (head.Last.Data.Equals(data))
                {
                    return count - 1;
                }
                if (current.Data.Equals(data))
                {
                    return x;
                }
                x++;
                while (current1 != null)
                {
                    if (current1.Data.Equals(data))
                    {
                        return x;
                    }
                    x++;
                    current1 = current1.Next;
                }
            }
            return -1;
        }
        //поиск по индексу
        public T IndexSearch(int data)
        {
            int x = 0;
            LastHeadNode<T> current = head;
            LastNode<T> current1 = head.Next;
            if (current != null)
            {
                if (x == data)
                {
                    return current.Data;
                }
                x++;
                while (current1 != null)
                {
                    if (x == data)
                    {
                        return current1.Data;
                    }
                    x++;
                    current1 = current1.Next;
                }
            }
            return default(T);
        }
        public void Print(LastLinkedList<T> list)
        {
            LastHeadNode<T> current = head;
            LastNode<T> current1 = head.Next;
            if (current == head)
            {
                Console.Write(current.Data + " ");
                current1 = current.Next;
            }
            while (current1 != null)
            {
                Console.Write(current1.Data + " ");
                current1 = current1.Next;
            }
        }
        public string MoveEnd(LastLinkedList<T> list)
        {
            string s = "";
            Stopwatch clock = new Stopwatch();
            LastHeadNode<T> current = head;
            LastNode<T> current1 = head.Next;
            clock.Start();
            if (current == head)
            {
                current1 = current.Next;
            }
            while (current1 != null)
            {
                if(current1 == tail)
                {
                    s += "Значение: ";
                    s += current1.Data + " ";
                }
                current1 = current1.Next;
            }
            clock.Stop();
            s += "Время: ";
            s += clock.Elapsed;
            clock.Reset();
            return s;
        }
        public string Move(int a, LastLinkedList<T> list)
        {
            string s = "";
            Stopwatch clock = new Stopwatch();
            LastHeadNode<T> current = head;
            LastNode<T> current1 = head.Next;
            clock.Start();
            if (a == 0)
            {
                s += "Значение: ";
                s += current.Data + " ";
            }
            else if(a == 1)
            {
                current1 = current.Next;
                s += "Значение: ";
                s += current1.Data + " ";
            }
            else
            {
                current1 = current.Next;
                for(int i = 0; i < a-1; i++)
                {
                    current1 = current1.Next;
                }
                s += "Значение: ";
                s += current1.Data + " ";
            }
            clock.Stop();
            s += "Время: ";
            s += clock.Elapsed;
            clock.Reset();
            return s;
        }
        public LastLinkedList<int> Sort(LastLinkedList<int> list)
        {
            LastLinkedList<int> result = new LastLinkedList<int>();
            int b = 0;
            int[] nums = new int[count];
            LastHeadNode<T> current = head;
            LastNode<T> current1 = head.Next;
            if (current == head)
            {
                nums[b] = Convert.ToInt32(current.Data);
                b++;
                current1 = current.Next;
            }
            while (current1 != null)
            {
                nums[b] = Convert.ToInt32(current1.Data);
                current1 = current1.Next;
                b++;
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
