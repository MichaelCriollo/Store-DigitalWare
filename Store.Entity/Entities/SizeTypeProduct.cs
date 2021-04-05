using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Entity.Entities
{
    [Table("SizeTypeProduct")]
    public partial class SizeTypeProduct
    {
        [Key]
        public int IdSizeTypeProduct { get; set; }

        public int IdSize { get; set; }

        public int IdTypeProduct { get; set; }

        public virtual Size Size { get; set; }

        public virtual TypeProduct TypeProduct { get; set; }
    }
}
