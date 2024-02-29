using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieAppRazorPages.Models;
using Microsoft.EntityFrameworkCore;
using MovieAppRazorPages.Repository;
namespace MovieAppRazorPages.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IGenreRepository _Repository;
        private readonly IMovieRepository _accountRepository;
        private readonly IWebHostEnvironment _appEnvironment;
        public IndexModel(IGenreRepository Repository, IMovieRepository AccountRepository, IWebHostEnvironment appEnvironment)
        {
            _Repository = Repository;
            _accountRepository = AccountRepository;
            _appEnvironment = appEnvironment;
        }
        [BindProperty]
        public IEnumerable<Movie> Movies { get; set; } = default!;
        public async Task<IActionResult> OnGet()
        {
            IEnumerable<Movie> movies = await _accountRepository.GetMoviesWithGenres();

            Movies = movies;
            return Page();
        }
    }
}
