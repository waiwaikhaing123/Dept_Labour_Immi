using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Dept_Labour_Immi.Models
{
    public class OpearationOne
    {
        public int ID { get; set; }
        [Required]
        public DateTime ApplyDate { get; set; }
        [Required]
        public DateTime DocumentCompleteDate { get; set; }
        [Required]
        public int? AgencyID { get; set; }
        public Agency angency { get; set; }
        [NotMapped]
        public string angencyName { get; set; }
        [Required]
        public int? ThaiCompanyID { get; set; }
        public ThaiCompany thaiCompany { get; set; }
        [NotMapped]
        public string ThaiCompanyName { get; set; }
        [Required]
        public int? DOEID { get; set; }
        public DOE DOE { get; set; }
        [NotMapped]
        public string? DOEName { get; set; }
        [Required]
        public int WorkTypeID { get; set; }
        public WorkType worktype { get; set; }
        [NotMapped]
        public string worktypeName { get; set; }
        [Required]
        public string? NoOfMaleWorker { get; set; }
        [Required]
        public string? NoOfFemaleWorker { get; set; }
        [Required]
        public string? TotalNoOfWorker { get; set; }
        public string? Remark { get; set; }
        public List<WorkType> WorkTypeList { get; set; } = new List<WorkType>();
        [NotMapped]
        public List<ThaiCompany> ThaiCompanyList { get; set; } = new List<ThaiCompany>();
        [NotMapped]
        public List<Agency> AgencyList { get; set; } = new List<Agency>();
        [NotMapped]
        public List<DOE> DOEList { get; set; } = new List<DOE>();
        [NotMapped]
        public List<Blacklist> blistes { get; set; } = new List<Blacklist>();
    }
}

