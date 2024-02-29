using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieAppRazorPages.Models;
using MovieAppRazorPages.Repository;
using NuGet.Protocol.Core.Types;

namespace MovieAppRazorPages.Pages.Movies
{
    public class DetailsModel : PageModel
    {
        private readonly IMovieRepository _movieRepository;
        public DetailsModel(IMovieRepository AccountRepository)
        {
            _movieRepository = AccountRepository;
        }

        [BindProperty]
        public Movie Movies { get; set; } = default!;

        public async Task<IActionResult> OnGet(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _movieRepository.GetMovieWithGenres(id);

            if (movie == null)
            {
                return NotFound();
            }

            Movies = movie;

            return Page();
        }
    }
}
