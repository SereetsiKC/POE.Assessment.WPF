using POE.Assessment.Common.Models;
using System.Collections.Generic;
using COPY = POE.Assessment.Common.Models.Copy;

namespace POE.Assessment.Common.DataProvider
{
    public interface IStudentDataProvider
    {
        void AddUserInformation(Common.Models.UserInformation userInformation);
        void AddModuleInformation(ModuleInformation moduleInformation);
        void AddStudentInformation(StudentInformation studentInformation);
        void AddSemesterInformation(SemesterInformation semesterInformation);

        SemesterInformation LoadSemesterInfo();
        StudentInformation LoadStudentInfo();
        IEnumerable<COPY.ModuleInformation> LoadModuleInfo();
        List<Modules> LoadModules();
        Common.Models.UserInformation LoadUserInfo();
        bool Login(string Username, string Password);

    }
}
