using POE.Assessment.Common.DataProvider;
using POE.Assessment.Common.Models;
using POE.Assessment.ViewModel.Command;

namespace POE.Assessment.ViewModel
{
    public class StudentInformationViewModel:ViewModelBase
    {
        private readonly StudentInformation studentInformation;
        private readonly IStudentDataProvider studentDataProvider;

        public StudentInformationViewModel(StudentInformation studentInformation, IStudentDataProvider studentDataProvider)
        {
            this.studentInformation = studentInformation;
            this.studentDataProvider = studentDataProvider;
            SaveCommand = new DelegateCommand(Save, () => CanSave);
        }
        public DelegateCommand SaveCommand { get; }
        #region StudentInformation
        public string StudentNumber
        {
            get => studentInformation.StudentNumber;
            set
            {
                if (studentInformation.StudentNumber != value)
                {
                    studentInformation.StudentNumber = value;
                    RaisePropertyChanged();
                }
            }
        }

        public string Name
        {
            get => studentInformation.Name;
            set
            {
                if (studentInformation.Name != value)
                {
                    studentInformation.Name = value;
                    RaisePropertyChanged();
                }
            }
        }

        public string Surname
        {
            get => studentInformation.Surname;
            set
            {
                if (studentInformation.Surname != value)
                {
                    studentInformation.Surname = value;
                    RaisePropertyChanged();
                }
            }
        }

        public bool CanSave => !string.IsNullOrEmpty(StudentNumber) && !string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(Surname);
        #endregion StudentInformation
        public void Save()
        {
            studentDataProvider.AddStudentInformation(studentInformation);
        }
    }
}
