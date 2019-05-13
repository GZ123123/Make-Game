using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SkiaSharp;
using SkiaSharp.Views.Forms;

namespace App1
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Game1 : ContentPage
	{
		public Game1 ()
		{
			InitializeComponent ();
		}
        public void OnCanvasViewPaintSurface(object sender,SKPaintSurfaceEventArgs e)
        {

        }
        public void OnCanvasViewTapped(object sender, TappedEventArgs e)
        {

        }
    }
}