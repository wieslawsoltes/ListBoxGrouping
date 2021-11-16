using System.Linq;
using ReactiveUI;

namespace ListBoxGrouping.ViewModels
{
    public class GroupingViewModel : ViewModelBase
    {
        private bool _isExpanded;
        private IGrouping<int, ItemViewModel>? _grouping;

        public bool IsExpanded
        {
            get => _isExpanded;
            set => this.RaiseAndSetIfChanged(ref _isExpanded, value);
        }

        public IGrouping<int, ItemViewModel>? Grouping
        {
            get => _grouping;
            set => this.RaiseAndSetIfChanged(ref _grouping, value);
        }
    }
}
