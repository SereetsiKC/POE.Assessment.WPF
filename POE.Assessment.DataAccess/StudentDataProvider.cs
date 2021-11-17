using POE.Assessment.Common.DataProvider;
using POE.Assessment.Common.Models;
using COPY = POE.Assessment.Common.Models.Copy;
using System.Collections.Generic;
using System.Diagnostics;
using POE.Assessment.DataAccess.Mappers;
using System.Linq;
using POE.Assessment.Data;

namespace POE.Assessment.DataAccess
{
    /// <summary>
    /// System Data Provider 
    /// </summary>
    public class StudentDataProvider : IStudentDataProvider
    {
        public StudentDataProvider()
        {
            ModuleInformation = new List<COPY.ModuleInformation>();
            Context = new POEAssessmentDBEntities();
        }
        /// <summary>
        /// System Data Access 
        /// </summary>
        private List<COPY.ModuleInformation> ModuleInformation { get; set; }
        private Common.Models.StudentInformation StudentInformation { get; set; }
        private Common.Models.SemesterInformation SemesterInformation { get; set; }
        private Common.Models.UserInformation UserInformation { get; set; }

        private readonly POEAssessmentDBEntities Context;
        public void AddUserInformation(Common.Models.UserInformation userInformation)
        {

            if (GetUser(userInformation.Username) == null)
            {
                var std = userInformation.MapToDomain();
                std.Password = Encryption.Encrypt(userInformation.Password);
                Context.Users.Add(std);
                Context.SaveChanges();

                UserInformation = std.MapToCommon();
            }
            else
            {
                var std = GetUser(userInformation.Username);
                std.Name = userInformation.Name;
                std.Surname = userInformation.Surname;
                std.Password = Encryption.Encrypt(userInformation.Password);
                Context.SaveChanges();
                UserInformation = std.MapToCommon();
            }

            Debug.WriteLine($"User Saved: {userInformation.Name}");
        }
        public void AddModuleInformation(Common.Models.ModuleInformation moduleInformation)
        {
            var std = new COPY.ModuleInformation(moduleInformation).MapToDomain();
            std.StudentInformationId = StudentInformation.Id;
            Context.ModuleInformations.Add(std);
            Context.SaveChanges();

            LoadModuleInfo();
            Debug.WriteLine($"Module Saved: {moduleInformation.Name}");
        }

        public void AddStudentInformation(Common.Models.StudentInformation studentInformation)
        {
            var std = studentInformation.MapToDomain();
            std.UserId = UserInformation.Id;
            Context.StudentInformations.Add(std);
            Context.SaveChanges();

            LoadStudentInfo();
            Debug.WriteLine($"Student Saved: {studentInformation.Name}");
        }

        public void AddSemesterInformation(Common.Models.SemesterInformation semesterInformation)
        {
            var std = semesterInformation.MapToDomain();
            Context.SemesterInformations.Add(std);
            Context.SaveChanges();

            GetAddedSemester();

            var sti = Context.StudentInformations.Where(x=>x.Id == StudentInformation.Id).First<Data.StudentInformation>();
            sti.SemesterId = SemesterInformation.Id;
            Context.SaveChanges();

            LoadStudentInfo();

            Debug.WriteLine($"Student Saved: {semesterInformation.NumberOfWeeks}");
        }

        private Common.Models.SemesterInformation GetAddedSemester()
        {
            SemesterInformation = (from x in Context.SemesterInformations
                                   select x).AsEnumerable<Data.SemesterInformation>()
                                   .LastOrDefault()
                                   .MapToCommon();


            return SemesterInformation ?? new Common.Models.SemesterInformation();
        }

        public List<Modules> LoadModules()
        {
            var modules = (from s in Context.Modules
                           select s).AsEnumerable<Data.Module>();

            return modules.Select(x => x.MapToCommon()).ToList();
        }

        public Common.Models.StudentInformation LoadStudentInfo()
        {
            StudentInformation = (from x in Context.StudentInformations
                                  join s in Context.Users on x.UserId equals s.Id
                                  where s.Id == UserInformation.Id
                                  select x)
                                  .FirstOrDefault()
                                  .MapToCommon();

            return StudentInformation ?? new Common.Models.StudentInformation();
        }

        public IEnumerable<COPY.ModuleInformation> LoadModuleInfo()
        {
            var results = (from x in Context.ModuleInformations
                           join s in Context.StudentInformations on x.StudentInformationId equals s.Id
                           join a in Context.Users on s.UserId equals a.Id
                           where a.Id == UserInformation.Id
                           select x).AsEnumerable<Data.ModuleInformation>();

            ModuleInformation = results.Select(x => new COPY.ModuleInformation(x.MapToCommon())).ToList() ?? new List<COPY.ModuleInformation>();

            return ModuleInformation.AsEnumerable<COPY.ModuleInformation>();
        }

        public Common.Models.SemesterInformation LoadSemesterInfo()
        {
            SemesterInformation = (from x in Context.SemesterInformations
                                   join s in Context.StudentInformations on x.Id equals s.SemesterId
                                   join a in Context.Users on s.UserId equals a.Id
                                   where a.Id == UserInformation.Id
                                   select x)
                                   .AsEnumerable<Data.SemesterInformation>()
                                   .FirstOrDefault()
                                   .MapToCommon();


            return SemesterInformation ?? new Common.Models.SemesterInformation();
        }

        public Common.Models.UserInformation LoadUserInfo()
        {
            return UserInformation;
        }

        private Data.User GetUser(string Username)
        {
            var user = (from x in Context.Users
                        where x.Username == Username
                        select x).FirstOrDefault<Data.User>();
            return user;
        }
        public bool Login(string Username, string Password)
        {
            Password = Encryption.Encrypt(Password);
            var user = (from x in Context.Users
                        where x.Username == Username && x.Password == Password
                        select x).FirstOrDefault<Data.User>();
            UserInformation = user.MapToCommon();

            return UserInformation != null;
        }
    }
}
