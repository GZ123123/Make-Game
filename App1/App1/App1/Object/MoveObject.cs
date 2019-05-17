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
            _type = copy_object.GetType();

            var __ = Convert.ChangeType(copy_object, _type);
            var _ = Helper.MyCast<_type>(_object);
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
