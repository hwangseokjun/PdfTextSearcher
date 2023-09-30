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
    public class ThumbnailsViewModel : ViewModelBase
    {
        private readonly Mediator _mediator;
        private bool _isVisible;
        private Thumbnail _selectedThumbnail;

        public bool IsVisible
        {
            get => _isVisible;
            set => SetProperty(ref _isVisible, value);
        }
        public Thumbnail SelectedThumbnail
        {
            get => _selectedThumbnail;
            set => SetProperty(ref _selectedThumbnail, value);
        }
        public ObservableCollection<Thumbnail> Thumbnails { get; set; }

        public ICommand SelectCommand { get; private set; }

        public ThumbnailsViewModel(Mediator mediator)
        {
            _mediator = mediator;
            Thumbnails = new ObservableCollection<Thumbnail>();
            SelectCommand = new RelayCommand(ExecuteSelect);
        }

        private void ExecuteSelect(object parameter)
        {
            var moveLocation = new MoveLocation(SelectedThumbnail.PageNumber);
            _mediator.NotifyPageMovableObjectClicked(moveLocation);
        }
    }
}