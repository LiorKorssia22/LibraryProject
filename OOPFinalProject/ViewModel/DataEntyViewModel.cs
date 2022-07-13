using BookLIB.InterFaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using static BookLIB.Book;
using static BookLIB.Journal;

namespace OOPFinalProject.ViewModel
{
    public class DataEntyViewModel : ViewModelBase //The class after on entering data into the system
    {
        #region Prop Book

        private string _itemName;
        public string ItemName
        {
            get => _itemName;
            set => Set(ref _itemName, value);
        }

        private string _itemAuthor;
        public string ItemAuthor
        {
            get => _itemAuthor;
            set { Set(ref _itemAuthor, value); }
        }

        private long _itemIsbm;
        public long ItemISBM
        {
            get => _itemIsbm;
            set { Set(ref _itemIsbm, value); }
        }

        private double _itemPrice;
        public double ItemPrice
        {
            get => _itemPrice;
            set { Set(ref _itemPrice, value); }
        }

        private int _itemCopie;
        public int ItemCopie
        {
            get => _itemCopie;
            set { Set(ref _itemCopie, value); }
        }

        private DateTime _itemDateprint;
        public DateTime ItemDateprint
        {
            get => _itemDateprint;
            set { Set(ref _itemDateprint, value); }
        }

        private double _itemDicount;

        public double ItemDicount
        {
            get
            {
                if (Catgory.HasFlag(CatgoryType.Action) && _itemDicount < 10) _itemDicount = 10;
                if (Catgory.HasFlag(CatgoryType.romantic) && _itemDicount < 20) _itemDicount = 20;
                if (Catgory.HasFlag(CatgoryType.comedy) && _itemDicount < 15) _itemDicount = 15;
                if (Catgory.HasFlag(CatgoryType.Fictional) && _itemDicount < 22) _itemDicount = 22;
                if (Catgory.HasFlag(CatgoryType.news) && _itemDicount < 5) _itemDicount = 5;

                return _itemDicount;
            }
            set { Set(ref _itemDicount, value); }
        }

        private string _itemGenre;
        public string ItemGenre
        {
            get => _itemGenre;
            set { Set(ref _itemGenre, value); }
        }

        private int _itemInStock;
        public int ItemInStock
        {
            get => _itemInStock;
            set { Set(ref _itemInStock, value); }
        }
        private CatgoryType _catgory;
        public CatgoryType Catgory
        {
            get => _catgory;
            set { Set(ref _catgory, value); }
        }

        #endregion

        #region prop Journal
        private string _itemNameJournal;
        public string ItemNameJournal
        {
            get => _itemNameJournal;
            set => Set(ref _itemNameJournal, value);
        }

        private string _itemAuthorJournal;
        public string ItemAuthorJournal
        {
            get => _itemAuthorJournal;
            set { Set(ref _itemAuthorJournal, value); }
        }

        private long _itemISBMJournal;
        public long ItemISBMJournal
        {
            get => _itemISBMJournal;
            set { Set(ref _itemISBMJournal, value); }
        }

        private double _itemPriceJournal;
        public double ItemPriceJournal
        {
            get => _itemPriceJournal;
            set { Set(ref _itemPriceJournal, value); }
        }

        private int _itemCopieJournal = 0;
        public int ItemCopieJournal
        {
            get => _itemCopieJournal;
            set { Set(ref _itemCopieJournal, value); }
        }

        private DateTime _itemDateprintJournal;
        public DateTime ItemDateprintJournal
        {
            get => _itemDateprintJournal;
            set { Set(ref _itemDateprintJournal, value); }
        }

        private double _itemDicountJournal;

        public double ItemDicountJournal
        {
            get
            {
                if (ItemCatgoryJournal.HasFlag(CatgoryTypeJornal.Newspaper) && _itemDicountJournal < 50) _itemDicountJournal = 50;
                if (ItemCatgoryJournal.HasFlag(CatgoryTypeJornal.magazine) && _itemDicountJournal < 25) _itemDicountJournal = 25;
                if (ItemCatgoryJournal.HasFlag(CatgoryTypeJornal.Artistic) && _itemDicountJournal < 13) _itemDicountJournal = 13;
                if (ItemCatgoryJournal.HasFlag(CatgoryTypeJornal.Food) && _itemDicountJournal < 30) _itemDicountJournal = 30;
                if (ItemCatgoryJournal.HasFlag(CatgoryTypeJornal.Travel) && _itemDicountJournal < 40) _itemDicountJournal = 40;
                return _itemDicountJournal;
            }
            set { Set(ref _itemDicountJournal, value); }
        }



        private int _itemInStockJournal;
        public int ItemInStockJournal
        {
            get => _itemInStockJournal;
            set { Set(ref _itemInStockJournal, value); }
        }

        private string _itemGenreJournal;
        public string ItemGenreJournal
        {
            get => _itemGenreJournal;
            set { Set(ref _itemGenreJournal, value); }
        }

        private CatgoryTypeJornal _itemCatgoryJournal;
        public CatgoryTypeJornal ItemCatgoryJournal
        {
            get => _itemCatgoryJournal;
            set { Set(ref _itemCatgoryJournal, value); }
        }
        #endregion




        public readonly IDataService dataService;
        public readonly IDataBook dataBook;
        public readonly IDataJournal dataJournal;
        public RelayCommand AddBookCommand { get; set; }
        public RelayCommand AddJournalCommand { get; set; }

        public DataEntyViewModel(IDataService dataService, IDataBook dataBook, IDataJournal dataJournal)
        {
            this.dataService = dataService;
            this.dataBook = dataBook;
            this.dataJournal = dataJournal;
            AddJournalCommand = new RelayCommand(AddJournalToList);
            AddBookCommand = new RelayCommand(AddBookToList);
        }

        public void AddJournalToList()
        {
            dataJournal.AddJournalToList(ItemNameJournal, ItemAuthorJournal, ItemISBMJournal, ItemDateprintJournal, ItemCopieJournal, ItemPriceJournal
              , ItemDicountJournal, ItemInStockJournal, Catgory, ItemCatgoryJournal);

            ItemNameJournal = ""; ItemAuthorJournal = ""; ItemISBMJournal = 0; ItemDateprintJournal = default; ItemCopieJournal = 0; ItemPriceJournal = 0;
            ItemDicountJournal = 0; ItemInStockJournal = 0; Catgory = default; ItemCatgoryJournal = default;
        }

        public void AddBookToList()
        {
            dataBook.AddBookToList(ItemName, ItemAuthor, ItemISBM, ItemDateprint, ItemCopie, ItemPrice, ItemDicount, ItemInStock, Catgory, ItemCatgoryJournal);

            ItemName = ""; ItemAuthor = ""; ItemISBM = 0; ItemDateprintJournal = default; ItemCopie = 0; ItemPrice = 0; ItemDicount = 0; ItemInStock = 0; Catgory = default; ItemCatgoryJournal = default;
        }
        public Array Catgorybook => Enum.GetValues(typeof(CatgoryType));
        public Array CatgoryJournal => Enum.GetValues(typeof(CatgoryTypeJornal));
    }
}
