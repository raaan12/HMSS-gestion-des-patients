using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HMSS.Models
{
    [Table("Doctors", Schema = "HMSS")]
    public class Doctor
    {
        [Key]
        [Display(Name = "Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DoctorId { get; set; }

        [Display(Name = "email")]
        [Column(TypeName = "Varchar(250)")]
        [Required]
        public string email { get; set; } = string.Empty;

        [Display(Name = "password")]
        [Column(TypeName = "Varchar(250)")]
        [Required]
        public string password { get; set; } = string.Empty;

        [Display(Name = "Name")]
        [Column(TypeName = "Varchar(250)")]
        [Required]
        public string nom { get; set; } = string.Empty;

        [Display(Name = "prenom")]
        [Column(TypeName = "Varchar(250)")]
        [Required]
        public string prenom { get; set; } = string.Empty;

        [Display(Name = "Speciality")]
        [Column(TypeName = "Varchar(250)")]
        [Required]
        public string speciality { get; set; } = string.Empty;

        public int Department_id { get; set; }
        public virtual Departement? departement { get; set; } 

        public virtual ICollection<Patient>? patients { get; set; }


    }
}
