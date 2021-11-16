using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using ReactiveUI;

namespace ListBoxGrouping.ViewModels
{
    public class ItemViewModel : ViewModelBase
    {
        private string?_name;
        private int _year;

        public string? Name
        {
            get => _name;
            set => this.RaiseAndSetIfChanged(ref _name, value);
        }
        
        public int Year
        {
            get => _year;
            set => this.RaiseAndSetIfChanged(ref _year, value);
        }
    }

    public class MainWindowViewModel : ViewModelBase
    {
        private ObservableCollection<ItemViewModel>? _items;
        private List<IGrouping<int, ItemViewModel>>? _groupedItems;

        public ObservableCollection<ItemViewModel>? Items
        {
            get => _items;
            set => this.RaiseAndSetIfChanged(ref _items, value);
        }

        public List<IGrouping<int, ItemViewModel>>? GroupedItems
        {
            get => _groupedItems;
            set => this.RaiseAndSetIfChanged(ref _groupedItems, value);
        }

        public MainWindowViewModel()
        {
            _items = new ObservableCollection<ItemViewModel>()
            {
                // new() { Name = "Test1", Year = 1997 },
                // new() { Name = "Test2", Year = 1997 },
                // new() { Name = "Test3", Year = 1997 },
                // new() { Name = "Test4", Year = 2015 },
                // new() { Name = "Test5", Year = 2015 },
                // new() { Name = "Test6", Year = 2015 },
                // new() { Name = "Test7", Year = 1975 },
                // new() { Name = "Test8", Year = 1975 },
                // new() { Name = "Test9", Year = 1975 },
                // new() { Name = "Test10", Year = 2005 },
                // new() { Name = "Test11", Year = 2005 },
                // new() { Name = "Test12", Year = 2005 },
            };

            var i = 0;

            for (var year = 0; year < 1000; year++)
            {
                for (var j = 0; j < 3; j++)
                {
                    _items.Add(new() { Name = $"Test {i++}", Year = year });
                }
            }

            _groupedItems = _items.GroupBy(x => x.Year).ToList();
        }
    }
}
