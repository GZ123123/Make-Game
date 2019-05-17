using System;
using System.Collections.Generic;
using System.Text;

namespace App1.help
{
    class Helper
    {
        public static T MyCast<T>(object _object)
        {
            //Convert.ChangeType(_object,);
            return (T)_object;
        }
    }
}
