using System;
using System.Collections.Generic;
using System.Text;

namespace дз_по_тетсированию_Двусвязных_списков
{
    interface IEnumerator
    {
        bool MoveNext(List_item elem) { return elem.Next != null; }
        List_item Current { get; }
    }
}
