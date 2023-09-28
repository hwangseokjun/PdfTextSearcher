using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfTextSearcher.Models
{
    public class SearchResult
    {
        public int PageNumber { get; set; }
        public ObservableCollection<TextFragment> TextFragments { get; set; }

        public SearchResult()
        {
            TextFragments = new ObservableCollection<TextFragment>();
        }
    }
}