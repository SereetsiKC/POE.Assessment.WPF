using POE.Assessment.Common.DataProvider;
using POE.Assessment.Common.Models;
using COPY = POE.Assessment.Common.Models.Copy;
using System.Collections.Generic;
using System.Diagnostics;

namespace POE.Assessment.DataAccess
{
    public class StudentDataProvider : IStudentDataProvider
    {
        public StudentDataProvider()
        {
            ModuleInformation = new List<COPY.ModuleInformation>();
        }
        private List<COPY.ModuleInformation> ModuleInformation { get; set; }
        private StudentInformation StudentInformation { get; set; }
        private SemesterInformation SemesterInformation { get; set; }

        public void AddModuleInformation(ModuleInformation moduleInformation)
        {
            ModuleInformation.Add(new COPY.ModuleInformation(moduleInformation));
            Debug.WriteLine($"Module Saved: {moduleInformation.Name}");
        }

        public void AddStudentInformation(StudentInformation studentInformation)
        {
            StudentInformation = studentInformation;
            Debug.WriteLine($"Student Saved: {studentInformation.Name}");
        }

        public void AddSemesterInformation(SemesterInformation semesterInformation)
        {
            SemesterInformation = semesterInformation;
            Debug.WriteLine($"Student Saved: {semesterInformation.NumberOfWeeks}");
        }

        public IEnumerable<Modules> LoadModules()
        {
            return new List<Modules> {
                new Modules { Id = 1, Code = "PROG6212" },
                new Modules { Id = 2, Code = "PRF216456"},
                new Modules { Id = 3, Code = "Testing2"},
                new Modules { Id = 4, Code = "Testing3" },
                new Modules { Id = 5, Code = "Testing4"}
            };
        }

        public StudentInformation LoadStudentInfo()
        {
            return StudentInformation;
        }

        public IEnumerable<COPY.ModuleInformation> LoadModuleInfo()
        {
            return ModuleInformation;
        }

        public SemesterInformation LoadSemesternfo()
        {
            return SemesterInformation;
        }


    }
}
