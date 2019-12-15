using Prism.Mvvm;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace HSLSample.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private LinearGradientBrush _linearGradientBrush;
        public LinearGradientBrush LinearGradientBrush
        {
            get { return _linearGradientBrush; }
            set { SetProperty(ref _linearGradientBrush, value); }
        }

        private SolidColorBrush _solidColorBrush = new SolidColorBrush(HSLConverter.HSL2RGB(0, 1, 0.5));
        public SolidColorBrush SolidColorBrush
        {
            get { return _solidColorBrush; }
            set { SetProperty(ref _solidColorBrush, value); }
        }

        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel()
        {
            //StartHSLGradation();
            //_ = Task.Delay(5000);
            //StopHSLGradation();

            var myLinearGradientBrush = new LinearGradientBrush();
            myLinearGradientBrush.StartPoint = new Point(0, 0);
            myLinearGradientBrush.EndPoint = new Point(1, 1);
            myLinearGradientBrush.GradientStops.Add(new GradientStop(Colors.Yellow, 0.0));
            myLinearGradientBrush.GradientStops.Add(new GradientStop(Colors.Red, 0.25));
            myLinearGradientBrush.GradientStops.Add(new GradientStop(Colors.Blue, 0.75));
            myLinearGradientBrush.GradientStops.Add(new GradientStop(Colors.LimeGreen, 1.0));

            LinearGradientBrush = myLinearGradientBrush;
        }

        private void StartHSLGradation()
        {
            _ = HSLGradationAsync();
        }

        private void StopHSLGradation()
        {
            SolidColorBrush = new SolidColorBrush(Color.FromRgb(0, 0, 0));
        }

        public async Task HSLGradationAsync()
        {
            while (true)
            {
                double i = 0;
                for (i = 0; i < 1; i += 0.01)
                {
                    var c = HSLConverter.HSL2RGB(i, 1, 0.5);
                    SolidColorBrush = new SolidColorBrush(c);
                    await Task.Delay(10);
                }
            }
        }
    }
}
