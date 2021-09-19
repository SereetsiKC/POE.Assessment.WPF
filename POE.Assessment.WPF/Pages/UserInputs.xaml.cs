using POE.Assessment.DataAccess;
using POE.Assessment.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Text.RegularExpressions;

namespace POE.Assessment.WPF.Pages
{
    /// <summary>
    /// Interaction logic for UserInputs.xaml
    /// </summary>
    public partial class UserInputs : Page
    {
        private UserInputsViewModel _viewModel;
        private MainWindow _mainWindow;
        public UserInputs()
        {
            InitializeComponent();
            _viewModel = new UserInputsViewModel(new StudentDataProvider());
            DataContext = _viewModel;
            Loaded += UserInputs_Loaded;
        }

        public UserInputs(MainWindow mainWindow) : this()
        {
            _mainWindow = mainWindow;
        }


        private void UserInputs_Loaded(object sender, RoutedEventArgs e)
        {
            _viewModel.Load();
        }


        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void ViewResults(object sender, RoutedEventArgs e)
        {
            StudentResults page = new StudentResults(_viewModel, _mainWindow);
            _mainWindow.Content = page;
        }
    }
}
