using System;
using System.Collections.Generic;
using System.Text;
using App1.Inteface;
using SkiaSharp;

namespace App1.Object
{
    class Tree : IObject
    {
        private SKPoint _start_from;
        private float _height;
        private float _width = 7;

        public SKPaint paint;
        private bool _is_rotate;
        private int _degrees = 0;
        private double _del = 0.1;

        public int Degrees { get => _degrees; set => _degrees = value; }
        public float Height { get => _height; set => _height = value; }
        public bool Is_rotate { get => _is_rotate; set => _is_rotate = value; }
        public float Width { get => _width; set => _width = value; }

        public Tree(SKPoint start_from,float height)
        {
            _start_from = start_from;
            _height = height;
        }
        public Tree(float x,float y, float height)
        {
            _start_from = new SKPoint(x,y);
            _height = height;
        }
        public Tree(Tree tree)
        {
            _start_from = tree._start_from;
            _height = tree._height;
            _width = tree._width;
            _degrees = tree._degrees;

            paint = tree.paint;
        }

        public void draw(SKCanvas canvas)
        {
            if (paint.StrokeWidth == 0) paint.StrokeWidth = _width;

            canvas.Save();

            canvas.Translate(_start_from);

            if (_is_rotate && rotate(canvas))
                Play_Page.fall = true;

            SKPoint zero = new SKPoint(0, 0);
            canvas.DrawLine(zero, SKPoint.Subtract(zero, new SKSize(0, _height)), paint);

            canvas.Restore();
        }

        // look like đạt
        public void updateHight(int val)
        {
            _height += val;
            if (_height > App.SCREEN_HEIGHT/3*2)
            {
                _height = 0;
            }
        }

        public virtual void moveTo(SKPoint new_pos)
        {
            _start_from = new_pos;
        }

        public void translateTo(SKPoint del)
        {
            throw new NotImplementedException();
        }

        private bool rotate(SKCanvas canvas)
        {
            canvas.RotateDegrees(_degrees);
            _degrees += Convert.ToInt32(_del += 0.1);
            if (_del > 10) _del = 10;

            if (_degrees >= 90) _degrees = 90;

            if (_degrees >= 90) return true;

            return false;

        }
        public void rotation()
        {
            _is_rotate = true;
            _degrees = 0;
            _del = 1;
            //_start_from = new SKPoint(this._start_from.X,this._start_from.Y-4);
        }
    }
}
