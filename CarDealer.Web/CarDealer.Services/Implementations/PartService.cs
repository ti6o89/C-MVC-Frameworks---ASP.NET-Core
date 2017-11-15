namespace CarDealer.Services.Implementations
{
    using System.Collections.Generic;
    using CarDealer.Services.Models.Parts;
    using CarDealer.Data;
    using System.Linq;
    using CarDealer.Data.Models;

    public class PartService : IPartService
    {
        private readonly CarDealerDbContext db;

        public PartService(CarDealerDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<PartsListingModel> AllListings()
        {
            return this.db
                .Parts
                .Select(p => new PartsListingModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Quantity = p.Quantity,
                    SupplierName = p.Supplier.Name
                })
                .ToList();
        }

        public IEnumerable<PartBasicModel> All()
            => this.db
            .Parts
            .OrderBy(p => p.Id)
            .Select(p => new PartBasicModel
            {
                Id = p.Id,
                Name = p.Name
            })
            .ToList();

        public void Create(string name, decimal price, int quantity, int supplierId)
        {
            var part = new Part
            {
                Name = name,
                Price = price,
                Quantity = quantity > 0 ? quantity : 1,
                SupplierId = supplierId
            };

            this.db.Add(part);
            this.db.SaveChanges();
        }

        public void Edit(int id, decimal price, int quantity)
        {
            var existingPart = this.db.Parts.Find(id);

            if (existingPart == null)
            {
                return;
            }

            existingPart.Price = price;
            existingPart.Quantity = quantity;

            this.db.SaveChanges();
        }

        public void Delete(int id)
        {
            var part = this.db.Parts.Find(id);

            if (part == null)
            {
                return;
            }

            this.db.Parts.Remove(part);
            this.db.SaveChanges();
        }

        public FormModel ById(int id)
        {
            return this.db
                .Parts
                .Where(p => p.Id == id)
                .Select(p => new FormModel
                {
                    Name = p.Name,
                    Price = p.Price,
                    Quantity = p.Quantity
                })
                .FirstOrDefault();
        }
    }
}
