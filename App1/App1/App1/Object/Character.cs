using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace App1.Object
{
    class Character
    {
        private SKPoint _current_pos;
        private int _width;
        private int _height;

        public SKPaint paint;

        public SKPoint Current_pos { get => _current_pos; set => _current_pos = value; }
        public int Width { get => _width; set => _width = value; }

        public Character(SKPoint start_from, int width = 20, int height = 20, SKPaint paint = null)
        {
            _current_pos = start_from;
            _width = width;
            _height = height;
            this.paint = paint;
        }
        public Character(float x, float y, int width = 20, int height = 20, SKPaint paint = null)
        {
            _current_pos = new SKPoint(x, y);
            _width = width;
            _height = height;
            this.paint = paint;
        }
        /*
         * translate Object to new position 
         */
        public virtual void moveTo(SKPoint new_pos)
        {
            _current_pos = new_pos;
        }
        
        /* 
         * lùi x xuống 10 đơn vị
         * del(-10,0);
        */
        public virtual void translateTo(SKPoint del)
        {
            _current_pos = SKPoint.Add(_current_pos, del);
        }
        public virtual void draw(SKCanvas canvas)
        {
            canvas.Save();
            canvas.Translate(_current_pos);
            canvas.DrawRect(0, 0, _width, _height, paint);
            canvas.Restore();
        }
    }
}
