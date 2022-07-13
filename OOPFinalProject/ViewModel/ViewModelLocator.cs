using BookLIB;
using BookLIB.Class;
using BookLIB.InterFaces;
using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;

namespace OOPFinalProject.ViewModel
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);



            SimpleIoc.Default.Register<IDataService, ItemCollection>();
            SimpleIoc.Default.Register<IDataBook, ItemCollectionBook>();
            SimpleIoc.Default.Register<IDataJournal, ItemCollectionJournal>();


            //SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<Obsercollection2>();
            SimpleIoc.Default.Register<UserControlCustomerViewModel>();
            SimpleIoc.Default.Register<UserControlManagerViewModel>();
            SimpleIoc.Default.Register<DataEntyViewModel>();
        }

        // public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();
        public UserControlCustomerViewModel UserControlCustomer => ServiceLocator.Current.GetInstance<UserControlCustomerViewModel>();
        public UserControlManagerViewModel UserControlManager => ServiceLocator.Current.GetInstance<UserControlManagerViewModel>();
        public DataEntyViewModel DataEnty => ServiceLocator.Current.GetInstance<DataEntyViewModel>();
        public Obsercollection2 Collection2 => ServiceLocator.Current.GetInstance<Obsercollection2>();

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}