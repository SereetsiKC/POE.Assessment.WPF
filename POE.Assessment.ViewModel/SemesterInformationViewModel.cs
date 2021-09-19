using POE.Assessment.Common.DataProvider;
using POE.Assessment.Common.Models;
using POE.Assessment.ViewModel.Command;
using System;

namespace POE.Assessment.ViewModel
{
    public class SemesterInformationViewModel: ViewModelBase
    {
        private readonly SemesterInformation semesterInformation;
        private readonly IStudentDataProvider studentDataProvider;

        public SemesterInformationViewModel(SemesterInformation semesterInformation, IStudentDataProvider studentDataProvider)
        {
            this.semesterInformation = semesterInformation;
            this.studentDataProvider = studentDataProvider;
            SaveCommand = new DelegateCommand(Save, () => CanSave);
        }
        public DelegateCommand SaveCommand { get; }

        public int NumberOfWeeks
        {
            get => semesterInformation.NumberOfWeeks;
            set
            {
                if (semesterInformation.NumberOfWeeks != value)
                {
                    semesterInformation.NumberOfWeeks = value;
                    RaisePropertyChanged();
                }
            }
        }

        public string StartDate
        {
            get => semesterInformation.StartDate.HasValue ? semesterInformation.StartDate.Value.ToString("dddd, dd MMMM yyyy") : DateTime.Now.ToString("dddd, dd MMMM yyyy");
            set
            {
                if (semesterInformation.StartDate != Convert.ToDateTime(value))
                {
                    semesterInformation.StartDate = Convert.ToDateTime(value);
                    RaisePropertyChanged();
                }
            }
        }

        public bool CanSave => NumberOfWeeks >= 1;

        public void Save()
        {
            studentDataProvider.AddSemesterInformation(semesterInformation);
        }
    }
}
