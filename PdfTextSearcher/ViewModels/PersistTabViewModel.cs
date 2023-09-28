using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfTextSearcher.ViewModels
{
    public class PersistTabViewModel : ViewModelBase
    {
        public PdfViewModel SelectedDocument { get; set; }
        public ObservableCollection<PdfViewModel> Documents { get; set; }

        public PersistTabViewModel()
        {
            Documents = new ObservableCollection<PdfViewModel>();
        }
    }
}