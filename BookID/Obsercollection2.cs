using System.Collections.ObjectModel;

namespace BookLIB
{
    public class Obsercollection2 //This class after the link between the list View and the filter
    {
        public ObservableCollection<AbstractItem> ListView { get; set; } = new ObservableCollection<AbstractItem>();

    }
}
