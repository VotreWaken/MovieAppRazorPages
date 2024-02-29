using MovieAppRazorPages.Models;

namespace MovieAppRazorPages.Repository
{
    public interface IMovieRepository : IRepository<Movie>
    {
        Task<IEnumerable<Movie>> GetMoviesWithGenres();
        Task<Movie> GetMovieWithGenres(int movieId);
    }
}
