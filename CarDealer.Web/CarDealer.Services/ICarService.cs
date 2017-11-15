namespace CarDealer.Services
{
    using CarDealer.Services.Models;
    using CarDealer.Services.Models.Cars;
    using System.Collections.Generic;

    public interface ICarService
    {
        IEnumerable<CarModel> OrderedCars(string make);

        IEnumerable<CarWithPartsModel> WithParts(int id);

        IEnumerable<CarWithPartsModel> AllCars();

        void Create(string make, string model, long travelledDistance, IEnumerable<int> parts);
    }
}
