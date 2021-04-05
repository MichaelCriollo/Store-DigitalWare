using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.UI.WebControls;

namespace Store.Entity.Entities
{
    [Table("Client")]
    public partial class Client
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Client()
        {
            Bills = new HashSet<Bill>();
        }

        [Key]
        [Display(Name = "Id del Cliente")]
        public int IdClient { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Nombre")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Apellido")]
        public string LastName { get; set; }

        [Required]
        [StringLength(15)]
        [Display(Name = "N° Celular")]
        public string MobilePhone { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Correo")]
        public string Email { get; set; }

        [Display(Name = "Fecha de nacimiento")]
        public DateTime BirthdayDate { get; set; }

        [Display(Name = "Fecha de creacion")]
        public DateTime DateCreate { get; set; }

        [Display(Name = "Fecha de edicion")]
        public DateTime? DateEdit { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bill> Bills { get; set; }
    }
}
