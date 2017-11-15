namespace CarDealer.Web.Models.Suppliers
{
    using CarDealer.Services.Models;
    using System.Collections.Generic;

    public class FilteredSuppliersModel
    {
        public IEnumerable<SupplierListingModel> Suppliers { get; set; }

        public SuppliersType Type { get; set; }
    }
}
