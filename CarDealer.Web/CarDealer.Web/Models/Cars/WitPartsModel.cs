namespace CarDealer.Web.Models.Cars
{
    using CarDealer.Services.Models.Cars;
    using System.Collections.Generic;

    public class WitPartsModel
    {
        public int Id { get; set; }

        public IEnumerable<CarWithPartsModel> Car { get; set; }
    }
}
