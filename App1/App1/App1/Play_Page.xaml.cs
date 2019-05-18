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
        #region public
        public static  bool fall = false;
        #endregion

        #region private
        private string p = "";
        private double count = 1;
        private bool is_long_press = false;
        // Paints
        private Random random = new Random();


        SKPaint rpaint;



        // draw trees not tree
        private Tree tree;

        // draw rects not rect
        //private Rect Crect;
        //private Rect Nrect;
        private Stand Crect;
        private Stand Nrect;

        // draw moveObjects 
        private List<MoveObject> moveObjects = new List<MoveObject>();

        // Container
        //private ObjectContainer<Rect> rects = new ObjectContainer<Rect>();
        private StandContainer stands = new StandContainer();
        private TreeContainer trees = new TreeContainer();

        // draw character
        private Character character;
        #endregion
        public Play_Page ()
		{
			InitializeComponent ();
            setUp();

            //rects.add(Crect);
            //rects.add(Nrect);

            stands.add(Crect);
            stands.add(Nrect);

            // test: remove Object from container
            //var __ = rects.remove(0);

            //rects.add(__);
            // end test
            trees.add(new Tree(tree));
            // Frame 
            Device.StartTimer(TimeSpan.FromSeconds(1f/60), () =>
            {
                ((SKCanvasView)canvasView).InvalidateSurface();
                return true;
            });

        }

        #region Set_UP
        void setUp()
        {
            Crect = new Stand(50, App.SCREEN_HEIGHT / 3 * 2);
            Nrect = new Stand(Crect.Current_pos.X + Crect.Width + 50 + random.Next(10, 500), App.SCREEN_HEIGHT / 3 * 2);
            tree = new Tree(100, App.SCREEN_HEIGHT / 3 * 2, 0);
            character = new Character(100 - tree.Width / 2, App.SCREEN_HEIGHT / 3 * 2);

            SKPaint paint = new SKPaint()
            {
                Color = SKColors.Black,
                IsStroke = true,
                Style = SKPaintStyle.Stroke,
            };

            rpaint = new SKPaint()
            {
                Color = SKColors.Red
            };

            SKPaint characterPain = new SKPaint()
            {
                Color = SKColors.Violet,
            };

            tree.paint = paint;
            Crect.paint = rpaint;
            Nrect.paint = rpaint;
            character.paint = characterPain;
        }
        #endregion

        #region Method
        void Red_LongPressing(object sender, MR.Gestures.LongPressEventArgs e)
        {
            count++;
            p = count+"LongPressing";
            is_long_press = true;
        }

        void Red_LongPressed(object sender, MR.Gestures.LongPressEventArgs e)
        {
            p = "LongPressed";
            if(is_long_press)
                trees.rotation();
            is_long_press = false;            
        }
        #endregion

        #region Update
        private void SKCanvasView_PaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            // set up environment
            SKImageInfo info = e.Info;
            SKSurface surface = e.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();
            // logic 
            if (is_long_press) trees.updateHeight(4);
            if (fall) {

                NextMove();
                fall = false;
            }

            // draw Object;
            stands.draw(canvas);

            trees.draw(canvas);
            
            character.draw(canvas);
        }

        private void NextMove()
        {
            trees.add(new Tree(tree));
            stands.add(new Stand(Crect.Current_pos.X + Crect.Width + 50 + random.Next(10, 500), App.SCREEN_HEIGHT / 3 * 2, paint:rpaint));
            if (trees.Count > 5) trees.remove(0, 3);
        }
        #endregion
    }
}