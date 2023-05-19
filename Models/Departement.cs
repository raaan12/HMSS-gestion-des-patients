using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HMSS.Models
{
    [Table("Departements", Schema = "HMSS")]
    public class Departement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "DepartmentId")]
        public int id_Dep { get; set; }


        [Display(Name = "Name")]
        [Column(TypeName = "Varchar(250)")]
        [Required]
        public string nom { get; set; } = string.Empty;

        public virtual ICollection<Doctor> doctors { get; set; } = new List<Doctor>();
    }
}
