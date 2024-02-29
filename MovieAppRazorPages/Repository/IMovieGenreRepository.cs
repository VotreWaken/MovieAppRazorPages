using MovieAppRazorPages.Models;

namespace MovieAppRazorPages.Repository
{
    public interface IMovieGenreRepository
    {
        // Get All Audio with Particular Genre
        Task<List<MovieGenre>> GetAll();

        // Create Audio with Particular Genre
        Task<MovieGenre> Create(MovieGenre audio);

        // Update Audio with Particular Genre
        Task Update(MovieGenre audioGenreDTO);

        // Get by Id Audio with Particular Genre
        Task<MovieGenre> GetById(int audioId, int genreId);

        // Delete Audio with Particular Genre
        Task Delete(int audioId);
    }
}
