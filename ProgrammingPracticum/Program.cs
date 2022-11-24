using System;
using System.Collections.Generic;
using System.Text;

namespace Урок18._11._22
{
    class MyList
    {
        public List_item head = new List_item("Null");
        public MyList() { }
        public MyList(string s) { head.Value = s; }
        public void DeleteDublicates()
        {
            List_item cur = head;
            while (cur.Next != null)
            {
                List_item cur1 = cur.Next;
                List_item previous = cur;
                while (cur1.Next != null)
                {
                    Console.WriteLine("i am here");
                    if (cur1.Value == cur.Value)
                    {
                        previous.Next = cur1.Next;
                    }
                    else
                    {
                        previous = cur1;
                    }
                    cur1 = cur1.Next;
                }
                if (cur1.Value == cur.Value)
                {
                    previous.Next = cur1.Next;
                }
                cur = cur.Next;
            }
        }
        public void Add(string st)
        {
            if (this.Length() == 1 && this.head.Value == "Null")
            {
                this.head.Value = st;
            }
            else
            {
                List_item temp = head;
                if (head.Value == st)
                    return;
                while (temp.Next != null)
                {
                    temp = temp.Next;
                    if (temp.Value == st)
                        return;
                }
                List_item elem = new List_item(st);
                temp.Next = elem;
            }
        }
        public void TurningAround()
        {
            if (this.Length() == 1)
            {
                return;
            }
            if (this.Length() == 2)
            {
                List_item first_ = head;
                List_item second_ = first_.Next;
                first_.Next = null;
                second_.Next = first_;
                this.head = second_;
                return;
            }
            List_item first = head;
            List_item second = first.Next;
            first.Next = null;
            List_item third = second.Next;
            second.Next = first;
            while (third.Next != null) 
            {
                List_item next_link = third.Next;
                first = second;
                second = third;
                third = next_link;
                second.Next = first;
            }
            this.head = third;
            this.head.Next = second;
        }
        public bool Is_Palindrom()
        {
            int dl = this.Length();
            for (int i = 0; i < dl / 2; i += 1)
            {
                if (this.ReturnElementByIndex(i).Value != this.ReturnElementByIndex((i + 1) * (-1)).Value)
                {
                    return false;
                }
            }
            return true;
        }
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

        // индексация: слева направо от 0, справа налево от -1
        public List_item ReturnElementByIndex(int ind)
        {
            List_item cur = head;
            if (ind < 0)
            {
                int i = 1;
                ind = Math.Abs(ind);
                while (cur.Next != null)
                {
                    if (i + ind - 1 == this.Length())
                    {
                        return cur;
                    }
                    cur = cur.Next;
                    i += 1;
                }
                if (i - 1 + ind == this.Length())
                {
                    return cur;
                }
            } else
            {
                int i = 0;
                while (cur.Next != null)
                {
                    if (i == ind)
                    {
                        return cur;
                    }
                    cur = cur.Next;
                    i += 1;
                }
                if (i == ind)
                {
                    return cur;
                }
            }
            return new List_item("error");
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
            if (this.Length() == 1 && this.head.Value == "Null")
            {
                this.head.Value = st;
            }
            else
            {
                List_item temp = head;
                while (temp.Next != null)
                {
                    temp = temp.Next;
                }
                List_item elem = new List_item(st);
                temp.Next = elem;
            }
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
