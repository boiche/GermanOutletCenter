using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GermanOutletStore.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public ICollection<ProductOrders> Products { get; set; }

        public string CustomerId { get; set; }
        public User Customer { get; set; }

        public DateTime TimeOfOrder { get; set; }
        public DateTime ExpectedTimeOfDeliver { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
    }
}
