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
}
