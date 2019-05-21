using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using System.IO;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace App1
{
    public partial class App : Application
    {
        public static int SCREEN_WIDTH;
        public static int SCREEN_HEIGHT;
        static public string fileName;

        public App()
        {
            InitializeComponent();
            //fileName = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "score.txt");
            //if (File.Exists(fileName))
            //{
            //    //File.WriteAllText(fileName, "0");
            //    File.Create("score.txt");
            //    File.WriteAllText(App.fileName, "0");
            //}
            setUp();

            MainPage = new NavigationPage(new MainPage());

        }

        private void setUp()
        {
            var mainDisplayInfo = DeviceDisplay.MainDisplayInfo;

            //var orientation = mainDisplayInfo.Orientation;

            // Rotation (0, 90, 180, 270)
            //var rotation = mainDisplayInfo.Rotation;

            // Width (in pixels)
            SCREEN_WIDTH = Convert.ToInt32(mainDisplayInfo.Width);

            // Height (in pixels)
            SCREEN_HEIGHT = Convert.ToInt32(mainDisplayInfo.Height);

            //// Screen density
            //var density = mainDisplayInfo.Density;
        }

        protected override void OnStart()
        {
            
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
