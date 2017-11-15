namespace CarDealer.Services.Models
{
    public class SalesListModel
    {
        public int Id { get; set; }

        public string Customer { get; set; }

        public decimal Price { get; set; }

        public double Discount { get; set; }

        public decimal DiscountedPrice => this.Price *(1 - (decimal)this.Discount);
    }
}
