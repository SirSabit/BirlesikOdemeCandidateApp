namespace Boca.Dtos.Payzee.Pay
{
    public class ProductDto
    {
        public int MerchantId { get; set; }
        public string ProductId { get; set; }
        public string Amount { get; set; }
        public string ProductName { get; set; }
        public string CommissionRate { get; set; }
    }

    
}
