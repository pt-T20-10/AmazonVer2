using System.Runtime.CompilerServices;
namespace AmazonWebsite.ViewModels
{
    
        public class ProductVM
        {
            public int ProducID { get; set; }
            public string? ProductName { get; set; }
            public string? Image { get; set; }
            public double Price { get; set; }
            public string? ShortDescription { get; set; }
            public string? TypeName { get; set; }
        }
        public class ProductDetailVM
        {
            public int ProducID { get; set; }
            public string? ProductName { get; set; }
            public string? Image { get; set; }
            public double Price { get; set; }
            public string? ShortDescription { get; set; }
            public string? TypeName { get; set; }
            public string? Details { get; set; }
            public int Rating { get; set; }
            public int SoluongTon { get; set; }
        }
    
}
