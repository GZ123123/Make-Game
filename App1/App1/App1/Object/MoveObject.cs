using System;
using System.Collections.Generic;
using System.Text;
using SkiaSharp;
using App1.help;

namespace App1.Object
{
    class MoveObject<T> : IMovableObject
    {
        private T _object;
        public IObjectContainer<T> container;

        public MoveObject(object copy_object)
        {
            if (copy_object != null)
                _object = (T)copy_object ;
        }

        public void add()
        {
            container.add(_object);
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
