using System;
using System.Threading;
using System.Diagnostics;

namespace дз_по_тетсированию_Двусвязных_списков
{
    class Program
    {
        static void Main(string[] args)
        {
            string res = Test1();
        }

        static public string Test1() // for class MyList
        {
            string ans = "";
            Stopwatch spwch = new Stopwatch();
            spwch.Start();
            string[] words = { "the", "fox", "jumps", "over", "the", "dog" };
            MyList ml = new MyList(words);
            Console.WriteLine("The linked list values:");
            ml.Prints();
            
            ml.AddToTop("today");
            Console.WriteLine("\nTest 1: Add 'today' to beginning of the list:");
            ml.Prints();

            string first = ml.head.Value;
            ml.head = ml.head.Next;
            ml.Append(first);
            Console.WriteLine("\nTest 2: Move first node to be last node:");
            ml.Prints();

            ml.tail.Value = "yesterday";
            Console.WriteLine("\nTest 3: Change the last node to 'yesterday':");
            ml.Prints();

            List_item cur = new List_item(ml.tail.Value);
            ml.tail = ml.tail.Previous;
            ml.tail.Next = null;
            cur.Next = ml.head;
            ml.head = cur;
            ml.head.Next.Previous = ml.head;
            Console.WriteLine("\nTest 4: Move last node to be first node:");
            ml.Prints();

            ml.head = ml.head.Next;
            ml.head.Previous = null;
            int ind_Indicate = ml.Length() - 1;
            cur = ml.tail;
            while (cur != null)
            {
                if (cur.Value == "the")
                    break;
                cur = cur.Previous;
                ind_Indicate -= 1;
            }
            Console.WriteLine("\nTest 5: Indicate last occurence of 'the':");
            ml.PrintsIndicated(ind_Indicate);

            cur = ml.tail;
            while (cur != null)
            {
                if (cur.Value == "the")
                {
                    List_item lazy_ = new List_item("lazy");
                    List_item old_ = new List_item("old");
                    List_item after_cur = cur.Next;
                    
                    cur.Next = lazy_;
                    lazy_.Next = old_;
                    old_.Next = after_cur;

                    after_cur.Previous = old_;
                    old_.Previous = lazy_;
                    lazy_.Previous = cur;

                    if (after_cur is null)
                        ml.tail = lazy_;
                    break;
                }
                cur = cur.Previous;
            }
            Console.WriteLine("\nTest 6: Add 'lazy' and 'old' after 'the':");
            ml.PrintsIndicated(ind_Indicate);

            ind_Indicate = 0;
            cur = ml.head;
            while (cur != null)
            {
                if (cur.Value == "fox")
                    break;
                cur = cur.Previous;
                ind_Indicate += 1;
            }
            Console.WriteLine("\nTest 7: Indicate the 'fox' node:");
            ml.PrintsIndicated(ind_Indicate);

            cur = ml.head;
            while (cur != null)
            {
                if (cur.Value == "fox")
                {
                    List_item quick_ = new List_item("quick");
                    List_item brown_ = new List_item("brown");
                    List_item before_cur = cur.Previous;

                    cur.Previous = brown_;
                    brown_.Previous = quick_;
                    quick_.Previous = before_cur;

                    brown_.Next = cur;
                    quick_.Next = brown_;
                    if (before_cur is null)
                        ml.head = quick_;
                    else
                        before_cur.Next = quick_;
                }
                cur = cur.Next;
            }
            Console.WriteLine("\nTest 8: Add 'quick' and 'brown' before 'fox':");
            ind_Indicate += 2;
            ml.PrintsIndicated(ind_Indicate);

            spwch.Stop();
            return ans;
        }
    }
}
