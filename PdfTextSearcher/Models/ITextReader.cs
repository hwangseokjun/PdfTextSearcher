using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfTextSearcher.Models
{
    public interface ITextReader
    {
        List<TextFragment> GetAllTextFragments();
    }
}
