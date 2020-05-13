using System.ComponentModel.DataAnnotations;

namespace GermanOutletStore.Models
{
    public class ProductOrders
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }

        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }

        public int SizeId { get; set; }
        public Size Size { get; set; }

        public bool IsDelivered { get; set; }
    }
}
