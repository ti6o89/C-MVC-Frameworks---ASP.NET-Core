namespace CarDealer.Web.Models.Sales
{
    using CarDealer.Services.Models.Sales;

    public class SaleDetailsByIdModel
    {
        public int Id { get; set; }

        public SaleDetailsModel Sale { get; set; }
    }
}
