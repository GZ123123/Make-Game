using System;
using System.Collections.Generic;
using System.Text;

namespace App1.Object
{
    interface IObjectContainer<T>
    {
        void add(T add_object);
        List<T> remove(int index, int count = 1);
        T remove(int index);
    }
}
