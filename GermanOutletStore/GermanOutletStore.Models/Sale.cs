using System;
using System.ComponentModel.DataAnnotations;

namespace GermanOutletStore.Models
{
    public class Sale
    {
        [Key]
        public int Id { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
        public decimal DiscountPrice { get; set; }

        public DateTime StartsOn { get; set; }
        public DateTime EndsOn { get; set; }
    }
}
