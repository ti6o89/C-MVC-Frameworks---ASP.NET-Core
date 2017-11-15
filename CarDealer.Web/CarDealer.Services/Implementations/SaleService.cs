using System.Collections.Generic;
using CarDealer.Services.Models;
using CarDealer.Data;
using System.Linq;
using CarDealer.Services.Models.Sales;

namespace CarDealer.Services.Implementations
{
    public class SaleService : ISaleService
    {
        private readonly CarDealerDbContext db;

        public SaleService(CarDealerDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<SalesListModel> GetAll()
        {
            return this.db
                .Sales
                .Select(s => new SalesListModel
                {
                    Id = s.Id,
                    Customer = s.Customer.Name,
                    Price = s.Car.Parts.Sum(c => c.Part.Price),
                    Discount = s.Discount
                })
                .ToList();
        }

        public SaleDetailsModel GetDetails(int Id)
        {
            return this.db
                .Sales
                .Where(s => s.Id == Id)
                .Select(s => new SaleDetailsModel
                {
                    Id = s.Id,
                    Make = s.Car.Make,
                    Model = s.Car.Model,
                    CustomerName = s.Customer.Name
                })
                .FirstOrDefault();
        }

        public IEnumerable<SalesListModel> DiscountedSales()
        {
            return this.GetAll()
                .Where(s => s.Discount > 0.00)
                .ToList();
        }

        public IEnumerable<SalesListModel> SalesByPercentage(double percent)
        {
            return this.DiscountedSales()
                .Where(s => s.Discount == percent)
                .ToList();
        }
    }
}
