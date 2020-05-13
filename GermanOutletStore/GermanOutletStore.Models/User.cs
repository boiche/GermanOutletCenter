using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace GermanOutletStore.Models
{
    public class User : IdentityUser
    {
        public User()
        {
            this.Orders = new List<Order>();
            this.Reviews = new List<Review>();
        }

        public string FullName { get; set; }

        public ICollection<Order> Orders { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
