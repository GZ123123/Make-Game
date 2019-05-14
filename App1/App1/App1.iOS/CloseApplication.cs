using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using App1.iOS;
using Foundation;
using UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(CloseApplication))]
namespace App1.iOS
{
    public class CloseApplication : ICloseApplication
    {
        public void closeApplication()
        {
            Thread.CurrentThread.Abort();
        }
    }
}