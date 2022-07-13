using BookLIB;
using BookLIB.InterFaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Windows;

namespace OOPFinalProject.ViewModel
{
    public class UserControlManagerViewModel : ViewModelBase //The class after on displaying the filter operation
    {
        public string InputName { get; set; }
        public string InputAuthor { get; set; }
        public long InputISBN { get; set; }
        public int InputPrice { get; set; }

        public bool CheckboxName { get; set; }
        public bool CheckboxAuthor { get; set; }
        public bool CheckboxISBN { get; set; }
        public bool CheckboxPrice { get; set; }

        public readonly IDataService dataService;
        public readonly IDataBook dataBook;
        public readonly IDataJournal dataJournal;
        public Obsercollection2 Col { get; set; }
        public RelayCommand BtnSearch { get; set; }
        public RelayCommand BtnShowList { get; set; }

        public UserControlManagerViewModel(IDataService dataService, IDataBook dataBook, IDataJournal dataJournal, Obsercollection2 col)
        {
            Col = col;
            this.dataService = dataService;
            this.dataBook = dataBook;
            this.dataJournal = dataJournal;
            BtnSearch = new RelayCommand(Filtering);
            BtnShowList = new RelayCommand(Filtering);
        }

        public void Filtering()
        {
            try
            {
                dataService.Filter(InputName, InputAuthor, InputISBN, InputPrice, CheckboxName, CheckboxAuthor
                    , CheckboxISBN, CheckboxPrice);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Configuration", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
