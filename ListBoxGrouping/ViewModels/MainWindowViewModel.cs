using System.Collections.ObjectModel;
using System.Linq;
using ReactiveUI;

namespace ListBoxGrouping.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ObservableCollection<ItemViewModel>? _items;
        private ObservableCollection<IGrouping<int, ItemViewModel>>? _groupedItems;

        public ObservableCollection<ItemViewModel>? Items
        {
            get => _items;
            set => this.RaiseAndSetIfChanged(ref _items, value);
        }

        public ObservableCollection<IGrouping<int, ItemViewModel>>? GroupedItems
        {
            get => _groupedItems;
            set => this.RaiseAndSetIfChanged(ref _groupedItems, value);
        }

        public MainWindowViewModel()
        {
            _items = new ObservableCollection<ItemViewModel>();

            var totalGroups = 1_000;
            var i = 0;

            for (var year = 0; year < totalGroups; year++)
            {
                for (var j = 0; j < 3; j++)
                {
                    _items.Add(new() { Name = $"Test {i++}", Year = year });
                }
            }

            _groupedItems = new ObservableCollection<IGrouping<int, ItemViewModel>>(_items.GroupBy(x => x.Year));
        }
    }
}
