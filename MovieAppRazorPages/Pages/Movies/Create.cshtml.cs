using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieAppRazorPages.Models;
using MovieAppRazorPages.Repository;

namespace MovieAppRazorPages.Pages.Movies
{
    public class CreateModel : PageModel
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMovieRepository _accountRepository;
        public CreateModel(IGenreRepository GenreRepository, IMovieRepository MovieRepository)
        {
            _genreRepository = GenreRepository;
            _accountRepository = MovieRepository;
        }

        [BindProperty]
        public Movie Movies { get; set; } = default!;

        public async Task<IActionResult> OnGet()
        {
            ViewData["AllGenres"] = await _genreRepository.GetAll();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _accountRepository.Create(Movies);
            return RedirectToPage("/Index");
        }
    }
}
