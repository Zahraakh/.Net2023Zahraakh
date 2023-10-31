using Microsoft.AspNetCore.Mvc;

namespace CmsShoppingCart.Models
{
    public class Rate 
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int RatingValue { get; set; }
    }
}
