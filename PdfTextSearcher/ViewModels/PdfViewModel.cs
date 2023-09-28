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
    public class PdfViewModel : ViewModelBase, IDisposable
    {
        private readonly Mediator _mediator;
        private string _fileName;
        private string _filePath;
        private double _zoomFactor;
        private int _totalPage;
        private int _currentPage;
        private RotateAngle _rotateAngle;
        private bool _isDisposed;

        public string FileName
        {
            get => _fileName;
            set => SetProperty(ref _fileName, value);
        }
        public string FilePath
        {
            get => _filePath;
            set => SetProperty(ref _filePath, value);
        }
        public double ZoomFactor
        {
            get => _zoomFactor;
            set => SetProperty(ref _zoomFactor, value);
        }
        public int TotalPage
        {
            get => _totalPage;
            set => SetProperty(ref _totalPage, value);
        }
        public int CurrentPage
        {
            get => _currentPage;
            set => SetProperty(ref _currentPage, value);
        }
        public RotateAngle RotateAngle
        {
            get => _rotateAngle;
            set => SetProperty(ref _rotateAngle, value);
        }

        public ICommand ZoomInCommand { get; private set; }
        public ICommand ZoomOutCommand { get; private set; }
        public ICommand RotateLeftCommand { get; private set; }
        public ICommand RotateRightCommand { get; private set; }
        public ThumbnailsViewModel ThumbnailsViewModel { get; private set; }
        public BookmarkViewModel BookmarkViewModel { get; private set; }
        public SearchResultViewModel SearchResultViewModel { get; set; }

        public PdfViewModel(Mediator mediator)
        {
            _mediator = mediator;
            ZoomInCommand = new RelayCommand(ExecuteZoomIn, CanExecuteZoomIn);
            ZoomOutCommand = new RelayCommand(ExecuteZoomOut, CanExecuteZoomOut);
            RotateLeftCommand = new RelayCommand(ExecuteRotateLeft, CanExecuteRotateLeft);
            RotateRightCommand = new RelayCommand(ExecuteRotateRight, CanExecuteRotateRight);
        }

        private void ExecuteZoomIn(object parameter)
        {
            throw new NotImplementedException();
        }

        private bool CanExecuteZoomIn(object parameter)
        {
            // 실행 가능한지 여부를 결정하는 로직을 구현합니다.
            return true;
        }

        private void ExecuteZoomOut(object parameter)
        {
            throw new NotImplementedException();
        }

        private bool CanExecuteZoomOut(object parameter)
        {
            // 실행 가능한지 여부를 결정하는 로직을 구현합니다.
            return true;
        }

        private void ExecuteRotateLeft(object parameter)
        {
            throw new NotImplementedException();
        }

        private bool CanExecuteRotateLeft(object parameter)
        {
            // 실행 가능한지 여부를 결정하는 로직을 구현합니다.
            return true;
        }

        private void ExecuteRotateRight(object parameter)
        {
            throw new NotImplementedException();
        }

        private bool CanExecuteRotateRight(object parameter)
        {
            // 실행 가능한지 여부를 결정하는 로직을 구현합니다.
            return true;
        }

        private void MovePage(PageMoveLocation obj)
        {
            throw new NotImplementedException();
        }

        private void SearchText(string keyword)
        {
            SearchResultViewModel.SearchResults.SearchText(keyword);
        }

        private void OnDocumentSelectionChanged(object obj)
        {
            if (obj is PdfViewModel comparer && comparer == this)
            {
                _mediator.OnPageMovableObjectClicked += MovePage;
                _mediator.OnKeywordSearchTriggered += SearchText;
            }
            else
            {
                _mediator.OnPageMovableObjectClicked -= MovePage;
                _mediator.OnKeywordSearchTriggered -= SearchText;
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_isDisposed)
            {
                throw new ObjectDisposedException("");
            }

            if (disposing)
            {
                _mediator.OnPageMovableObjectClicked -= MovePage;
            }

            _isDisposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}