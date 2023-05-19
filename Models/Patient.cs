using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HMSS.Models
{
    [Table("Patients", Schema = "HMSS")]
    public class Patient
    {
        [Key]
        [Display(Name = "PatientId")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPatient { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Doctor_id { get; set; }
        public virtual Doctor? doctor { get; set; }
    }
}
