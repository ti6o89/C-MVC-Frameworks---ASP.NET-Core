namespace CarDealer.Web.Models.Customers
{
    using CarDealer.Services.Models.Customers;

    public class GetById
    {
        public int Id { get; set; }

        public ByIdModel Customer { get; set; }
    }
}
