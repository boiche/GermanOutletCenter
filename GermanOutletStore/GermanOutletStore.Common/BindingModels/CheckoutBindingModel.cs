using GermanOutletStore.Common.ViewModels;
using GermanOutletStore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GermanOutletStore.Common.BindingModels
{
    public class CheckoutBindingModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string PostalCode { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }

        public DateTime TimeOfOrder { get; set; }
        public DateTime ExpectedTimeOfDeliver { get; set; }

        public List<ProductCheckoutViewModel> OrderedProducts { get; set; }

        public string CustomerId { get; set; }
        public User Customer { get; set; }

        public List<string> Countries { get; set; }

        public decimal Total { get; set; }
    }
}
