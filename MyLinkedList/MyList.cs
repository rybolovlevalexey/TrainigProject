using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace дз_по_тетсированию_Двусвязных_списков
{
    class ValueNotInListError : Exception { }
    class MyList<T>
    {
        public List_item<T> head = new List_item<T>(default(T));
        public List_item<T> tail = new List_item<T>(default(T));
        public int Count = -1;
        //int Count { get { return Count; } set { Count = value; } }
        public MyList() { Count = 0; }
        public MyList(T s) { head.Value = s; tail = head; Count = 1; }
        public MyList(T[] mas_s)
        {
            Count = mas_s.Length;
            if (mas_s.Length == 0)
                return;
            if (mas_s.Length == 1)
            {
                head.Value = mas_s[0]; tail = head;
                return;
            }
            List_item<T> cur = head;
            head.Value = mas_s[0];
            for (int i = 1; i < mas_s.Length; i += 1)
            {
                if (i + 1 != mas_s.Length)
                {
                    List_item<T> elem = new List_item<T>(mas_s[i]);
                    elem.Previous = cur;
                    cur.Next = elem;
                    cur = elem;
                }
                else
                {
                    List_item<T> elem = new List_item<T>(mas_s[i]);
                    elem.Previous = cur;
                    cur.Next = elem;
                    tail = elem;
                }
            }
        }
        public override string ToString()
        {
            string result = "";
            List_item<T> temp = head;
            while (temp.Next != null)
            {
                result += $"{temp.Value} ";
                temp = temp.Next;
            }
            result += $"{temp.Value}\n";
            return result;
        }
        public void Clear()
        {
            this.head = null;
            this.tail = null;
            Count = 0;
        }
        public T this[int index]
        {
            get
            {
                return ReturnElementByIndex(index).Value;
            }
        }
        public static MyList<T> operator +(MyList<T> a, MyList<T> b)
        {
            MyList<T> ans = new MyList<T>(a.head.Value);
            List_item<T> cur = a.head.Next;
            List_item<T> previous = ans.head;
            List_item<T> new_element;

            while (cur.Next != null)
            {
                new_element = new List_item<T>(cur.Value);
                previous.Next = new_element;
                previous = previous.Next;
                cur = cur.Next;
            }
            new_element = new List_item<T>(cur.Value);
            previous.Next = new_element;
            previous = previous.Next;
            cur = b.head;
            while (cur.Next != null)
            {
                new_element = new List_item<T>(cur.Value);
                previous.Next = new_element;
                previous = previous.Next;
                cur = cur.Next;
            }
            ans.Append(cur.Value);
            return ans;
        }
        public void Print_withPreviousNext()
        {
            List_item<T> cur = head;
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
        public void AddFirst(T st)
        {
            List_item<T> cur = head;
            head = new List_item<T>(st);
            head.Next = cur;
            cur.Previous = head;
            Count += 1;
        }
        public bool DeleteByValue(T value)
        {
            Count -= 1;
            List_item<T> cur = head;
            if (Convert.ToString(cur.Value) == Convert.ToString(value))
            {
                head.Value = cur.Next.Value;
                head.Next = cur.Next.Next;
                return true;
            }
            while (cur.Next != null)
            {
                List_item<T> previous = cur;
                cur = cur.Next;
                if (Convert.ToString(cur.Value) == Convert.ToString(value))
                {
                    previous.Next = cur.Next;
                    cur.Next.Previous = previous;
                    return true;
                }
            }
            Count += 1;
            return false;
        }
        public void TurningAround()
        {
            if (Count == 1 || Count == 0)
            {
                return;
            }
            if (Count == 2)
            {
                List_item<T> first_ = head;
                List_item<T> second_ = first_.Next;
                first_.Next = null;
                second_.Next = first_;
                head = second_;
                first_.Previous = head;
                tail = head.Next;
                tail.Previous = head;
                return;
            }
            List_item<T> first = head;
            List_item<T> second = first.Next;
            first.Next = null;
            tail = first;
            List_item<T> third = second.Next;
            second.Next = first;
            while (third.Next != null)
            {
                List_item<T> next_link = third.Next;
                first = second;
                second = third;
                third = next_link;
                second.Next = first;
            }
            this.head = third;
            this.head.Next = second;

            List_item<T> one = head;
            head.Previous = null;
            List_item<T> two = one.Next;
            two.Previous = one;
            while (two.Next != null)
            {
                two = two.Next;
                one = one.Next;
                two.Previous = one;
            }
            two.Previous = one;
        }
        public bool IsPalindrom()
        {
            List_item<T> to_the_end = head;
            while (to_the_end.Next != null)
            {
                to_the_end = to_the_end.Next;
            }
            int dl = Count, i = 0;

            List_item<T> from_start = head;
            while (i < dl / 2)
            {
                if (Convert.ToString(from_start.Value) != Convert.ToString(to_the_end.Value))
                {
                    return false;
                }
                i += 1;
                from_start = from_start.Next;
                to_the_end = to_the_end.Previous;
            }
            return true;
        }

        // индексация: слева направо от 0, справа налево от -1
        public List_item<T> ReturnElementByIndex(int ind)
        {
            List_item<T> cur = head;
            if (ind < 0)
            {
                int i = 1;
                ind = Math.Abs(ind);
                while (cur.Next != null)
                {
                    if (i + ind - 1 == Count)
                    {
                        return cur;
                    }
                    cur = cur.Next;
                    i += 1;
                }
                if (i - 1 + ind == Count)
                {
                    return cur;
                }
            }
            else
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
            throw new IndexOutOfRangeException();
        }
        public void Append(T st)
        {
            if (Count == 0)
            {
                this.head.Value = st;
            }
            else
            {
                List_item<T> temp = head;
                while (temp.Next != null)
                {
                    temp = temp.Next;
                }
                List_item<T> elem = new List_item<T>(st);
                elem.Previous = temp;
                temp.Next = elem;
                tail = elem;
            }
            Count += 1;
        }
        public void Printn()
        {
            List_item<T> temp = head;
            while (temp.Next != null)
            {
                Console.WriteLine($"{temp.Value} ");
                temp = temp.Next;
            }
            Console.WriteLine($"{temp.Value} ");
        }
        public void Prints()
        {
            List_item<T> temp = head;
            while (temp.Next != null)
            {
                Console.Write($"{temp.Value} ");
                temp = temp.Next;
            }
            Console.Write($"{temp.Value}\n");
        }
        public int Length()
        {
            return Count;
        }
    }
}
