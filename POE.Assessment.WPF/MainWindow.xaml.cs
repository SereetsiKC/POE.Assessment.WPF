using POE.Assessment.WPF.Pages;
using System.Windows;

namespace POE.Assessment.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            UserInputs userInputs = new UserInputs(this);
            this.Content = userInputs;
        }
    }
}
