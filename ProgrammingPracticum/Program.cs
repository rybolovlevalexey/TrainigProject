using System;
using System.Collections.Generic;
using System.Text;

namespace Урок18._11._22
{
    class List_item
    {
        public string Value;
        public List_item Next = null;
        public List_item(string s) 
        {
            Value = s;
        }
    }
}
