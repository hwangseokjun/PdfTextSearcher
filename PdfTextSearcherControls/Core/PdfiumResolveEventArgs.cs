﻿using System;

namespace PdfTextSearcherControls.Core
{
    public class PdfiumResolveEventArgs : EventArgs
    {
        public string PdfiumFileName { get; set; }
    }

    public delegate void PdfiumResolveEventHandler(object sender, PdfiumResolveEventArgs e);
}