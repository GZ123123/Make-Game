using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using App1.Object;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Tmp_Page : ContentPage
    {
        private string p ="asdasdas";
        public Tmp_Page()
        {
            InitializeComponent();


        }

        private void SKCanvasView_PaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            SKImageInfo info = e.Info;
            SKSurface surface = e.Surface;
            SKCanvas canvas = surface.Canvas;

            using(var paint  = new SKPaint())
            {
                paint.TextSize = 64.0f;
                paint.IsAntialias = true;
                paint.Color = new SKColor(0x42, 0x81, 0xA4);
                paint.IsStroke = false;

                canvas.DrawText(p, info.Width / 2, info.Height / 2, paint);
            }
        }

        private void TapGestureRecognizer_Tapped(object sender, SKTouchEventArgs e)
        {
            // we have handled these events

            e.Handled = true;

            // update the UI
            ((SKCanvasView)sender).InvalidateSurface();
        }
    }


}