using POE.Assessment.Common.Models;
using System.Collections.Generic;
using COPY = POE.Assessment.Common.Models.Copy;

namespace POE.Assessment.Common.DataProvider
{
    public interface IStudentDataProvider
    {
        void AddModuleInformation(ModuleInformation moduleInformation);
        void AddStudentInformation(StudentInformation testInformation);
        void AddSemesterInformation(SemesterInformation semesterInformation);

        SemesterInformation LoadSemesternfo();
        StudentInformation LoadStudentInfo();
        IEnumerable<COPY.ModuleInformation> LoadModuleInfo();
        IEnumerable<Modules> LoadModules();

    }
}
