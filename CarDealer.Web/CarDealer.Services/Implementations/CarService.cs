namespace CarDealer.Services.Implementations
{
    using System.Collections.Generic;
    using CarDealer.Services.Models;
    using CarDealer.Data;
    using System.Linq;
    using CarDealer.Services.Models.Cars;
    using CarDealer.Data.Models;

    public class CarService : ICarService
    {
        private readonly CarDealerDbContext db;

        public CarService(CarDealerDbContext db)
        {
            this.db = db;
        }

        public void Create(string make, string model, long travelledDistance, IEnumerable<int> parts)
        {
            var existingParts = this.db
                .Parts
                .Where(p => parts.Contains(p.Id))
                .Select(p => p.Id)
                .ToList();

            var car = new Car
            {
                Make = make,
                Model = model,
                TravelledDistance = travelledDistance
            };

            foreach (var partId in existingParts)
            {
                car.Parts.Add(new PartCar { PartId = partId });
            }

            this.db.Add(car);
            this.db.SaveChanges();
        }

        public IEnumerable<CarModel> OrderedCars(string make)
        {
            var carQuery = this.db
                .Cars
                .Where(c => c.Make.ToLower() == make.ToLower())
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .ToList();

            return carQuery
                .Select(c => new CarModel
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                });
        }

        public IEnumerable<CarWithPartsModel> WithParts(int id)
        {
            return db
                .Cars
                .Where(c => c.Id == id)
                .Select(c => new CarWithPartsModel
            {
                Make = c.Make,
                Model = c.Model,
                TravelledDistance = c.TravelledDistance,
                Parts = c.Parts
                .Select(p => new PartsModel
                {
                    Name = p.Part.Name,
                    Price = p.Part.Price
                })
            });
        }

        public IEnumerable<CarWithPartsModel> AllCars()
        {
            return db
                .Cars
                .Select(c => new CarWithPartsModel
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance,
                    Parts = c.Parts
                    .Select(p => new PartsModel
                    {
                        Name = p.Part.Name,
                        Price = p.Part.Price
                    })
                })
                .ToList();
        }
    }
}
