﻿using System;
using System.Collections.Generic;
using System.Text;

using SkiaSharp;

namespace App1.Object
{
    interface IMovableObject : IDrawableObject
    {
        void translate();
    }
}