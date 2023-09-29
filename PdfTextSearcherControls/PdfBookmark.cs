using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfTextSearcherControls.Core
{
    public class PdfBookmark
    {
        public string Title { get; set; }
        public int PageIndex { get; set; }

        public PdfBookmarkCollection Children { get; }

        public PdfBookmark()
        {
            Children = new PdfBookmarkCollection();
        }

        public override string ToString()
        {
            return Title;
        }
    }

    public class PdfBookmarkCollection : Collection<PdfBookmark>
    {
    }
}