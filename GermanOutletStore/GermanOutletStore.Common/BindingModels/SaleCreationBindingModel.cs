using System;

namespace GermanOutletStore.Common.BindingModels
{
    public class SaleCreationBindingModel
    {
        public int? SaleId { get; set; }
        public decimal OldPrice { get; set; }
        public decimal NewPrice { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double ClearanceInProcent { get; set; }
        public DateTime StartsOn { get; set; }
        public DateTime EndsOn { get; set; }
    }
}
