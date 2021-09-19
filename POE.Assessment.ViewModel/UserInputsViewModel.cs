
using POE.Assessment.Common.DataProvider;
using POE.Assessment.Common.Models;
using POE.Assessment.ViewModel.Command;
using System.Collections.ObjectModel;

namespace POE.Assessment.ViewModel
{
    public class UserInputsViewModel : ViewModelBase
    {
        private readonly IStudentDataProvider studentDataProvider;
        private ModuleInformationViewModel _module;
        private StudentInformationViewModel _student;
        private SemesterInformationViewModel _semester;
        public UserInputsViewModel(IStudentDataProvider studentDataProvider)
        {
            Modules = new ObservableCollection<Modules>();
            ModulesColletion = new ObservableCollection<ModuleInformationViewModel>();
            this.studentDataProvider = studentDataProvider;
            LoadCommand = new DelegateCommand(Load);
            SaveCommand = new DelegateCommand(Save);
        }
        public DelegateCommand LoadCommand { get; }
        public DelegateCommand SaveCommand { get; }

        public ObservableCollection<Modules> Modules { get; }

        public ObservableCollection<ModuleInformationViewModel> ModulesColletion { get; }

        public ModuleInformationViewModel Module
        {
            get => _module;
            set
            {
                if (_module != value)
                {
                    _module = value;
                    RaisePropertyChanged();
                }
            }
        }
        public StudentInformationViewModel Student
        {
            get => _student;
            set
            {
                if (_student != value)
                {
                    _student = value;
                    RaisePropertyChanged();
                }
            }
        }

        public SemesterInformationViewModel Semester {
            get => _semester;
            set
            {
                if (_semester != value)
                {
                    _semester = value;
                    RaisePropertyChanged();
                }
            }
        }

        public void Save()
        {
            Student.Save();
            Semester.Save();
        }

        public virtual void Load()
        {
            Module = new ModuleInformationViewModel(new ModuleInformation(), studentDataProvider);
            Student = new StudentInformationViewModel(new StudentInformation(), studentDataProvider);
            Semester = new SemesterInformationViewModel(new SemesterInformation(), studentDataProvider);

            var modules = studentDataProvider.LoadModules();
            Modules.Clear();
            foreach (var module in modules)
            {
                Modules.Add(module);
            }
        }

        public void LoadResults()
        {
            Module = new ModuleInformationViewModel(new ModuleInformation(), studentDataProvider);
            Student = new StudentInformationViewModel(studentDataProvider.LoadStudentInfo(), studentDataProvider);
            Semester = new SemesterInformationViewModel(studentDataProvider.LoadSemesternfo(), studentDataProvider);

            var modulesCollection = studentDataProvider.LoadModuleInfo();
            ModulesColletion.Clear();
            foreach (var module in modulesCollection)
            {
                var newModuleViewModel = new ModuleInformationViewModel(new ModuleInformation(module), studentDataProvider);
                newModuleViewModel.CalculateSelfStudyHoursPerWeek(Semester.NumberOfWeeks);
                ModulesColletion.Add(newModuleViewModel);
            }

            var modules = studentDataProvider.LoadModules();
            Modules.Clear();
            foreach (var module in modules)
            {
                Modules.Add(module);
            }
        }
    }
}