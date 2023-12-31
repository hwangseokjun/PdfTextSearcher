﻿using Microsoft.Win32;
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
    public class MainViewModel : ViewModelBase
    {
        private readonly Mediator _mediator;
        private string _keyword;
        private int _currentPage;
        private int _zoomFactor;
        private string _fileName;

        public string Keyword
        {
            get => _keyword;
            set => SetProperty(ref _keyword, value);
        }
        public string FileName
        {
            get => _fileName;
            set => SetProperty(ref _fileName, value);
        }
        public int CurrentPage
        {
            get => _currentPage;
            set => SetProperty(ref _currentPage, value);
        }
        public int ZoomFactor
        {
            get => _zoomFactor;
            set => SetProperty(ref _zoomFactor, value);
        }
        public PersistTabViewModel PersistTabViewModel { get; set; }

        public ICommand OpenCommand { get; private set; }
        public ICommand SearchCommand { get; private set; }
        public ICommand ExportToExcelCommand { get; private set; }

        public MainViewModel()
        {
            _mediator = new Mediator();
            _mediator.OnDocumentSelectionChanged += OnDocumentSelectionChanged;
            PersistTabViewModel = new PersistTabViewModel();
            OpenCommand = new RelayCommand(ExecuteOpen);
            SearchCommand = new RelayCommand(ExecuteSearch, CanExecuteSearch);
            ExportToExcelCommand = new RelayCommand(ExecuteExportToExcel, CanExecuteExportToExcel);
        }

        private void OnDocumentSelectionChanged(object obj)
        {
            // 도큐먼트의 원래 상태로 작업창 되돌리기, 헷갈릴 수 있으므로 컨트롤 설계부터 시작하기
            //if (obj is DocumentInformation info) 
            //{
            //    FileName = info.FileName;
            //    CurrentPage = info.CurrentPage;
            //    ZoomFactor = info.ZoomFactor;
            //}
            throw new NotImplementedException();
        }

        private void ExecuteOpen(object parameter)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "PDF files (*.pdf)|*.pdf",
                Title = "Open PDF File",
                Multiselect = true,
            };

            if (openFileDialog.ShowDialog() is true)
            {
                string[] filePaths = openFileDialog.FileNames;
                _mediator.NotifyDocumentLoaded(filePaths);
            }
        }

        private void ExecuteSearch(object parameter)
        {
            if (string.IsNullOrWhiteSpace(Keyword))
            {
                return;
            }

            _mediator.NotifyKeywordSearchTriggered(Keyword);
        }

        private bool CanExecuteSearch(object parameter)
        {
            // 실행 가능한지 여부를 결정하는 로직을 구현합니다.
            return true;
        }

        private void ExecuteExportToExcel(object parameter)
        {
            throw new NotImplementedException();
        }

        private bool CanExecuteExportToExcel(object parameter)
        {
            // 실행 가능한지 여부를 결정하는 로직을 구현합니다.
            return true;
        }
    }
}