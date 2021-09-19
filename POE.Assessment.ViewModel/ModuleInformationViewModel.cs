using POE.Assessment.Common.DataProvider;
using POE.Assessment.Common.Models;
using POE.Assessment.ViewModel.Command;
using System;
using System.Diagnostics;
using System.Linq;

namespace POE.Assessment.ViewModel
{
    public class ModuleInformationViewModel : ViewModelBase
    {
        private readonly ModuleInformation moduleInformation;
        private readonly IStudentDataProvider studentDataProvider;

        public ModuleInformationViewModel(ModuleInformation moduleInformation, IStudentDataProvider studentDataProvider)
        {
            this.moduleInformation = moduleInformation;
            this.studentDataProvider = studentDataProvider;

            SaveCommand = new DelegateCommand(Save, () => CanSave);
        }

        public DelegateCommand SaveCommand { get; }

        public int CodeId
        {
            get => moduleInformation.CodeId;
            set
            {
                if (moduleInformation.CodeId != value)
                {
                    moduleInformation.CodeId = value;
                    RaisePropertyChanged();
                    SaveCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public string Code
        {
            get => moduleInformation.Code;
            set
            {
                if (moduleInformation.Code != value)
                {
                    moduleInformation.Code = value;
                    RaisePropertyChanged();                    
                }
            }
        }

        public string Name
        {
            get => moduleInformation.Name;
            set
            {
                if (moduleInformation.Name != value)
                {
                    moduleInformation.Name = value;
                    RaisePropertyChanged();
                }
            }
        }

        public int NumberOfCredits
        {
            get => moduleInformation.NumberOfCredits;
            set
            {
                if (moduleInformation.NumberOfCredits != value)
                {
                    moduleInformation.NumberOfCredits = value;
                    RaisePropertyChanged();
                }
            }
        }

        public int ClassHoursPerWeek
        {
            get => moduleInformation.ClassHoursPerWeek;
            set
            {
                if (moduleInformation.ClassHoursPerWeek != value)
                {
                    moduleInformation.ClassHoursPerWeek = value;
                    RaisePropertyChanged();
                }
            }
        }

        public int HoursOfSelfStudy
        {
            get => moduleInformation.HoursOfSelfStudy;
            set
            {
                if (moduleInformation.HoursOfSelfStudy != value)
                {
                    moduleInformation.HoursOfSelfStudy = value;
                    RaisePropertyChanged();
                }
            }
        }

        public string StudyDate
        {
            get => moduleInformation.StudyDate.HasValue ? moduleInformation.StudyDate.Value.ToString("dddd, dd MMMM yyyy") : DateTime.Now.ToString("dddd, dd MMMM yyyy");
            set
            {
                if (moduleInformation.StudyDate != Convert.ToDateTime(value))
                {
                    moduleInformation.StudyDate = Convert.ToDateTime(value);
                    RaisePropertyChanged();
                }
            }
        }

        public decimal SelfStudyHoursPerWeek
        {
            get => moduleInformation.SelfStudyHoursPerWeek; 
            set {
                if (moduleInformation.SelfStudyHoursPerWeek != value)
                {
                    moduleInformation.SelfStudyHoursPerWeek = value;
                    RaisePropertyChanged();
                }
            }
        }

        public decimal RemainingSelfStudyHours
        {
            get => moduleInformation.SelfStudyHoursPerWeek - moduleInformation.HoursOfSelfStudy;
        }

        public bool CanSave => CodeId >= 1;
        public void CalculateSelfStudyHoursPerWeek(int NumberOfWeeks)
        {
            decimal credits = NumberOfCredits * 10;
            if (credits > 0 && ClassHoursPerWeek > 0)
                SelfStudyHoursPerWeek = Decimal.Divide(credits, ClassHoursPerWeek) - NumberOfWeeks;
        }
        public void Save()
        {
            var test1 = studentDataProvider.LoadModuleInfo();
            var test = test1.Any(x => x.CodeId == CodeId);
            if (!test)
            {
                Code = studentDataProvider.LoadModules().FirstOrDefault(x => x.Id == moduleInformation.CodeId).Name;
                studentDataProvider.AddModuleInformation(moduleInformation);
                Debug.WriteLine(studentDataProvider.LoadModuleInfo().SingleOrDefault(x => x.CodeId == CodeId)?.Name);
            }
            else
            {
                Debug.WriteLine($"Module already Add {studentDataProvider.LoadModuleInfo().SingleOrDefault(x => x.CodeId == CodeId)?.Name}");
            }

        }
    }
}
