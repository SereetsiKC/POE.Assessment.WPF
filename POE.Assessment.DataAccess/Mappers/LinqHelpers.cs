using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COPY = POE.Assessment.Common.Models.Copy;

namespace POE.Assessment.DataAccess.Mappers
{
    internal static class UserMappers
    {
        internal static Common.Models.UserInformation MapToCommon(this Data.User domain)
        {
            if (domain == null)
                return null;

            return new Common.Models.UserInformation()
            {
                Id = domain.Id,
                Name = domain.Name,
                Surname = domain.Surname,
                Username = domain.Username,
                Password = domain.Password
            };

        }

        internal static Data.User MapToDomain(this Common.Models.UserInformation common)
        {
            if (common == null)
                return null;

            return new Data.User()
            {
                Id = common.Id,
                Name = common.Name,
                Surname = common.Surname,
                Username = common.Username,
                Password = common.Password
            };

        }
    }

    internal static class StudentInformationMappers
    {
        internal static Common.Models.StudentInformation MapToCommon(this Data.StudentInformation domain)
        {
            if (domain == null)
                return null;

            return new Common.Models.StudentInformation()
            {
                Id = domain.Id,
                Name = domain.Name,
                StudentNumber = domain.StudentNumber,
                Surname = domain.Surname
            };

        }

        internal static Data.StudentInformation MapToDomain(this Common.Models.StudentInformation common)
        {
            if (common == null)
                return null;

            return new Data.StudentInformation()
            {
                Id = common.Id,
                Name = common.Name,
                StudentNumber = common.StudentNumber,
                Surname = common.Surname
            };

        }
    }

    internal static class ModuleMappers
    {
        internal static Common.Models.Modules MapToCommon(this Data.Module domain)
        {
            if (domain == null)
                return null;

            return new Common.Models.Modules()
            {
                Id = domain.Id,
                Name = domain.Name,
                Code = domain.Code
            };

        }

        internal static Data.Module MapToDomain(this Common.Models.Modules common)
        {
            if (common == null)
                return null;

            return new Data.Module()
            {
                Id = common.Id,
                Name = common.Name,
                Code = common.Code
            };

        }
    }

    internal static class ModuleInformationMappers
    {
        internal static Common.Models.ModuleInformation MapToCommon(this Data.ModuleInformation domain)
        {
            if (domain == null)
                return null;

            return new Common.Models.ModuleInformation()
            {
                Id = domain.Id,
                CodeId = domain.CodeId,
                Name = domain.Name,
                NumberOfCredits = domain.NumberOfCredits,
                ClassHoursPerWeek = domain.ClassHoursPerWeek,
                HoursOfSelfStudy = domain.HoursOfSelfStudy,
                SelfStudyHoursPerWeek = domain.SelfStudyHoursPerWeek.Value,
                StudyDate = domain.StudyDate,
                Code = domain.Code,
                StudentInformationId = domain.StudentInformationId
            };

        }

        internal static Data.ModuleInformation MapToDomain(this COPY.ModuleInformation common)
        {
            if (common == null)
                return null;

            return new Data.ModuleInformation()
            {
                Id = common.Id,
                CodeId = common.CodeId,
                Name = common.Name,
                NumberOfCredits = common.NumberOfCredits,
                ClassHoursPerWeek = common.ClassHoursPerWeek,
                HoursOfSelfStudy = common.HoursOfSelfStudy,
                SelfStudyHoursPerWeek = common.SelfStudyHoursPerWeek,
                StudyDate = common.StudyDate.Value,
                Code = common.Code,
                StudentInformationId = common.StudentInformationId
            };

        }
    }

    internal static class SemesterInformationMappers
    {
        internal static Common.Models.SemesterInformation MapToCommon(this Data.SemesterInformation domain)
        {
            if (domain == null)
                return null;

            return new Common.Models.SemesterInformation()
            {
                Id = domain.Id,
                NumberOfWeeks = domain.NumberOfWeeks,
                StartDate = domain.StartDate
            };

        }

        internal static Data.SemesterInformation MapToDomain(this Common.Models.SemesterInformation common)
        {
            if (common == null)
                return null;

            return new Data.SemesterInformation()
            {
                Id = common.Id,
                NumberOfWeeks = common.NumberOfWeeks,
                StartDate = common.StartDate
            };

        }
    }
}
