using App1.Object;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace App1.Inteface
{
    interface IObject : IDrawableObject
    {
        void translateTo(SKPoint del);

        void moveTo(SKPoint new_pos);

    }
}
