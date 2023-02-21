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
            Console.WriteLine("ok");
        }

        public void pop()
        {
            if (Head is null)
            {
                Console.WriteLine("error");
            }
            else
            {
                int value = Head.Value;
                Head = Head.Next;
                Console.WriteLine(value);
            }
        }
        public void front()
        {
            if (Head is null)
                Console.WriteLine("error");
            else
                Console.WriteLine(Head.Value);
        }

        public void size()
        {
            QueueElem cur = Head;
            int length = 0;
            if (cur is null)
            {
                length = 0;
            } else
            {
                while (!(cur is null))
                {
                    length += 1;
                    cur = cur.Next;
                }
            }
            Console.WriteLine(length);
        }

        public void clear()
        {
            Head = null;
            Console.WriteLine("ok");
        }
        public void exit()
        {
            Console.WriteLine("bye");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
}
