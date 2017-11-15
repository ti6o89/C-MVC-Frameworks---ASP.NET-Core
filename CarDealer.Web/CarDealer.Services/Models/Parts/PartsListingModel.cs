namespace CarDealer.Services.Models.Parts
{
    public class PartsListingModel : PartsModel
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public string SupplierName { get; set; }
    }
}
