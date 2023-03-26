using System;
using System.Collections.Generic;
using System.Text;

namespace дз_по_тетсированию_Двусвязных_списков
{
    class ValueNotInListError : Exception { }
    class MyList<T>
    {
        public List_item head = new List_item(null);
        public List_item tail = new List_item(null);
        public MyList() { }
        public MyList(T s) { head.Value = Convert.ToString(s); tail = head; }
        public MyList(T[] mas_s)
        {
            if (mas_s.Length == 0)
                return;
            if (mas_s.Length == 1)
            {
                head.Value = Convert.ToString(mas_s[0]); tail = head;
                return;
            }
            List_item cur = head;
            head.Value = Convert.ToString(mas_s[0]);
            for (int i = 1; i < mas_s.Length; i += 1)
            {
                if (i + 1 != mas_s.Length)
                {
                    List_item elem = new List_item(Convert.ToString(mas_s[i]));
                    elem.Previous = cur;
                    cur.Next = elem;
                    cur = elem;
                }
                else
                {
                    List_item elem = new List_item(Convert.ToString(mas_s[i]));
                    elem.Previous = cur;
                    cur.Next = elem;
                    tail = elem;
                }
            }
        }
        public int FindIndexByValue(T value, bool from_head = true)
        {
            if (from_head)
            {
                int ind = 0;
                List_item cur = head;
                while (cur != null)
                {
                    if (cur.Value == Convert.ToString(value))
                        return ind;
                    ind += 1;
                    cur = cur.Next;
                }
                return -1;
            } else
            {
                int ind = this.Length() - 1;
                List_item cur = tail;
                while (cur != null)
                {
                    if (cur.Value == Convert.ToString(value))
                        return ind;
                    ind -= 1;
                    cur = cur.Previous;
                }
                return -1;
            }
        }
        public void AddBefore(T value, T before_what, bool from_head = true, int add_count = 1)
        {
            if (from_head)
            {
                List_item cur = head;
                while (cur != null)
                {
                    if (cur.Value == Convert.ToString(before_what))
                    {
                        add_count -= 1;
                        List_item elem = new List_item(Convert.ToString(value));
                        elem.Next = cur;
                        elem.Previous = cur.Previous;
                        
                        cur.Previous = elem;
                        elem.Previous.Next = elem;
                    }
                    if (add_count == 0)
                        break;
                    cur = cur.Next;
                }
            }
            else
            {
                List_item cur = tail;
                while (cur != null)
                {
                    if (cur.Value == Convert.ToString(before_what))
                    {
                        add_count -= 1;
                        List_item elem = new List_item(Convert.ToString(value));
                        elem.Next = cur;
                        elem.Previous = cur.Previous;

                        cur.Previous = elem;
                        elem.Previous.Next = elem;
                    }
                    if (add_count == 0)
                        break;
                    cur = cur.Previous;
                }
            }
        }
        public void RemoveFirst()
        {
            head = head.Next;
            head.Previous = null;
        }
        public void RemoveLast()
        {
            tail = tail.Previous;
            tail.Next = null;
        }
        public void AddAfter(T value, T after_what, bool from_head = true, int add_count = 1)
        {
            if (from_head)
            {
                List_item cur = head;
                while (cur != null)
                {
                    if (cur.Value == Convert.ToString(after_what))
                    {
                        add_count -= 1;
                        List_item elem = new List_item(Convert.ToString(value));
                        elem.Next = cur.Next;
                        elem.Previous = cur;
                        cur.Next = elem;
                        elem.Next.Previous = elem;
                    }
                    if (add_count == 0)
                        break;
                    cur = cur.Next;
                }
            } else
            {
                List_item cur = tail;
                while (cur != null)
                {
                    if (cur.Value == Convert.ToString(after_what))
                    {
                        add_count -= 1;
                        List_item elem = new List_item(Convert.ToString(value));
                        elem.Next = cur.Next;
                        elem.Previous = cur;
                        cur.Next = elem;
                        elem.Next.Previous = elem;
                    }
                    if (add_count == 0)
                        break;
                    cur = cur.Previous;
                }
            }
            
        }
        public void Clear()
        {
            head = null;
            tail = null;
        }
        public bool CheckIn(T value)
        {
            List_item cur = head;
            while (cur != null)
            {
                if (cur.Value == Convert.ToString(value))
                    return true;
                cur = cur.Next;
            }
            return false;
        }
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
        public string this[int index]
        {
            get
            {
                return ReturnElementByIndex(index).Value;
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
        public void AddToTop(T st)
        {
            List_item cur = head;
            head = new List_item(Convert.ToString(st));
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
        public void DeleteByValue(T value)
        {
            List_item cur = head;
            if (cur.Value == Convert.ToString(value))
            {
                head.Value = cur.Next.Value;
                head.Next = cur.Next.Next;
                return;
            }
            if (tail.Value == Convert.ToString(value))
            {
                tail.Previous.Next = null;
                tail = tail.Previous;
                return;
            }
            while (cur.Next != null)
            {
                List_item previous = cur;
                cur = cur.Next;
                if (cur.Value == Convert.ToString(value))
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
        public void Add(T st)
        {
            if (this.Length() == 1 && this.head.Value is null)
            {
                this.head.Value = Convert.ToString(st);
            }
            else
            {
                if (tail.Next is null && tail.Previous is null && head.Value != Convert.ToString(st))
                {
                    tail.Value = Convert.ToString(st);
                    tail.Previous = head;
                    head.Next = tail;
                }
                else
                {
                    List_item cur = head;
                    if (cur.Value == Convert.ToString(st))
                        return;
                    while (cur.Next != null)
                    {
                        cur = cur.Next;
                        if (cur.Value == Convert.ToString(st))
                            return;
                    }
                    List_item elem = new List_item(Convert.ToString(st));
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
        public void Append(T st)
        {
            if (this.Length() == 1 && this.head.Value is null)
            {
                this.head.Value = Convert.ToString(st);
            }
            else
            {
                List_item temp = head;
                while (temp.Next != null)
                {
                    temp = temp.Next;
                }
                List_item elem = new List_item(Convert.ToString(st));
                elem.Previous = temp;
                temp.Next = elem;
                tail = elem;
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
        public void PrintsIndicated(int index)
        {
            int i = 0;
            List_item temp = head;
            while (temp.Next != null)
            {
                if (i == index)
                    Console.Write($"({temp.Value}) ");
                else
                    Console.Write($"{temp.Value} ");
                i += 1;
                temp = temp.Next;
            }
            if (i == index)
                Console.Write($"({temp.Value})\n");
            else
                Console.Write($"{temp.Value}\n");
        }
    }
}
