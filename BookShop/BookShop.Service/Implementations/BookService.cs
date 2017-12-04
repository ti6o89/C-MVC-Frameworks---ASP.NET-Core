namespace BookShop.Services.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Models.Books;
    using System.Linq;
    using System.Threading.Tasks;

    public class BookService : IBookService
    {
        private readonly BookShopDbContext db;

        public BookService(BookShopDbContext db)
        {
            this.db = db;
        }

        public async Task<BookDetailsServiceModel> Details(int id)
            => await this.db
                .Books
                .Where(b => b.Id == id)
                .ProjectTo<BookDetailsServiceModel>()
                .FirstOrDefaultAsync();
    }
}
