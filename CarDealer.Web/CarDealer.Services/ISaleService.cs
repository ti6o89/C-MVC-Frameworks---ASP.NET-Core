namespace CarDealer.Services
{
    using CarDealer.Services.Models;
    using CarDealer.Services.Models.Sales;
    using System.Collections.Generic;

    public interface ISaleService
    {
        IEnumerable<SalesListModel> GetAll();

        SaleDetailsModel GetDetails(int Id);

        IEnumerable<SalesListModel> DiscountedSales();

        IEnumerable<SalesListModel> SalesByPercentage(double percent);
    }
}
