using Prism.Mvvm;

namespace HSLSample.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "HSLSample";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel()
        {
        }
    }
}
