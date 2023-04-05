using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace дз_по_тетсированию_Двусвязных_списков
{
    class ValueNotInListError : Exception { }
    class MyList<T>: ICloneable, ICollection<T>, IEnumerable<T>//, IComparable
    {
        private List_item<T> CurNode;
        private int CurIndex;

        public List_item<T> head = new List_item<T>(default(T));
        public List_item<T> tail = new List_item<T>(default(T));
        private int count = 0;
        public bool IsReadOnly => throw new NotImplementedException();
        int ICollection<T>.Count => count;

        public MyList() { count = 0; }
        public MyList(T s) { head.Value = s; tail = head; count = 1; }
        public MyList(T[] mas_s)
        {
            count = mas_s.Length;
            if (mas_s.Length == 0)
                return;
            if (mas_s.Length == 1)
            {
                head.Value = mas_s[0];
                tail = head;
                return;
            }
            head.Value = mas_s[0];
            for (int i = 1; i < mas_s.Length; i += 1)
                this.Append(mas_s[i]);
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
            count = 0;
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
            while (cur != null)
            {
                ans.Append(cur.Value);
                cur = cur.Next;
            }
            cur = b.head.Next;
            while (cur != null)
            {
                ans.Append(cur.Value);
                cur = cur.Next;
            }
            return ans;
        }
        public void Print_withPreviousNext()
        {
            List_item<T> cur = head;
            while (cur.Next != null)
            {
                if (cur.Previous == null)
                    Console.Write("NO");
                else
                    Console.Write(cur.Previous.Value);
                Console.Write(" ");
                Console.Write(cur.Value);
                Console.Write(" ");
                if (cur.Next == null)
                    Console.Write("NO");
                else
                    Console.Write(cur.Next.Value);
                Console.WriteLine("");
                cur = cur.Next;
            }
            if (cur.Next == null)
                Console.Write(cur.Previous.Value + " " + cur.Value + " NO");
        }
        public void AddFirst(T st)
        {
            List_item<T> cur = head;
            head = new List_item<T>(st);
            head.Next = cur;
            cur.Previous = head;
            count += 1;
        }
        public bool DeleteByValue(T value)
        {
            List_item<T> cur = head;
            if (cur.Value.Equals(value))
            {
                head.Value = cur.Next.Value;
                head.Next = cur.Next.Next;
                count -= 1;
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
                    count -= 1;
                    return true;
                }
            }
            return false;
        }
        public void Reverse()
        {
            if (count == 1 || count == 0)
                return;
            if (count == 2)
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
            List_item<T> to_the_end = tail;
            int dl = count, i = 0;
            List_item<T> from_start = head;
            while (i < dl / 2)
            {
                if (!from_start.Value.Equals(to_the_end.Value))
                    return false;
                i += 1;
                from_start = from_start.Next;
                to_the_end = to_the_end.Previous;
            }
            return true;
        }
        // индексация: слева направо от 0
        public List_item<T> ReturnElementByIndex(int ind)
        {
            List_item<T> cur = head;
            int i = 0;
            if (ind < 0 || ind >= count)
                throw new IndexOutOfRangeException();
            while (cur != null)
            {
                if (ind == i)
                    return cur;
                i += 1;
                cur = cur.Next;
            }
            return cur;
        }
        private void Append(T st)
        {
            if (count == 0)
            {
                this.head.Value = st;
                tail = head;
            }
            else
            {
                if (count == 1)
                {
                    tail = new List_item<T>(st);
                    tail.Previous = head;
                    head.Next = tail;
                } else
                {
                    List_item<T> cur = new List_item<T>(st);
                    tail.Next = cur;
                    cur.Previous = tail;
                    tail = cur;
                }
            }
            count += 1;
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
 
        public object Clone()
        {
            MyList<T> clone_list = new MyList<T>();
            List_item<T> cur = this.head;
            
            while (cur != null)
            {
                clone_list.Append(cur.Value);
                cur = cur.Next;
            }
            return clone_list;
        }
        public void Add(T item)
        {
            this.Append(item);
        }
        public bool Contains(T item)
        {
            List_item<T> cur = this.head;
            while(cur != null)
            {
                if (cur.Value.Equals(item))
                    return true;
                cur = cur.Next;
            }
            return false;
        }
        public void CopyTo(T[] array, int arrayIndex=0)
        {
            List_item<T> cur = this.head;
            int index = 0;
            while (cur != null)
            {
                array[index + arrayIndex] = cur.Value;
                cur = cur.Next;
                index += 1;
            }
        }
        public bool Remove(T item)
        {
            return this.DeleteByValue(item);
        }
        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
