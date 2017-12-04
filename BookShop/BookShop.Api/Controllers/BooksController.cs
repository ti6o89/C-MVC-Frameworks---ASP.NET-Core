namespace BookShop.Api.Controllers
{
    using Infrastructure.Exstensions;
    using Microsoft.AspNetCore.Mvc;
    using Services;
    using System.Threading.Tasks;
    using static WebConstants;

    public class BooksController : BaseController
    {
        private readonly IBookService books;

        public BooksController(IBookService books)
        {
            this.books = books;
        }

        [HttpGet(WithId)]
        public async Task<IActionResult> Get(int id)
            => this.OkOrNotFound(await this.books.Details(id));
    }
}
