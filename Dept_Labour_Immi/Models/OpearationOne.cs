using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Dept_Labour_Immi.Models
{
    public class OpearationOne
    {
        public int ID { get; set; }
        public DateTime ApplyDate { get; set; }
    //    [DisplayName(Name = "Doc Complete Date")]
        public DateTime DocumentCompleteDate { get; set; }
        public int? AgencyID { get; set; }
        public Agency angency { get; set; }
        public int? ThaiCompanyID { get; set; }
        public ThaiCompany thaiCompany { get; set; }
        public int? DOEID { get; set; }
       // public DOE thaiCompanty { get; set; }
        public int WorkTypeID { get; set; }
        public WorkType worktype { get; set; }
        [NotMapped]
        public string worktypeName { get; set; }
        public string? NoOfMaleWorker { get; set; }
        public string? NoOfFemaleWorker { get; set; }
        public string? TotalNoOfWorker { get; set; }
        public string? Remark { get; set; }
        public List<WorkType> WorkTypeList { get; set; } = new List<WorkType>();
    }
}

