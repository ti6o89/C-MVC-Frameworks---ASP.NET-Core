namespace CarDealer.Web.Controllers
{
    using CarDealer.Web.Models.Cars;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Services;
    using System.Collections.Generic;
    using System.Linq;

    [Route("cars")]
    public class CarsController : Controller
    {
        private readonly ICarService cars;
        private readonly IPartService parts;

        public CarsController(ICarService cars, IPartService parts)
        {
            this.cars = cars;
            this.parts = parts;
        }

        [Authorize]
        [Route("create")]
        public IActionResult Create() 
            => View(new CarFormModel
            {
                AllParts = this.GetPartsSelectItems()
            });

        [Authorize]
        [HttpPost]
        [Route("create")]
        public IActionResult Create(CarFormModel formModel)
        {
            if (!ModelState.IsValid)
            {
                formModel.AllParts = this.GetPartsSelectItems();
                return View(formModel);
            }

            this.cars.Create(
                formModel.Make,
                formModel.Model,
                formModel.TravelledDistance,
                formModel.SelectedParts);

            return RedirectToAction(nameof(All));
        }

        [Route("{make}")]
        public IActionResult ByMake(string make)
        {
            var cars = this.cars.OrderedCars(make);

            return View(new CarsByMakeModel
            {
                Make = make,
                Cars = cars
            });
        }

        [Route("{id}/parts")]
        public IActionResult Parts(string id)
        {
            var car = this.cars.WithParts(int.Parse(id));

            return View(new WitPartsModel
            {
                Id = int.Parse(id),
                Car = car
            });
        }

        [Route("all")]
        public IActionResult All()
        {
            return View(this.cars.AllCars());
        }

        private IEnumerable<SelectListItem> GetPartsSelectItems()
            => this.parts
                .All()
                .Select(p => new SelectListItem
                {
                    Text = p.Name,
                    Value = p.Id.ToString()
                });
    }
}
