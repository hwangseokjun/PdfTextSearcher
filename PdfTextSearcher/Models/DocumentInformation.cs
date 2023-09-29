using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfTextSearcher.Models
{
    public struct DocumentInformation
    {
        public int CurrentPage { get; set; }
        public int TotalPage { get; set; }
        public string FileName { get; set; }
        public int ZoomFactor { get; set; }
        public RotateAngle RotateAngle { get; set; }
    }
}
