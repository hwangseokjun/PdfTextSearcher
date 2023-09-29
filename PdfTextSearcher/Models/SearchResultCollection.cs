using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfTextSearcher.Models
{
    /// <summary>
    /// 어딘가에서 신호를 알려서 전체 문자의 값을 찾아와야함
    /// 이런 API를 만들 수 있는지?
    /// 문자를 전송하는 계층을 래핑하여 외부에 따로 만들어 둬야한다.
    /// </summary>
    public class SearchResultCollection
    {
        public ObservableCollection<SearchResult> Results { get; private set; }

        public SearchResultCollection()
        {
            Results = new ObservableCollection<SearchResult>();
        }

        public void SearchText(ITextReader textReader, string keyword)
        {
            List<TextFragment> texts = textReader.GetAllTextFragments();
            
        }

        public void ExportTo(string savePath)
        {
            throw new NotImplementedException();
        }
    }
}