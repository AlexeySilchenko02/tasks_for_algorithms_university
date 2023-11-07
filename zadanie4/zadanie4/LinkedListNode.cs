using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie4
{
    //узел односвязного списка
    public class LinkedListNode<T>
    {
        public T Value; //значение
        public LinkedListNode<T> Next; //указатель на следующий узел

        public LinkedListNode(T value, LinkedListNode<T> next = null)
        {
            Value = value;
            Next = next;
        } 

    }
}
