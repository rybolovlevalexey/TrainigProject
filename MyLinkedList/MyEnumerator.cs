using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace дз_по_тетсированию_Двусвязных_списков
{
    class MyEnumerator<T> : IEnumerator<T>
    {
        public List_item<T> current;
        public List_item<T> Head_;
        private bool start_flag = true;

        public MyEnumerator(List_item<T> Head)
        {
            current = null;
            Head_ = Head;
        }
        public T Current
        {
            get { return current.Value; }
        }

        object IEnumerator.Current { get { return current; } }

        public void Dispose()
        {
            
        }

        public bool MoveNext()
        {
            if (start_flag)
            {
                start_flag = false;
                current = Head_;
                if (current.Next == null)
                    return false;
                return true;
            }
            if (current.Next == null)
                return false;
            current = current.Next;
            return true;
        }

        public void Reset()
        {
            current = null;
            start_flag = true;
        }
    }
}
