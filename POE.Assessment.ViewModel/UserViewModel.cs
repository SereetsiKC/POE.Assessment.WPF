using POE.Assessment.Common.DataProvider;
using POE.Assessment.Common.Models;
using POE.Assessment.ViewModel.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POE.Assessment.ViewModel
{
    public class UserViewModel : ViewModelBase
    {
        private readonly UserInformation user;
        private readonly IStudentDataProvider studentDataProvider;

        public UserViewModel(UserInformation user, IStudentDataProvider studentDataProvider)
        {
            this.user = user;
            this.studentDataProvider = studentDataProvider;
            SaveCommand = new DelegateCommand(Save, () => CanSave);
        }

        public DelegateCommand SaveCommand { get; }
        public int Id
        {
            get => user.Id;
            set
            {
                if (user.Id != value)
                {
                    user.Id = value;
                    RaisePropertyChanged();
                }
            }
        }
        public string Name
        {
            get => user.Name;
            set
            {
                if (user.Name != value)
                {
                    user.Name = value;
                    RaisePropertyChanged();
                }
            }
        }
        public string Surname
        {
            get => user.Surname;
            set
            {
                if (user.Surname != value)
                {
                    user.Surname = value;
                    RaisePropertyChanged();
                }
            }
        }
        public string Username
        {
            get => user.Username;
            set
            {
                if (user.Username != value)
                {
                    user.Username = value;
                    RaisePropertyChanged();
                }
            }
        }

        public string Password
        {
            get => user.Password;
            set
            {
                if (user.Password != value)
                {
                    user.Password = value;
                    RaisePropertyChanged();
                }
            }
        }
        public bool CanSave => true;
        public bool Login()
        {
           return  studentDataProvider.Login(user.Username, user.Password);
        }
        public void Save()
        {
            studentDataProvider.AddUserInformation(user);
        }
    }
}