namespace BookShop.Services
{
    using BookShop.Services.Models.Books;
    using Services.Models.Author;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IAuthorService
    {
        Task<AuthorDetailsServiceModel> Details(int id);

        Task<int> Create(string firstName, string lastName);

        Task<IEnumerable<BookWithCategoriesServiceModel>> Books(int authorId);
    }
}
