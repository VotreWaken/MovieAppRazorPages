using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieAppRazorPages.Models;
using MovieAppRazorPages.Repository;

namespace MovieAppRazorPages.Pages.Movies
{
    public class DeleteModel : PageModel
    {
        private readonly IMovieRepository _movieRepository;
        IMovieGenreRepository _movieGenreRepository;
        public DeleteModel(IMovieRepository Repository, IMovieGenreRepository movieGenreRepository)
        {
            _movieRepository = Repository;
            this._movieGenreRepository = movieGenreRepository;
        }

        [BindProperty(SupportsGet = true)]
        public Movie Movies { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            await _movieGenreRepository.Delete(id.Value);
            await _movieRepository.Delete(id.Value);

            return RedirectToPage("/Index");
        }
    }
}
