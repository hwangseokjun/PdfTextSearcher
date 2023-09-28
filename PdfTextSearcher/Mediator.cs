using PdfTextSearcher.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfTextSearcher
{
    public class Mediator
    {
        public event Action<string[]> OnDocumentLoaded;
        public event Action<object> OnDocumentSelectionChanged;
        public event Action<string> OnKeywordSearchTriggered;
        public event Action<PageMoveLocation> OnPageMovableObjectClicked;

        public void NotifyDocumentLoaded(string[] filePaths)
        {
            OnDocumentLoaded?.Invoke(filePaths);
        }

        public void NotifyDocumentSelectionChanged(object obj)
        {
            OnDocumentSelectionChanged?.Invoke(obj);
        }

        public void NotifyKeywordSearchTriggered(string keyword)
        {
            OnKeywordSearchTriggered?.Invoke(keyword);
        }

        public void NotifyPageMovableObjectClicked(PageMoveLocation pageMoveLocation)
        {
            OnPageMovableObjectClicked?.Invoke(pageMoveLocation);
        }
    }
}