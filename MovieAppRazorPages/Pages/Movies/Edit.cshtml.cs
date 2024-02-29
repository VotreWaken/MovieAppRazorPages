using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieAppRazorPages.Models;
using MovieAppRazorPages.Repository;

namespace MovieAppRazorPages.Pages.Movies
{
    public class EditModel : PageModel
    {
        private readonly IGenreRepository _Repository;
        private readonly IMovieRepository _accountRepository;
        private readonly IWebHostEnvironment _appEnvironment;
        public EditModel(IGenreRepository Repository, IMovieRepository AccountRepository, IWebHostEnvironment appEnvironment)
        {
            _Repository = Repository;
            _accountRepository = AccountRepository;
            _appEnvironment = appEnvironment;
        }

        [BindProperty]
        public Movie Movies { get; set; } = default!;
        public async Task<IActionResult> OnGet(int id)
        {
            ViewData["AllGenres"] = await _Repository.GetAll();
            Movies = await _accountRepository.GetById(id);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Movie movie = new Movie()
            {
                Id = Movies.Id,
                MovieTitle = Movies.MovieTitle,
                MovieDescription = Movies.MovieDescription,
                Director = Movies.Director,
                ProductionDate = Movies.ProductionDate,
                FilmImage = Movies.FilmImage,
                MovieGenres = Movies.MovieGenres,
                SelectedGenres = Movies.SelectedGenres
            };

            if (Movies == null)
            {
                return NotFound();
            }

            await _accountRepository.Update(movie);

            return RedirectToPage("/Index");
        }
    }
}