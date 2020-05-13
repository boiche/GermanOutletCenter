using System;
using System.ComponentModel.DataAnnotations;

namespace GermanOutletStore.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }

        [MinLength(10), MaxLength(256)]
        public string Content { get; set; }
        public double Rating { get; set; }

        public int ProductId { get; set; }
        public Product ReviewedProduct { get; set; }

        public string CustomerId { get; set; }
        public User Customer { get; set; }

        public DateTime PublishedOnDate { get; set; }
    }
}
