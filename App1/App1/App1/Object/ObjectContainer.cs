using System;
using System.Collections.Generic;
using System.Text;
using SkiaSharp;

namespace App1.Object
{
    // giống như list nhưng có các thuộc tính được xây sẵn 
    class ObjectContainer<T> : IDrawableObject
    {
        protected List<T> _object;
        public int Count { get => _object.Count; }
        public ObjectContainer()
        {
            _object = new List<T>();
        }
        public virtual void add(T add_object)
        {
            _object.Add(add_object);
        }

        public void draw(SKCanvas canvas)
        {
            _object.ForEach(drawObject =>
            {
                ((IDrawableObject)drawObject).draw(canvas);
            });
        }

        public virtual T remove(int index,int count = 1)
        {
            if(count == 1)
            {
                T _ = _object[index];
                _object.RemoveAt(index);
                return _;
            } else {
                return _object[index];
            }
        }
    }
}
