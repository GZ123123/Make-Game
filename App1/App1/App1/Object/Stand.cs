using System;
using System.Collections.Generic;
using System.Text;
using SkiaSharp;

namespace App1.Object
{
    class Stand : Rect
    {
        public Stand(SKPoint start_from, int width = 100, SKPaint paint = null)
            : base(start_from, width, App.SCREEN_HEIGHT - Convert.ToInt32(start_from.Y), paint)
        { }
        public Stand(float x,float y,int width = 100, SKPaint paint = null) 
            : base(x,y,width, App.SCREEN_HEIGHT - Convert.ToInt32(y) , paint)
        { }
    }
}
