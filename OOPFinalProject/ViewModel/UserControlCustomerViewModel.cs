using BookLIB;
using BookLIB.InterFaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using static BookLIB.Book;
using static BookLIB.Journal;

namespace OOPFinalProject.ViewModel
{
    public class UserControlCustomerViewModel : ViewModelBase //The class followed on the presentation of the List View
    {
        #region FieldForEdit
        private AbstractItem selectItem;

        public AbstractItem SelectItem
        {
            get
            {
                return selectItem;
            }
            set
            {
                Set(ref selectItem, value);
            }
        }

        private string editName;
        public string EditName { get => editName; set => Set(ref editName, value); }


        private string editAuthor;
        public string EditAuthor { get => editAuthor; set => Set(ref editAuthor, value); }


        private int editCopies;
        public int EditCopies { get => editCopies; set => Set(ref editCopies, value); }


        private DateTime editDatePrint;
        public DateTime EditDatePrint { get => editDatePrint; set => Set(ref editDatePrint, value); }


        private double editDiscount;
        public double EditDiscount { get => editDiscount; set => Set(ref editDiscount, value); }


        private int editStock;
        public int EditStock { get => editStock; set => Set(ref editStock, value); }


        private CatgoryType editCatgory;
        public CatgoryType EditCatgory { get => editCatgory; set => Set(ref editCatgory, value); }


        private CatgoryTypeJornal editCatgoryjournal;
        public CatgoryTypeJornal EditCatgoryjournal { get => editCatgoryjournal; set => Set(ref editCatgoryjournal, value); }


        private double editPrice;

        public double EditPrice { get => editPrice; set => Set(ref editPrice, value); }

        private long editIsbm;

        public long EditIsbm { get => editIsbm; set => Set(ref editIsbm, value); }
        #endregion

        #region FieldForCheckEdit

        private bool checkboxEditName;
        public bool CheckboxEditName { get => checkboxEditName; set => Set(ref checkboxEditName, value); }


        private bool checkboxEditAuthor;
        public bool CheckboxEditAuthor { get => checkboxEditAuthor; set => Set(ref checkboxEditAuthor, value); }


        private bool checkboxEditIsbm;
        public bool CheckboxEditIsbm { get => checkboxEditIsbm; set => Set(ref checkboxEditIsbm, value); }


        private bool checkboxEditPrice;
        public bool CheckboxEditPrice { get => checkboxEditPrice; set => Set(ref checkboxEditPrice, value); }


        private bool checkboxEditCopies;
        public bool CheckboxEditCopies { get => checkboxEditCopies; set => Set(ref checkboxEditCopies, value); }


        private bool checkboxEditDatePrint;
        public bool CheckboxEditDatePrint { get => checkboxEditDatePrint; set => Set(ref checkboxEditDatePrint, value); }


        private bool checkboxEditDiscount;
        public bool CheckboxEditDiscount { get => checkboxEditDiscount; set => Set(ref checkboxEditDiscount, value); }


        private bool checkboxEditStock;
        public bool CheckboxEditStock { get => checkboxEditStock; set => Set(ref checkboxEditStock, value); }


        private bool checkboxEditCatgory;
        public bool CheckboxEditCatgory { get => checkboxEditCatgory; set => Set(ref checkboxEditCatgory, value); }


        private bool checkboxEditCatgoryjournal;
        public bool CheckboxEditCatgoryjournal { get => checkboxEditCatgoryjournal; set => Set(ref checkboxEditCatgoryjournal, value); }



        #endregion




        public readonly IDataService dataService;
        public readonly IDataBook dataBook;
        public readonly IDataJournal dataJournal;
        public Obsercollection2 ListView { get; set; }
        public RelayCommand EditBtn { get; set; }

        private ICollectionView _myCollection;

        public ICollectionView MyCollection
        {
            get { return _myCollection; }
            set
            {
                _myCollection = value;
            }
        }

        public UserControlCustomerViewModel(IDataService dataService, IDataBook dataBook, IDataJournal dataJournal, Obsercollection2 col)
        {
            this.dataService = dataService;
            this.dataBook = dataBook;
            this.dataJournal = dataJournal;
            ListView = col;
            dataService.RefrashEvent += RefreshList;
            dataBook.MessageBoxMiss += AddMessegeIfNull;
            dataJournal.MessageBoxMiss += AddMessegeIfNull;

            MyCollection = CollectionViewSource.GetDefaultView(ListView.ListView);
            dataBook.AddBookEvent += AddBookToViewList;
            dataJournal.AddJournalEvent += AddJournalToViewList;
            dataBook.MessageBoxAdd += AddMessageBoxViewList;
            dataJournal.MessageBoxAdd += AddMessageBoxViewList;
            dataService.MessageIfNotFilter += AddMesageIfnotFilter;
            EditBtn = new RelayCommand(EditTheItem);
        }

        private void AddMesageIfnotFilter() => MessageBox.Show("Failed filter operation, please try again!", "Configuration", MessageBoxButton.OK, MessageBoxImage.Warning);

        private void AddMessegeIfNull() => MessageBox.Show("Error! You need to fill in all the fields", "Configuration", MessageBoxButton.OK, MessageBoxImage.Warning);
        private void AddMessageBoxViewList() => MessageBox.Show("Can't have the same ISBN twice!", "Configuration", MessageBoxButton.OK, MessageBoxImage.Warning);

        private void EditTheItem()
        {
            MyCollection.Refresh();
            dataService.EditItems(ref selectItem, editName, editAuthor, editIsbm, editPrice, editCopies
                , editDatePrint, editDiscount, editStock, editCatgory, editCatgoryjournal
                , checkboxEditName, checkboxEditAuthor, checkboxEditIsbm, checkboxEditPrice, checkboxEditCopies
                , checkboxEditDatePrint, checkboxEditDiscount, checkboxEditStock, checkboxEditCatgory, checkboxEditCatgoryjournal);
        }

        private void RefreshList(List<AbstractItem> items)
        {

            if (items != null && items.Count != 0)
            {
                ListView.ListView.Clear();

                foreach (AbstractItem item in items)
                {
                    ListView.ListView.Add(item);
                }
            }
            else
            {
                MessageBox.Show("Your selection was not found!", "Configuration", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void AddJournalToViewList(AbstractItem journalItem) => ListView.ListView.Add(journalItem);

        private void AddBookToViewList(AbstractItem bookItem) => ListView.ListView.Add(bookItem);

        public Array Catgorybook => Enum.GetValues(typeof(CatgoryType));
        public Array CatgoryJournal => Enum.GetValues(typeof(CatgoryTypeJornal));
    }
}
