using System.ComponentModel.DataAnnotations;

namespace Dept_Labour_Immi.Models
{
    public class WorkType
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? DemandType { get; set; }
    }
}
