﻿namespace BookShop.Api.Controllers
{
    using Services;
    using Microsoft.AspNetCore.Mvc;
    using Infrastructure.Exstensions;
    using Models.Authors;
    using System.Threading.Tasks;
    using Infrastructure.Filters;

    using static WebConstants;

    public class AuthorsController : BaseController
    {
        private readonly IAuthorService authors;

        public AuthorsController(IAuthorService authors)
        {
            this.authors = authors;
        }

        [HttpGet(WithId)]
        public async Task<IActionResult> Get(int id)
            => this.OkOrNotFound(await this.authors.Details(id));

        [HttpGet]
        public async Task<IActionResult> GetBooks(int id)
            => this.Ok(await authors.Books(id));

        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Post([FromBody]AuthorRequestModel model)
            => Ok(await this.authors.Create(
                model.FirstName,
                model.LastName));
    }
}
