﻿using PdfTextSearcherControls.Enums;
using System;

namespace PdfTextSearcherControls
{
    public partial class ScrollPanel
    {
        /// <summary>
        /// Zooms the PDF document in one step.
        /// </summary>
        public void ZoomIn()
        {
            SetZoom(Zoom * ZoomFactor);
        }

        /// <summary>
        /// Zooms the PDF document out one step.
        /// </summary>
        public void ZoomOut()
        {
            SetZoom(Zoom / ZoomFactor);
        }

        public void SetZoom(double zoom)
        {
            Zoom = Math.Min(Math.Max(zoom, ZoomMin), ZoomMax);
            ZoomMode = PdfViewerZoomMode.None;
            OnPagesDisplayModeChanged();
        }

        public void SetZoomMode(PdfViewerZoomMode mode)
        {
            ZoomMode = mode;
            OnPagesDisplayModeChanged();
        }
    }
}