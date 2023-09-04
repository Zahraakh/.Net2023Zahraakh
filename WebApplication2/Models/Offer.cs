namespace CmsShoppingCart.Models
{
    public class Offer
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public decimal DiscountPercentage { get; set; }
    }
}
