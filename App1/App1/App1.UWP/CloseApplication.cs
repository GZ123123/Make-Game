﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace App1.UWP
{
    public class CloseApplication : ICloseApplication
    {
        public void closeApplication()
        {
            Application.Current.Exit();
        }
    }
}
