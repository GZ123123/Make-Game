using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using App1.Droid;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(CloseApplication))]

namespace App1.Droid
{
    public class CloseApplication : ICloseApplication
    {
        public void closeApplication()
        {

            var activity = (Activity)Forms.Context;
            activity.FinishAffinity();
        }
    }
}

