using Avalonia.Controls;
using Visual_Lab_5.ViewModels;
using Avalonia.Interactivity;

namespace Visual_Lab_5.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.FindControl<Button>("OpenFileButton").Click += async delegate
            {
                var taskPathIn = new OpenFileDialog()
                {
                    Title = "Open file",
                    Filters = null
                }.ShowAsync((Window)this.VisualRoot);

                string[]? path = await taskPathIn;
                var contex = this.DataContext as MainWindowViewModel;
                if (path != null) contex.SetPath = string.Join(@"\", path);
            };

            this.FindControl<Button>("SaveFileButton").Click += async delegate
            {
                var taskPathOut = new SaveFileDialog()
                {
                    Title = "Choose file",
                    Filters = null
                }.ShowAsync((Window)this.VisualRoot);

                string? path2 = await taskPathOut;
                var contex = this.DataContext as MainWindowViewModel;
                if (path2 != null) contex.GetPath = path2;
            };


        }
        private void MyClickEventHandler(object sender, RoutedEventArgs e)
        {
            var w = new RegexWindow();
            w.DataContext = this.DataContext as MainWindowViewModel;
            w.ShowDialog((Window)this.VisualRoot);
        }
    }
}
