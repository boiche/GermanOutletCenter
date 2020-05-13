using System;

namespace GermanOutletStore.Common.BindingModels
{
    public class OrderCreationBindingModel
    {
        public int Quantity { get; set; }

        public string SizeName { get; set; }
        public int SizeId { get; set; }

        public string ProductName { get; set; }
        public int OrderedProductId { get; set; }

        public DateTime TimeOfOrder { get; set; }
    }
}
