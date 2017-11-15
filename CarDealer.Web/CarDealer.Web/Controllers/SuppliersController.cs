namespace CarDealer.Web.Controllers
{
    using CarDealer.Services;
    using CarDealer.Services.Models;
    using CarDealer.Web.Models.Suppliers;
    using Microsoft.AspNetCore.Mvc;

    public class SuppliersController : Controller
    {
        private readonly ISupplierService suppliers;

        public SuppliersController(ISupplierService suppliers)
        {
            this.suppliers = suppliers;
        }

        [Route("suppliers/{type}")]
        public IActionResult Filtered(string type)
        {
            var filter = type.ToLower() == "local"
                ? SuppliersType.Local
                : SuppliersType.Importers;

            var filteredSuppliers = suppliers.AllListings(filter);

            return View(new FilteredSuppliersModel
            {
                Suppliers = filteredSuppliers,
                Type = filter
            });
        }
    }
}
