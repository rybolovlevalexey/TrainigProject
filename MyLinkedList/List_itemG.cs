using System;
using System.Collections.Generic;
using System.Text;

namespace дз_по_тетсированию_Двусвязных_списков
{
    class List_item<T>
    {
        public T Value;
        public List_item<T> Next = null;
        public List_item<T> Previous = null;
        public List_item(T s)
        {
            Value = s;
        }
    }
}
