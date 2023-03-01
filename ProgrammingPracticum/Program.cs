using System;
using System.Collections.Generic;
using System.Text;

namespace Урок18._11._22
{
    class MyList
    {
        public List_item head = new List_item(null);
        public List_item tail = new List_item(null);
        public MyList() { }
        public MyList(string s) { head.Value = s; tail = head; }
        public override string ToString()
        {
            string result = "";
            List_item temp = head;
            while (temp.Next != null)
            {
                result += $"{temp.Value} ";
                temp = temp.Next;
            }
            result += $"{temp.Value}\n";
            return result;
        }
        public string this [int index]
        {
            get
            {
                return ReturnElementByIndex(index).Value;
            }
        }

        public static MyList operator +(MyList a, MyList b) 
        {
            MyList ans = new MyList(a.head.Value);
            List_item cur = a.head.Next;
            List_item previous = ans.head;
            List_item new_element = new List_item("");

            while (cur.Next != null)
            {
                new_element = new List_item(cur.Value);
                previous.Next = new_element;
                previous = previous.Next;
                cur = cur.Next;
            }
            new_element = new List_item(cur.Value);
            previous.Next = new_element;
            previous = previous.Next;
            cur = b.head;
            while (cur.Next != null)
            {
                new_element = new List_item(cur.Value);
                previous.Next = new_element;
                previous = previous.Next;
                cur = cur.Next;
            }
            ans.Append(cur.Value);
            return ans;
        }
        public void Print_withPreviousNext()
        {
            List_item cur = head;
            while (cur.Next != null)
            {
                if (cur.Previous == null)
                {
                    Console.Write("NO");
                }
                else
                {
                    Console.Write(cur.Previous.Value);
                }
                Console.Write(" ");
                Console.Write(cur.Value);
                Console.Write(" ");
                if (cur.Next == null)
                {
                    Console.Write("NO");
                }
                else
                {
                    Console.Write(cur.Next.Value);
                }
                Console.WriteLine("");
                cur = cur.Next;
            }
            if (cur.Next == null)
            {
                Console.Write(cur.Previous.Value + " " + cur.Value + " NO");
            }
        }
        public void DeleteWithoutUsingHead(List_item element)
        {
            if (element.Next == null)
            {
                element = null;
            }
            else
            {
                while (element.Next != null)
                {
                    element.Value = element.Next.Value;
                    if (element.Next.Next == null)
                    {
                        element.Next = null;
                        break;
                    }
                    element = element.Next;
                }
            }
        }
        public void AddToTop(string st)
        {
            List_item cur = head;
            head = new List_item(st);
            head.Next = cur;
            cur.Previous = head;
        }
        // индексация с 0
        public void DeleteByIndex(int index)
        {
            if (this.Length() < index || index < 0)
            {
                Console.WriteLine("Введён некорректный индекс");
                return;
            }
            List_item cur = head;
            if (index == 0)
            {
                head.Value = cur.Next.Value;
                head.Next = cur.Next.Next;
                cur.Next.Previous = head;
                return;
            }
            int i = 0;
            while (cur.Next != null)
            {
                List_item previous = cur;
                cur = cur.Next;
                i += 1;
                if (i == index)
                {
                    previous.Next = cur.Next;
                    cur.Next.Previous = previous;
                    return;
                }
            }
            
        }
        public void DeleteByValue(string value)
        {
            List_item cur = head;
            if (cur.Value == value)
            {
                head.Value = cur.Next.Value;
                head.Next = cur.Next.Next;
                return;
            }
            while (cur.Next != null)
            {
                List_item previous = cur;
                cur = cur.Next;
                if (cur.Value == value)
                {
                    previous.Next = cur.Next;
                    cur.Next.Previous = previous;
                    return;
                }
            }
        }
        public void DeleteDublicates()
        {
            List_item cur = head;
            while (cur.Next != null)
            {
                List_item cur1 = cur.Next;
                List_item previous = cur;
                while (cur1.Next != null)
                {
                    if (cur1.Value == cur.Value)
                    {
                        previous.Next = cur1.Next;
                        cur1.Next.Previous = previous;
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
                    cur1.Next.Previous = previous;
                }
                cur = cur.Next;
            }
        }
        public void Add(string st)
        {
            if (this.Length() == 1 && this.head.Value is null)
            {
                this.head.Value = st;
            }
            else
            {
                if (tail.Next is null && tail.Previous is null && head.Value != st)
                {
                    tail.Value = st;
                    tail.Previous = head;
                    head.Next = tail;
                } else
                {
                    List_item cur = head;
                    if (cur.Value == st)
                        return;
                    while (cur.Next != null)
                    {
                        cur = cur.Next;
                        if (cur.Value == st)
                            return;
                    }
                    List_item elem = new List_item(st);
                    tail = elem;
                    cur.Next = tail;
                    tail.Previous = cur;
                }
                
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
                head = second_;
                first_.Previous = head;
                tail = head.Next;
                tail.Previous = head;
                return;
            }
            List_item first = head;
            List_item second = first.Next;
            first.Next = null;
            tail = first;
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

            List_item one = head;
            head.Previous = null;
            List_item two = one.Next;
            two.Previous = one;
            while (two.Next != null)
            {
                two = two.Next;
                one = one.Next;
                two.Previous = one;
            }
            two.Previous = one;
        }
        public bool Is_Palindrom_new()
        {
            List_item to_the_end = head;
            while (to_the_end.Next != null)
            {
                to_the_end = to_the_end.Next;
            }
            int dl = this.Length(), i = 0;

            List_item from_start = head;
            while (i < dl / 2)
            {
                if (from_start.Value != to_the_end.Value)
                {
                    return false;
                }
                i += 1;
                from_start = from_start.Next;
                to_the_end = to_the_end.Previous;
            }
            return true;
        }

        public bool Is_Palindrom()
        {
            int dl = this.Length();
            for (int i = 0; i < dl / 2; i += 1)
            {
                if (this.ReturnElementByIndex(i).Value != this.ReturnElementByIndex((i + 1) * (-1)).Value)
                    return false;
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
            if (this.Length() == 1 && this.head.Value is null)
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
                elem.Previous = temp;
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
