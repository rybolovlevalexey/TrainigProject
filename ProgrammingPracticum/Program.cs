using System;
using System.Collections.Generic;
using System.Text;

namespace Урок18._11._22
{
    class MyList
    {
        public List_item head = new List_item("");
        public MyList() { }
        public MyList(string s) { head.Value = s; }
        public int Length()
        {
            if (head.Value == "" && head.Next == null)
            {
                return 0;
            }
            int dlina = 1;
            List_item cur = head;
            while (cur.Next != null)
            {
                dlina += 1;
                cur = cur.Next;
            }
            return dlina;
        }
        public void Element_IndFromEnd(int ind)
        {
            int i = 1;
            List_item cur = head;
            bool flag = false;
            if (ind <= 0)
            {
                flag = true;
                Console.WriteLine("Полученный индекс не соответствует размерам списка");
            }
            while (cur.Next != null && !flag)
            {
                if (i + ind - 1 == this.Length())
                {
                    Console.WriteLine(cur.Value);
                    flag = true;
                }
                cur = cur.Next;
                i += 1;
            }
            if (i - 1 + ind == this.Length() && !flag)
            {
                Console.WriteLine(cur.Value);
                flag = true;
            }
            if (!flag)
            {
                Console.WriteLine("Полученный индекс не соответствует размерам списка");
            }
        }

        public void Element_IndFromStart(int ind)
        {
            int i = 1;
            List_item cur = head;
            bool flag = false;
            if (ind <= 0)
            {
                flag = true;
                Console.WriteLine("Полученный индекс не соответствует размерам списка");
            }
            while (cur.Next != null && !flag)
            {
                if (i == ind)
                {
                    Console.WriteLine(cur.Value);
                    flag = true;
                }
                cur = cur.Next;
                i += 1;
            }
            if (i == ind && !flag)
            {
                Console.WriteLine(cur.Value);
                flag = true;
            }
            if (!flag)
            {
                Console.WriteLine("Полученный индекс не соответствует размерам списка");
            }
        }
        public void Append(string st)
        {
            List_item temp = head;
            while (temp.Next != null)
            {
                temp = temp.Next;
            }
            List_item elem = new List_item(st);
            temp.Next = elem;
        }
        public void Printn()
        {
            List_item temp = head;
            while (temp.Next != null)
            {
                Console.WriteLine($"{temp.Value} ");
                temp = temp.Next;
            }
            Console.WriteLine($"{temp.Value} ");
        }
        public void Prints()
        {
            List_item temp = head;
            while (temp.Next != null)
            {
                Console.Write($"{temp.Value} ");
                temp = temp.Next;
            }
            Console.Write($"{temp.Value}\n");
        }
    }
}
