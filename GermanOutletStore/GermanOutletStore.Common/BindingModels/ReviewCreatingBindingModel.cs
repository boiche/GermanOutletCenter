using System;

namespace GermanOutletStore.Common.BindingModels
{
    public class ReviewCreatingBindingModel
    {
        public string Content { get; set; }
        public DateTime PublishedOn { get; set; }
        public string CustomerId { get; set; }
        public int ProductId { get; set; }
        public double Rating { get; set; }
    }
}
