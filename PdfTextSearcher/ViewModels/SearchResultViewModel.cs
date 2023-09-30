using PdfTextSearcher.Commands;
using PdfTextSearcher.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PdfTextSearcher.ViewModels
{
    public class SearchResultViewModel : ViewModelBase
    {
        private readonly Mediator _mediator;
        private bool _isVisible;
        private TextFragment _selectedResult;

        public bool IsVisible
        {
            get => _isVisible;
            set => SetProperty(ref _isVisible, value);
        }
        public TextFragment SelectedResult
        {
            get => _selectedResult;
            set => SetProperty(ref _selectedResult, value);
        }
        public SearchResultCollection SearchResults { get; set; }

        public ICommand SelectCommand { get; private set; }

        public SearchResultViewModel(Mediator mediator)
        {
            _mediator = mediator;
            SearchResults = new SearchResultCollection();
            SelectCommand = new RelayCommand(ExecuteSelect);
        }

        private void ExecuteSelect(object parameter)
        {
            int pageNumber = SelectedResult.Parent.PageNumber;
            int centerX = SelectedResult.CenterX;
            int centerY = SelectedResult.CenterY;
            var moveLocation = new MoveLocation(pageNumber, centerX, centerY);
            _mediator.NotifyPageMovableObjectClicked(moveLocation);
        }
    }
}