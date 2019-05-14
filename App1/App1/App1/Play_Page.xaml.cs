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
		public Play_Page ()
		{
			InitializeComponent ();
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
                StrokeWidth = 20
            };

            //canvas.DrawCircle(info.Width / 2, info.Height / 2,100, paint);

            canvas.DrawLine(info.Width / 2 - 120, info.Height / 2,info.Width / 2 + 120,info.Height / 2 -20, paint);

            canvas.RotateDegrees(120);

        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

        }
    }
}