using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfTextSearcher.Models
{
    public struct MoveLocation
    {
        public int PageNumber { get; private set; }
        public int CenterX { get; private set; }
        public int CenterY { get; private set; }
        public int Dummy { get; private set; }

        public MoveLocation(int pageNumber, int centerX = 0, int centerY = 0)
        {
            PageNumber = pageNumber;
            CenterX = centerX;
            CenterY = centerY;
            Dummy = 0;
        }
    }
}