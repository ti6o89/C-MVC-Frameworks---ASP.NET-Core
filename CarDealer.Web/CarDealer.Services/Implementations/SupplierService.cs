namespace CarDealer.Services.Implementations
{
    using System.Collections.Generic;
    using CarDealer.Services.Models;
    using System.Linq;
    using CarDealer.Data;
    using System;
    using CarDealer.Services.Models.Suppliers;

    public class SupplierService : ISupplierService
    {
        private readonly CarDealerDbContext db;

        public SupplierService(CarDealerDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<SupplierModel> All()
            => this.db
            .Suppliers
            .OrderBy(s => s.Name)
            .Select(s => new SupplierModel
            {
                Id = s.Id,
                Name = s.Name
            })
            .ToList();

        public IEnumerable<SupplierListingModel> AllListings(SuppliersType type)
        {
            var suppliersQuery = this.db.Suppliers.AsQueryable();

            switch (type)
            {
                case SuppliersType.Local:
                    suppliersQuery = suppliersQuery.Where(s => s.IsImporter == false);

                    break;
                case SuppliersType.Importers:
                    suppliersQuery = suppliersQuery.Where(s => s.IsImporter == true);

                    break;

                default:
                    throw new InvalidOperationException($"Invalid suppliers type: {type}");
            }

            return suppliersQuery
                .Select(s => new SupplierListingModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    NumberOfParts = s.Parts.Count()
                });
        }
    }
}
