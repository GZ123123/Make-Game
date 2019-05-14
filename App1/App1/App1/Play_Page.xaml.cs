using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SkiaSharp.Views.Forms;
using SkiaSharp;

namespace App1
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Play_Page : ContentPage
	{
        private int angle = 0;

		public Play_Page ()
		{
			InitializeComponent ();

            Device.StartTimer(TimeSpan.FromSeconds(1f/60 ), () =>
             {
                 canvasView.InvalidateSurface();
                 return true;
             });
        }

        bool ShowFill = false;

        private void SKCanvasView_PaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            SKImageInfo info = e.Info;
            SKSurface surface = e.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            SKPaint paint = new SKPaint()
            {
                Style = SKPaintStyle.Stroke,
                Color = SKColors.Blue,
                StrokeWidth = 10
            };

            if (ShowFill)
            {
                paint.Color = SKColors.Red;
            }

            //canvas.DrawCircle(info.Width / 2, info.Height / 2,100, paint);

            angle += 5;
            angle %= 100;

            canvas.Save();

            canvas.Translate(info.Width / 2, info.Height / 2);
            canvas.RotateDegrees(angle);


            canvas.DrawLine( 0, 0,0, -120, paint);
            canvas.Restore();
            

        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            ShowFill ^= true;
        }
    }
}