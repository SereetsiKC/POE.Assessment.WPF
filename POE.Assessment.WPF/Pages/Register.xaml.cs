using POE.Assessment.DataAccess;
using POE.Assessment.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace POE.Assessment.WPF.Pages
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Page
    {
        private UserInputsViewModel _viewModel;
        private MainWindow _mainWindow;
        public Register()
        {
            InitializeComponent();
            _viewModel = new UserInputsViewModel(new StudentDataProvider());
            DataContext = _viewModel;
            Loaded += Register_Loaded;
        }
        public Register(MainWindow mainWindow) : this()
        {
            _mainWindow = mainWindow;
        }

        private void Register_Loaded(object sender, RoutedEventArgs e)
        {
            _viewModel.Load();
        }

        private void RegisterNewUser(object sender, RoutedEventArgs e)
        {
            _viewModel.User.Save();
            LogNewUserIn();
        }

        private void LogNewUserIn()
        {
            var response = _viewModel.Login();
            if (!response)
            {
                const string message = "Do you wish to register?";
                const string caption = "Invalid Username or paword";
                var results = MessageBox.Show(message, caption, MessageBoxButton.YesNo,
                    MessageBoxImage.Question);
                if (results == MessageBoxResult.Yes)
                {
                    Register register = new Register(_mainWindow);
                    _mainWindow.Content = register;
                }
            }
            else
            {
                UserInputs userInputs = new UserInputs(_mainWindow, _viewModel);
                _mainWindow.Content = userInputs;
            }
        }
    }
}
