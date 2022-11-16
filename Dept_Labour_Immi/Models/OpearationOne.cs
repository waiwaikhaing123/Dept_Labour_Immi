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
        [DisplayName("တင်ပြသည့် ရက်စွဲ")]
        public DateTime ApplyDate { get; set; }
        [Required]
        [DisplayName("စာရွက်စာတမ်းပြည့်စုံသည့် ရက်စွဲ")]
        public DateTime DocumentCompleteDate { get; set; }
        [Required]
        [DisplayName("မြန်မာအေဂျင်စီ အမည်")]
        public int? AgencyID { get; set; }
        [DisplayName("မြန်မာအေဂျင်စီ အမည်")]
        public Agency angency { get; set; }
        [NotMapped]
        public string angencyName { get; set; }
        [Required]
        [DisplayName("ထိုင်းကုမ္ပဏီ အမည်")]
        public int? ThaiCompanyID { get; set; }
        [DisplayName("ထိုင်းကုမ္ပဏီ အမည်")]
        public ThaiCompany thaiCompany { get; set; }
        [NotMapped]
        public string ThaiCompanyName { get; set; }
        [Required]
        [DisplayName("စာအမှတ်")]
        public int? DOEID { get; set; }
        [DisplayName("စာအမှတ်")]
        public DOE DOE { get; set; }
        [NotMapped]
        public string? DOEName { get; set; }
        [Required]
        [DisplayName("အလုပ်အကိုင် အမျိုးအစား")]
        public int WorkTypeID { get; set; }
        [DisplayName("အလုပ်အကိုင် အမျိုးအစား")]
        public WorkType worktype { get; set; }
        [NotMapped]
        public string worktypeName { get; set; }
        [Required]
        [DisplayName("ကျား")]
        public string? NoOfMaleWorker { get; set; }
        [Required]
        [DisplayName("မ")]
        public string? NoOfFemaleWorker { get; set; }
        [Required]
        [DisplayName("ပေါင်း")]
        public string? TotalNoOfWorker { get; set; }
        [DisplayName("မှတ်ချက်")]
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
        [NotMapped]
        [DisplayName("စဥ်")]
        public string No { get; set; }
    }
}

