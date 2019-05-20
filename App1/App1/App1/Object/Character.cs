using System;
using System.IO;
using System.Reflection;

using Xamarin.Forms;

using SkiaSharp;
using SkiaSharp.Views.Forms;

namespace App1.Object
{
    class Character
    {
        private SKPoint _current_pos;
        private int _width;
        private int _height;

        public SKPaint paint;

        public static SKBitmap CharactorBitsMap;

        public SKPoint Current_pos { get => _current_pos; set => _current_pos = value; }
        public int Width { get => _width; set => _width = value; }

        public Character(SKPoint start_from, int width = 40, int height = 50, SKPaint paint = null)
        {
            if(CharactorBitsMap == null)
            {
                Assembly assembly = GetType().GetTypeInfo().Assembly;
                using (Stream stream = assembly.GetManifestResourceStream(
                                    "App1.Media.charactor.png")){
                    CharactorBitsMap = SKBitmap.Decode(stream);
                }
            }
            _current_pos = new SKPoint( start_from.X -width,start_from.Y - height);
            _width = width;
            _height = height;
            this.paint = paint;
        }
        public Character(float x, float y, int width = 25, int height = 40, SKPaint paint = null)
        {
            if (CharactorBitsMap == null)
            {
                Assembly assembly = GetType().GetTypeInfo().Assembly;
                using (Stream stream = assembly.GetManifestResourceStream("App1.Media.charactor.png"))
                {
                    CharactorBitsMap = SKBitmap.Decode(stream);
                }
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
                canvas.DrawRect(rect, paint);
                //canvas.DrawBitmap(CharactorBitsMap, rect, paint);
            }
            

            canvas.Restore();
        }
    }
}
