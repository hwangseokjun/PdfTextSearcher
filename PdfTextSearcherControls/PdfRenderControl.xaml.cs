using PdfTextSearcherControls.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PdfTextSearcherControls
{
    /// <summary>
    /// PdfRenderControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class PdfRenderControl : UserControl
    {
        public static readonly DependencyProperty SourceProperty =
               DependencyProperty.Register("Source", typeof(string), typeof(PdfRenderControl), new PropertyMetadata(null, OnDocumentSourceChanged));
        public static readonly DependencyProperty ZoomFactorProperty =
            DependencyProperty.Register("ZoomFactor", typeof(int), typeof(PdfRenderControl), new PropertyMetadata(null, OnZoomFactorChanged));
        public static readonly DependencyProperty PdfRotationProperty =
            DependencyProperty.Register("PdfRotation", typeof(PdfRotation), typeof(PdfRenderControl), new PropertyMetadata(null, OnPdfRotationChanged));
        public static readonly DependencyProperty CurrentPageProperty =
            DependencyProperty.Register("CurrentPage", typeof(int), typeof(PdfRenderControl), new PropertyMetadata(0, OnCurrentPageChanged));
        public static readonly DependencyProperty DisplayModeProperty =
            DependencyProperty.Register("DisplayMode", typeof(PdfViewerPagesDisplayMode), typeof(PdfRenderControl), new PropertyMetadata(1, OnDisplayModeChanged));
        public static readonly DependencyProperty ZoomModeProperty =
            DependencyProperty.Register("ZoomMode", typeof(PdfViewerZoomMode), typeof(PdfRenderControl), new PropertyMetadata(0, OnZoomModeChanged));

        public string Source
        {
            get => (string)GetValue(SourceProperty);
            set => SetValue(SourceProperty, value);
        }
        public int ZoomFactor
        {
            get => (int)GetValue(ZoomFactorProperty);
            set => SetValue(ZoomFactorProperty, value);
        }
        public PdfRotation PdfRotation
        {
            get => (PdfRotation)GetValue(PdfRotationProperty);
            set => SetValue(PdfRotationProperty, value);
        }
        public int CurrentPage
        {
            get => (int)GetValue(CurrentPageProperty);
            set => SetValue(CurrentPageProperty, value);
        }
        public PdfViewerPagesDisplayMode DisplayMode
        {
            get => (PdfViewerPagesDisplayMode)GetValue(DisplayModeProperty);
            set => SetValue(DisplayModeProperty, value);
        }
        public PdfViewerZoomMode ZoomMode
        {
            get => (PdfViewerZoomMode)GetValue(ZoomModeProperty);
            set => SetValue(ZoomModeProperty, value);
        }

        public PdfRenderControl()
        {
            InitializeComponent();
            Unloaded += PdfRenderControl_Unloaded;
        }

        private void PdfRenderControl_Unloaded(object sender, RoutedEventArgs e)
        {
            Renderer?.Dispose();
        }

        private static void OnDocumentSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is PdfRenderControl pdfRenderControl)
            {
                if (pdfRenderControl.Renderer != null && e.NewValue is string filePath)
                {
                    pdfRenderControl.Renderer.OpenPdf(filePath);
                }
            }
        }

        private static void OnZoomFactorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is PdfRenderControl pdfRenderControl && e.NewValue is int zoomFactor)
            {
                pdfRenderControl.Renderer.SetZoom(zoomFactor);
            }
        }

        private static void OnPdfRotationChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is PdfRenderControl pdfRenderControl && e.NewValue is PdfRotation rotation)
            {
                pdfRenderControl.Renderer.Rotate = rotation;
            }
        }

        private static void OnCurrentPageChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is PdfRenderControl pdfRenderControl && e.NewValue is int currentPage)
            {
                pdfRenderControl.Renderer.GotoPage(currentPage);
            }
        }

        private static void OnDisplayModeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is PdfRenderControl pdfRenderControl && e.NewValue is PdfViewerPagesDisplayMode displayMode)
            {
                pdfRenderControl.Renderer.PagesDisplayMode = displayMode;
            }
        }

        private static void OnZoomModeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is PdfRenderControl pdfRenderControl && e.NewValue is PdfViewerZoomMode zoomMode)
            {
                pdfRenderControl.Renderer.SetZoomMode(zoomMode);
            }
        }
    }
}