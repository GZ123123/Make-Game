using System;
using System.Collections.Generic;
using System.Text;
using SkiaSharp;
using App1.help;

namespace App1.Object
{
    class MoveObject : IMovableObject
    {
        private Type _type;
        private object _object;
        public object container;

        public MoveObject(object copy_object)
        {
            if (copy_object != null) { 
                _type = copy_object.GetType();
                _object = copy_object;
                var __ = Convert.ChangeType(copy_object, _type);
            }
        }

        public void translate()
        {
            throw new NotImplementedException();
        }

        public void draw(SKCanvas canvas)
        {
            throw new NotImplementedException();
        }
    }
}
