using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SkiaSharp.Views.Forms;
using SkiaSharp;
using App1.Object;

namespace App1
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Play_Page : ContentPage
	{
        private List<Stand> _stands;

        bool ShowFill = false;

        SKPaint paint = new SKPaint()
        {
            Style = SKPaintStyle.Stroke,
            Color = SKColors.Blue,
            StrokeWidth = 10
        };

        public Play_Page ()
		{
			InitializeComponent ();

            SKPoint current_pos = new SKPoint(0,200);

            _stands = new List<Stand>();

            Device.StartTimer(TimeSpan.FromSeconds(5f), () =>
              {
                  current_pos = SKPoint.Add(current_pos, new SKSize(100, 50));
                  _stands.Add(new Stand(current_pos, paint: paint));
                  if (_stands.Count > 3) _stands.RemoveAt(0);
                  canvasView.InvalidateSurface();
                  return true;
              });
        }

        private void SKCanvasView_PaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            SKImageInfo info = e.Info;
            SKSurface surface = e.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();
            if(_stands.Count != 0)
                _stands.ForEach(st=>st.draw(canvas));
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            ShowFill ^= true;
        }
    }
}