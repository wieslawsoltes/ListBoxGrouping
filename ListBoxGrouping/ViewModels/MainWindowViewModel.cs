﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ReactiveUI;

namespace ListBoxGrouping.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ObservableCollection<ItemViewModel>? _items;
        private ObservableCollection<GroupingViewModel>? _groupedItems;

        public ObservableCollection<ItemViewModel>? Items
        {
            get => _items;
            set => this.RaiseAndSetIfChanged(ref _items, value);
        }

        public ObservableCollection<GroupingViewModel>? GroupedItems
        {
            get => _groupedItems;
            set => this.RaiseAndSetIfChanged(ref _groupedItems, value);
        }

        public MainWindowViewModel()
        {
            _items = new ObservableCollection<ItemViewModel>();

            var totalGroups = 1_000;
            var i = 0;
            var minItems = 3;
            var maxItems = 10;
            var rand = new Random();

            for (var year = 0; year < totalGroups; year++)
            {
                var totalItems = rand.Next(minItems, maxItems);

                for (var j = 0; j < totalItems; j++)
                {
                    _items.Add(new() { Name = $"Test {i++}", Year = year });
                }
            }

            _groupedItems = new ObservableCollection<GroupingViewModel>(
                _items.GroupBy(x => x.Year)
                    .Select(x => new GroupingViewModel() 
                    {
                        IsExpanded = true,
                        Grouping = x
                    }));
        }
    }
}
