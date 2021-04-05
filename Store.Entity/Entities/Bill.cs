using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Entity.Entities
{
    [Table("Bill")]
    public partial class Bill
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Bill()
        {
            DetailBills = new HashSet<DetailBill>();
        }

        [Key]
        [Display(Name = "Numero de factura")]
        public int IdBill { get; set; }

        public int IdClient { get; set; }

        [Column(TypeName = "numeric")]
        [Display(Name = "Precio Total")]
        public decimal TotalPrice { get; set; }

        [Display(Name = "Fecha de creacion")]
        public DateTime DateCreate { get; set; }

        [Display(Name = "Fecha de edicion")]
        public DateTime? DateEdit { get; set; }

        [NotMapped]
        public int SearchAction { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetailBill> DetailBills { get; set; }

        public virtual Client Client { get; set; }
    }
}
