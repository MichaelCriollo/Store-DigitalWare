using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Entity.Entities
{
    [Table("ProductSize")]
    public partial class ProductSize
    {
        [Key]
        public int IdProductSize { get; set; }

        public int IdProduct { get; set; }

        public int IdSize { get; set; }

        public DateTime DateCreate { get; set; }

        public DateTime? DateEdit { get; set; }

        public virtual Product Product { get; set; }

        public virtual Size Size { get; set; }
    }
}
