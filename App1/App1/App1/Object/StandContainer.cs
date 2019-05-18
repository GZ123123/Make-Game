using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace App1.Object
{
    class StandContainer : ObjectContainer<Stand>
    {
        public Stand Last => _object.LastOrDefault();
        public Stand secondLast => (_object.Count > 1) ? _object[_object.Count - 2] : null; 
    }
}
