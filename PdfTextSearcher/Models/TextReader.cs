using PdfTextSearcherControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfTextSearcher.Models
{
    public class TextReader : ITextReader
    {
        private readonly PdfRenderer _renderer;

        public TextReader(PdfRenderer renderer)
        {
            _renderer = renderer;
        }

        public List<TextFragment> GetAllTextFragments()
        {
            throw new NotImplementedException();
        }
    }
}
