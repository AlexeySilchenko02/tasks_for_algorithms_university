using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie7_1
{
    public class Heap
    {
        private Node[] heapArray; //массив со всеми вершинами
        private int maxSize; //размер массива
        private int currentSize; //количество узлов в массиве

        public Heap(int maxSize)
        {
            this.maxSize = maxSize;
            this.currentSize = 0;
            heapArray = new Node[maxSize];
        }

        public void printHeap() //отображение пирамиды в консоль
        {
            Console.WriteLine("Массив значений: ");

            for(int n = 0; n < currentSize; n++)
            {
                if(heapArray[n] != null)
                {
                    Console.WriteLine(heapArray[n].getValue() + " ");
                }
                else
                {
                    Console.WriteLine("-");
                }
            }
            Console.WriteLine("");

            int countOfGaps = 32;
            int itemsPerRow = 1;
            int columnNumber = 0; // номер элемента в данной строке

            string lines = "___________________________________________________________________";
            Console.WriteLine(lines);

            for(int i = 0; i < currentSize; i++)
            {
                if(columnNumber == 0) //проверяем первый элемент в текущей строке
                {
                    for(int k=0; k<countOfGaps; k++) //добавлям предшествующие пробелы
                    {
                        Console.Write(' ');
                    }
                }
                Console.Write(heapArray[i].getValue()); // выводим в консоль значение вершины

                if(++columnNumber == itemsPerRow) //проверяем последний ли элемент в строке
                {
                    countOfGaps /= 2; //уменьшаем кол-во отступов для следующей строки
                    itemsPerRow *= 2; //указываем, что элементов может быть в двое больше
                    columnNumber = 0; //сбрасываем счетчик для текущего элемента строки
                    Console.WriteLine(""); //переходим на некст строку
                }
                else //переходим к следующему элементу
                {
                    for(int k = 0; k < countOfGaps * 2 - 2; k++)
                    {
                        Console.Write(' '); //добавляем отступы
                    }
                }
            }
            Console.WriteLine("\n" + lines);//нижний пунктир
        }

        public bool insertNode(int value) //вставка нового значения
        {
            if(currentSize == maxSize) //проверяем не выходит ли за рамки массива
                return false;
            Node newNode = new Node(value);//создаем вершины с данным значением
            heapArray[currentSize] = newNode;// вершину задём в самый низ дерева
            displaceUp(currentSize++);// пытаемся поднять вершину, если значение вершины позволяет
            return true;
        }

        public Node removeNode(int index) //удалить элемент по индексу массива
        {
            if (index > 0 && currentSize > index)
            {
                Node root = heapArray[index];
                heapArray[index] = heapArray[--currentSize]; // задаём элементу с переданным индексом, значение последнего элемента
                heapArray[currentSize] = null;// последний элемент удаляем
                displaceDown(index);// проталкиваем вниз новый элемент, чтобы он должное ему место
                return root;
            }
            return null;
        }

        public bool changeNode(int index, int newValue)
        {
            if (index < 0 || currentSize <= index)
            {
                return false;
            }
            int oldValue = heapArray[index].getValue(); // сохраняем старое значение
            heapArray[index].setValue(newValue); // присваиваем новое

            if (oldValue < newValue)// если узел повышается
            {
                displaceUp(index);// выполняется смещение вверх     
            }
            else // если понижается
            {                 
                displaceDown(index); // смещение вниз  
            }
            return true;
        }

        private void displaceUp(int index)//смещение вверх
        { 
            int parentIndex = (index - 1) / 2; // узнаем индекс родителя
            Node bottom = heapArray[index]; // берем элемент
            while (index > 0 && heapArray[parentIndex].getValue() < bottom.getValue())// если родительский элемент меньше
            {
                heapArray[index] = heapArray[parentIndex];// то меняем его местами с рассматриваемым
                index = parentIndex;
                parentIndex = (parentIndex - 1) / 2;// берем новый родительский индекс и повторяем сравнение элементов
            }
            heapArray[index] = bottom;// соохраняем результат
        }

        private void displaceDown(int index)// смещение вниз
        {
            int largerChild;
            Node top = heapArray[index]; // сохранение корня, пока у узла есть хотя бы один потомок
            while (index < currentSize / 2)// если данное условие не выполняется то элемент уже в самом низу пирамиды
            {
                int leftChild = 2 * index + 1; // вычисляем индексы в массиве для левого узла ребенка
                int rightChild = leftChild + 1;// и правого

                if (rightChild < currentSize && heapArray[leftChild].getValue() < heapArray[rightChild].getValue())
                {
                    largerChild = rightChild;//вычисляем ребенка вершину с наибольшим числовым значением
                }
                else
                {
                    largerChild = leftChild;
                }

                if (top.getValue() >= heapArray[largerChild].getValue())// если значение вершины больше или равно значени его наибольшего ребенка
                {
                    break;// то выходим из метода
                }

                heapArray[index] = heapArray[largerChild];// заменяем вершину, большей дочерней вершиной
                index = largerChild; // текущий индекс переходит вниз
            }
            heapArray[index] = top; // задаем конечное местоположение для элемента
        }
    }
}
