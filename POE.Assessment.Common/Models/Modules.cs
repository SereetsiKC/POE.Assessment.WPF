using POE.Assessment.Data;

namespace POE.Assessment.Common.Models
{
    public class Modules
    {
        public Modules() { }
        public Modules(Module domain) {
            Id = domain.Id;
            Code = domain.Code;
            Name = domain.Name;
        }
        public int Id{ get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
