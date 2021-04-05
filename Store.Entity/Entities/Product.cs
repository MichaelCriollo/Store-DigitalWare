using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Store.Entity.Entities
{
    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            DetailBills = new HashSet<DetailBill>();
            ProductSizes = new HashSet<ProductSize>();
        }

        [Key]
        public int IdProduct { get; set; }

        public int IdTypeProduct { get; set; }

        public int IdState { get; set; }

        public int IdColor { get; set; }

        public int IdGender { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Referencia")]
        public string Reference { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Nombre del producto")]
        public string Name { get; set; }

        [Column(TypeName = "numeric")]
        [Display(Name = "Precio Unitario")]
        public decimal PriceUnit { get; set; }

        [Display(Name = "Cantidad")]
        public int Quantity { get; set; }

        [Display(Name = "Fecha de Creacion")]
        public DateTime DateCreate { get; set; }

        [Display(Name = "Fecha de Edicion")]
        public DateTime? DateEdit { get; set; }

        public virtual Color Color { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetailBill> DetailBills { get; set; }

        public virtual Gender Gender { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductSize> ProductSizes { get; set; }

        [NotMapped]
        public int SearchAction { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem> ListTypes { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem> ListColors { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem> ListGender { get; set; }

        public virtual State State { get; set; }

        public virtual TypeProduct TypeProduct { get; set; }
    }
}
