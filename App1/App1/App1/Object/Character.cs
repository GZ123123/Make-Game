using System;
using System.IO;
using System.Reflection;

using Xamarin.Forms;

using SkiaSharp;
using SkiaSharp.Views.Forms;
using System.Collections.Generic;

namespace App1.Object
{
    class Character
    {
        private SKPoint _current_pos;
        private int _width;
        private int _height;
        
        private SKBitmap _stand;
        private List<SKBitmap> _move;
        private float countFrame = 0;

        public SKPaint paint;
        public bool is_stand = true;


        public SKPoint Current_pos { get => _current_pos; set => _current_pos = value; }
        public int Width { get => _width; set => _width = value; }

        public Character(SKPoint start_from, int width = 40, int height = 50, SKPaint paint = null)
        {
            if (_stand == null)
            {
                _move = new List<SKBitmap>();

                Assembly assembly = GetType().GetTypeInfo().Assembly;
                using (Stream stream = assembly.GetManifestResourceStream("App1.Media.stand.png"))
                    _stand = SKBitmap.Decode(stream);
                using (Stream stream = assembly.GetManifestResourceStream("App1.Media.move1.png"))
                    _move.Add(SKBitmap.Decode(stream));
                using (Stream stream = assembly.GetManifestResourceStream("App1.Media.move2.png"))
                    _move.Add(SKBitmap.Decode(stream));
                using (Stream stream = assembly.GetManifestResourceStream("App1.Media.move3.png"))
                    _move.Add(SKBitmap.Decode(stream));
                using (Stream stream = assembly.GetManifestResourceStream("App1.Media.move4.png"))
                    _move.Add(SKBitmap.Decode(stream));
                using (Stream stream = assembly.GetManifestResourceStream("App1.Media.move5.png"))
                    _move.Add(SKBitmap.Decode(stream));
            }
            _current_pos = new SKPoint( start_from.X -width,start_from.Y - height);
            _width = width;
            _height = height;
            this.paint = paint;
        }
        public Character(float x, float y, int width = 25, int height = 40, SKPaint paint = null)
        {
            if (_stand == null)
            {
                _move = new List<SKBitmap>();
                Assembly assembly = GetType().GetTypeInfo().Assembly;
                using (Stream stream = assembly.GetManifestResourceStream("App1.Media.stand.png"))
                    _stand = SKBitmap.Decode(stream); 
                using (Stream stream = assembly.GetManifestResourceStream("App1.Media.move1.png"))
                    _move.Add(SKBitmap.Decode(stream)); 
                using (Stream stream = assembly.GetManifestResourceStream("App1.Media.move2.png"))
                    _move.Add(SKBitmap.Decode(stream)); 
                using (Stream stream = assembly.GetManifestResourceStream("App1.Media.move3.png"))
                    _move.Add(SKBitmap.Decode(stream)); 
                using (Stream stream = assembly.GetManifestResourceStream("App1.Media.move4.png"))
                    _move.Add(SKBitmap.Decode(stream)); 
                using (Stream stream = assembly.GetManifestResourceStream("App1.Media.move5.png"))
                    _move.Add(SKBitmap.Decode(stream)); 
            }
            _current_pos = new SKPoint(x - width, y - height);
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
            SKRect rect = SKRect.Create(0, 0, _width, _height);
            //canvas.DrawRect(0, 0, _width, _height, paint);
            using (SKPaint paint = new SKPaint())
            {
                //paint.Color = paint.Color.WithAlpha((byte)(0xFF * (1 - progress)));
                //canvas.DrawRect(rect, paint);
                if (is_stand) {
                    countFrame = 0;
                    canvas.DrawBitmap(_stand, rect, paint);
                }
                else
                {
                    countFrame += 0.1f;
                    countFrame %= 5;
                    canvas.DrawBitmap(_move[(int)countFrame], rect, paint);
                }
            }
            

            canvas.Restore();
        }
    }
}
