using System;

namespace ConsoleApp1
{
    public class QueueElem
    {
        public int Value;
        public QueueElem Next = null;
        public QueueElem(int val)
        {
            Value = val;
        }
    }

    class Queue
    {
        public QueueElem Head;
        public Queue()
        {
            Head = null;
        }
        public void push(int elem)
        {
            if (Head is null)
                Head = new QueueElem(elem);
            else
            {
                QueueElem cur = Head;
                while (!(cur.Next is null))
                    cur = cur.Next;
                cur.Next = new QueueElem(elem);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
}
