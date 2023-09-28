using PdfTextSearcher.Commands;
using PdfTextSearcher.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PdfTextSearcher.ViewModels
{
    public class BookmarkViewModel : ViewModelBase
    {
        private readonly Mediator _mediator;
        private Bookmark _selectedBookmark;
        private bool _isVisible;

        public Bookmark SelectedBookmark
        {
            get => _selectedBookmark;
            set => SetProperty(ref _selectedBookmark, value);
        }
        public bool IsVisible
        {
            get => _isVisible;
            set => SetProperty(ref _isVisible, value);
        }
        public ObservableCollection<Bookmark> Bookmarks { get; set; }

        public ICommand SelectCommand { get; private set; }

        public BookmarkViewModel(Mediator mediator)
        {
            _mediator = mediator;
            Bookmarks = new ObservableCollection<Bookmark>();
            SelectCommand = new RelayCommand(ExecuteSelect);
        }

        private void ExecuteSelect(object parameter)
        {
            var moveLocation = new PageMoveLocation(SelectedBookmark.PageNumber);
            _mediator.NotifyPageMovableObjectClicked(moveLocation);
        }
    }
}
