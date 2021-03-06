﻿using System;
using System.Collections.Generic;
using System.Text;
using SkiaSharp;

namespace App1.Object
{
    class Rect : IDrawableObject
    {
        private SKPoint _current_pos;
        private int _width;
        private int _height;

        public SKPaint paint;

        public SKPoint Current_pos { get => _current_pos; set => _current_pos = value; }
        public int Width { get => _width; set => _width = value; }

        public Rect(SKPoint start_from,int width = 100,int height = 100, SKPaint paint = null)
        {
            _current_pos = start_from;
            _width = width;
            _height = height;
            this.paint = paint;
        }
        public Rect(float x,float y,int width = 100, int height = 100, SKPaint paint = null)
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

        public virtual void moveTo(Rect to)
        {
            _current_pos = to._current_pos;
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
