namespace BookShop.Services
{
    using Models.Books;
    using System.Threading.Tasks;

    public interface IBookService
    {
        Task<BookDetailsServiceModel> Details(int id);
    }
}
