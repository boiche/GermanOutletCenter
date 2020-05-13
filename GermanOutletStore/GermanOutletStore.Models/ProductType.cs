using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GermanOutletStore.Models
{
    public class ProductType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
