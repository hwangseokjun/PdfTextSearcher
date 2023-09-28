using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfTextSearcher.Models
{
    public class SearchResultCollection
    {
        public ObservableCollection<SearchResult> Results { get; set; }

        public SearchResultCollection()
        {
            Results = new ObservableCollection<SearchResult>();
        }

        public void SearchText(string keyword)
        {
            throw new NotImplementedException();
        }

        public void ExportTo(string savePath)
        {
            throw new NotImplementedException();
        }
    }
}