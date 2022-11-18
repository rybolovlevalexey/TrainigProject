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
            Console.Write($"{temp.Value} ");
        }
    }
}
