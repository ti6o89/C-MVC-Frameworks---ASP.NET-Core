namespace CarDealer.Web.Controllers
{
    using CarDealer.Services;
    using Microsoft.AspNetCore.Mvc;

    public class SalesController : Controller
    {
        private readonly ISaleService sales;


        public SalesController(ISaleService sales)
        {
            this.sales = sales;
        }

        [Route("sales")]
        public IActionResult AllSales()
        {
            return View(this.sales.GetAll());
        }

        [Route("sales/{id}")]
        public IActionResult SaleDetails(int id)
        {
            return View(this.sales.GetDetails(id));
        }

        [Route("sales/discounted")]
        public IActionResult DiscountedSales()
        {
            return View(this.sales.DiscountedSales());
        }

        [Route("sales/discounted/{percent}")]
        public IActionResult DiscountedByPercentage(double percent)
        {
            return View(this.DiscountedByPercentage(percent));
        }
    }
}

