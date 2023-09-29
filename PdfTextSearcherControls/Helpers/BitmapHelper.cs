﻿using System;
using System.Drawing;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using PdfTextSearcherControls.Core;

namespace PdfTextSearcherControls.Helpers
{
    internal static class BitmapHelper
    {
        public static BitmapSource ToBitmapSource(this Image image)
        {
            return ToBitmapSource(image as Bitmap);
        }

        /// <summary>
        /// Convert an IImage to a WPF BitmapSource. The result can be used in the Set Property of Image.Source
        /// </summary>
        /// <param name="bitmap">The Source Bitmap</param>
        /// <returns>The equivalent BitmapSource</returns>
        public static BitmapSource ToBitmapSource(this System.Drawing.Bitmap bitmap)
        {
            if (bitmap == null) return null;

            using (var source = (Bitmap)bitmap.Clone())
            {
                var hBitmap = source.GetHbitmap(); //obtain the Hbitmap

                var bs = Imaging.CreateBitmapSourceFromHBitmap(
                    hBitmap,
                    IntPtr.Zero,
                    Int32Rect.Empty,
                    BitmapSizeOptions.FromEmptyOptions());

                NativeMethods.DeleteObject(hBitmap); //release the HBitmap
                bs.Freeze();

                return bs;
            }
        }

        public static BitmapSource ToBitmapSource(this byte[] bytes, int width, int height, int dpiX, int dpiY)
        {
            var result = BitmapSource.Create(
                            width,
                            height,
                            dpiX,
                            dpiY,
                            PixelFormats.Bgra32,
                            null /* palette */,
                            bytes,
                            width * 4 /* stride */);
            result.Freeze();

            return result;
        }
    }
}