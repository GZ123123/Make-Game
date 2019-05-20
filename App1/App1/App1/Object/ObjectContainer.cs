using System;
using System.Collections.Generic;
using System.Text;
using SkiaSharp;

namespace App1.Object
{
    // giống như list nhưng có các thuộc tính được xây sẵn 
    class ObjectContainer<T> : IDrawableObject,IObjectContainer<T>
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
            if(_object!= null && _object.Count > 0)
                _object.ForEach(drawObject =>
                {
                    ((IDrawableObject)drawObject).draw(canvas);
                });
        }
        public virtual T remove(int index)
        {
                T _ = _object[index];
                _object.RemoveAt(index);
                return _;  
        }
        public virtual List<T> remove(int index,int count)
        {
            var _ = _object.GetRange(index, count);
            _object.RemoveRange(index, count);
            return _;
        }
    }
}
