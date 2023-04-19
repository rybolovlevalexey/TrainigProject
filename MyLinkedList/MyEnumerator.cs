using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace дз_по_тетсированию_Двусвязных_списков
{
    class MyEnumerator<T> : IEnumerator<T>
    {
        public MyList<T> mylist;

        public List_item<T> current;
        public T Current
        {
            get { return current.Value; }
        }

        object IEnumerator.Current => throw new NotImplementedException();

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            current = current.Next;
            if (current != null)
                return true;
            return false;
        }

        public void Reset()
        {
            current = mylist.head;
        }
    }
}
