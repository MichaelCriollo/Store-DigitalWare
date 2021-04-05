using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Entity.Entities
{
    [Table("DetailBill")]
    public partial class DetailBill
    {
        [Key]
        public int IdDetailBill { get; set; }

        [Display(Name = "Numero de factura")]
        public int IdBill { get; set; }

        public int IdProduct { get; set; }

        [Display(Name = "Cantidad")]
        public int Quantity { get; set; }

        [Column(TypeName = "numeric")]
        [Display(Name = "Precio")]
        public decimal Price { get; set; }

        [Display(Name = "Fecha de creacion")]
        public DateTime DateCreate { get; set; }

        [Display(Name = "Fecha de edicion")]
        public DateTime? DateEdit { get; set; }

        [NotMapped]
        public int SearchAction { get; set; }

        public virtual Bill Bill { get; set; }

        public virtual Product Product { get; set; }
    }
}
