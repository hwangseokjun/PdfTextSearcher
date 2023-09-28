using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfTextSearcher.Models
{
    public class TextFragment
    {
        public SearchResult Parent { get; private set; }
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public string Text { get; private set; }
        public int CenterX => (X + Width) / 2;
        public int CenterY => (Y + Height) / 2;

        public TextFragment(SearchResult parent, int x, int y, int width, int height, string text)
        {
            Parent = parent;
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Text = text;
        }

        public void SetText(string text)
        {
            Text = text;
        }
    }
}