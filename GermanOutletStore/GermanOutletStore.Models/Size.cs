using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GermanOutletStore.Models
{
    public class Size
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<ProductSize> Products { get; set; }
        public ICollection<ProductOrders> ProductOrders { get; set; }
    }
}
