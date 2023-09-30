using PdfTextSearcher.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PdfTextSearcher.ViewModels
{
    public class PdfTabViewModel : ViewModelBase
    {
        private readonly Mediator _mediator;
        public ThumbnailsViewModel ThumbnailsViewModel { get; private set; }
        public BookmarkViewModel BookmarkViewModel { get; private set; }
        public SearchResultViewModel SearchResultViewModel { get; set; }

        public ICommand SelectThumbnailsTabCommand { get; private set; }
        public ICommand SelectBookmarkTabCommand { get; private set; }
        public ICommand SelectSearchResultTabCommand { get; private set; }

        public PdfTabViewModel(Mediator mediator)
        {
            _mediator = mediator;
            ThumbnailsViewModel = new ThumbnailsViewModel(_mediator);
            BookmarkViewModel = new BookmarkViewModel(_mediator);
            SearchResultViewModel = new SearchResultViewModel(_mediator);
            SelectThumbnailsTabCommand = new RelayCommand(ExecuteSelectThumbnailsTab);
            SelectBookmarkTabCommand = new RelayCommand(ExecuteSelectBookmarkTab);
            SelectSearchResultTabCommand = new RelayCommand(ExecuteSelectSearchResultTab);
        }

        private void ExecuteSelectThumbnailsTab(object parameter)
        {
            BookmarkViewModel.IsVisible = false;
            SearchResultViewModel.IsVisible = false;
            ThumbnailsViewModel.IsVisible = true;
        }

        private void ExecuteSelectBookmarkTab(object parameter)
        {
            ThumbnailsViewModel.IsVisible = false;
            SearchResultViewModel.IsVisible = false;
            BookmarkViewModel.IsVisible = true;
        }

        private void ExecuteSelectSearchResultTab(object parameter)
        {
            BookmarkViewModel.IsVisible = false;
            ThumbnailsViewModel.IsVisible = false;
            SearchResultViewModel.IsVisible = true;
        }
    }
}