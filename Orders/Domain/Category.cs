using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Category
    {
        [ScaffoldColumn(false)]
        public int CategoryID { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Name")]
        public string CategoryName { get; set; }

        [Display(Name = "Category description")]
        public string Description { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
