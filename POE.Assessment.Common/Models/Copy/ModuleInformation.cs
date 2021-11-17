using System;

namespace POE.Assessment.Common.Models.Copy
{
    public class ModuleInformation
    {
        public ModuleInformation()
        {

        }
        public ModuleInformation(Models.ModuleInformation module)
        {
            Id = module.Id;
            CodeId = module.CodeId;
            Name = module.Name;
            NumberOfCredits = module.NumberOfCredits;
            ClassHoursPerWeek = module.ClassHoursPerWeek;
            HoursOfSelfStudy = module.HoursOfSelfStudy;
            SelfStudyHoursPerWeek = module.SelfStudyHoursPerWeek;
            StudyDate = module.StudyDate;
            Code = module.Code;
            StudentInformationId = module.StudentInformationId;
        }
        public int Id { get; set; }
        public int StudentInformationId { get; set; }
        public int CodeId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int NumberOfCredits { get; set; }
        public int ClassHoursPerWeek { get; set; }
        public int HoursOfSelfStudy { get; set; }
        public decimal SelfStudyHoursPerWeek { get; set; }
        public DateTime? StudyDate { get; set; }
    }
}
