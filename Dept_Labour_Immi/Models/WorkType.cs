using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dept_Labour_Immi.Models
{
    public class WorkType
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("အလုပ်အကိုင် အမျိုးအစား")]
        public string? Name { get; set; }
        [Required]
      //  [DisplayName("အလုပ်အကိုင် အမျိုးအစား")]
        public string? DemandType { get; set; }
        [NotMapped]
        [DisplayName("စဥ်")]
        public string No { get; set; }
    }
}
