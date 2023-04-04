using System;
using System.Collections.Generic;
using System.Text;

namespace дз_по_тетсированию_Двусвязных_списков
{
    interface ICollection<T> : IEnumerable
    {
        int Count { get; set; }
        void CopyTo(T copy_array)  // надо передавать массив, в который будет происходить копирование
        {

        }
    }
}
