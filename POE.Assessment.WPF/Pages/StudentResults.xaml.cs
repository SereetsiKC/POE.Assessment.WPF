using POE.Assessment.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace POE.Assessment.WPF.Pages
{
    /// <summary>
    /// Interaction logic for StudentResults.xaml
    /// </summary>
    public partial class StudentResults : Page
    {
        private UserInputsViewModel _viewModel;
        private MainWindow _mainWindow;
        public StudentResults()
        {
            InitializeComponent();
        }

        public StudentResults(UserInputsViewModel model, MainWindow mainWindow) :this()
        {
            _viewModel = model;
            DataContext = _viewModel;
            _mainWindow = mainWindow;
            Loaded += StudentResults_Loaded;
        }

        private void StudentResults_Loaded(object sender, RoutedEventArgs e)
        {
            _viewModel.LoadResults();
            ResultsGrid.DataContext = _viewModel;
        }

        private void GoBack(object sender, RoutedEventArgs e)
        {
            UserInputs page = new UserInputs(_mainWindow);
            _mainWindow.Content = page;
        }
    }
}
