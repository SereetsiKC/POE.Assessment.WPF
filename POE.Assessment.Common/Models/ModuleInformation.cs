using System;

namespace POE.Assessment.Common.Models
{
    public class ModuleInformation
    {
        public ModuleInformation()
        {

        }
        public ModuleInformation(Copy.ModuleInformation module)
        {
            CodeId = module.CodeId;
            Name = module.Name;
            NumberOfCredits = module.NumberOfCredits;
            ClassHoursPerWeek = module.ClassHoursPerWeek;
            HoursOfSelfStudy = module.HoursOfSelfStudy;
            SelfStudyHoursPerWeek = module.SelfStudyHoursPerWeek;
            StudyDate = module.StudyDate;
            Code = module.Code;
        }
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
