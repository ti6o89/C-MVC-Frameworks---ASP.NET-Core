namespace CarDealer.Services.Models.Cars
{
    using System.Collections.Generic;

    public class CarWithPartsModel : CarModel
    {
        public IEnumerable<PartsModel> Parts { get; set; }
    }
}
