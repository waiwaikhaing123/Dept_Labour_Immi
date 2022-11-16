using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Dept_Labour_Immi.Models
{
    public class Blacklist
    {
        public int Id { get; set; }
        //public string Name { get; set; }
        public string Reason { get; set; }

        [DisplayName("မှ")]
        [DataType(DataType.Date)]
        public DateTime FromDate { get; set; }

        [DisplayName("ထိ")]
        [DataType(DataType.Date)]
        public DateTime? Todate { get; set; }
        public string? Remark { get; set; }
        public bool IsActive { get; set; }
        public string penaltyType { get; set; }
        //foreign key 


        //public List<Agency> agencies { get; set; }  //update comment
        //public List<ThaiCompany> ThaiCompanies { get; set; }
        //public int PenaltyID { get; set; }  //can use if there come more peanlties

        public int? AgencyID { get; set; }
        public Agency? agency { get; set; }

        public int? ThaiCompanyID { get; set; }
        public ThaiCompany? thaiCompany { get; set; }
    }
}
