using MovieAppRazorPages.Models;
using Microsoft.EntityFrameworkCore;
namespace MovieAppRazorPages.Repository
{
    public class MovieGenreRepository : IMovieGenreRepository
    {
        // Context
        private readonly MovieContext _context;

        // Constructor
        public MovieGenreRepository(MovieContext context)
        {
            _context = context;
        }

        // Get All Audio Genres
        public async Task<List<MovieGenre>> GetAll()
        {
            return await _context.MovieGenre.ToListAsync();
        }

        // Get All Audio Genres By Id
        public async Task<MovieGenre> GetById(int audioId, int genreId)
        {
            return await _context.MovieGenre.FindAsync(audioId, genreId);
        }

        // Get All Audio Genres By Id
        public async Task<MovieGenre> GetByMovie(int movieId, int genreId)
        {
            return await _context.MovieGenre.FirstOrDefaultAsync(mg => mg.MovieId == movieId && mg.GenreId == genreId);
        }

        // Create Audio Genres
        public async Task<MovieGenre> Create(MovieGenre audioGenre)
        {
            _context.MovieGenre.Add(audioGenre);
            await _context.SaveChangesAsync();
            return audioGenre;
        }

        // Update Audio Genres
        public async Task Update(MovieGenre audioGenre)
        {
            _context.Entry(audioGenre).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        // Delete Audio Genres
        public async Task Delete(int audioId)
        {
            var movieGenresToDelete = _context.MovieGenre.Where(mg => mg.MovieId == audioId);
            if (movieGenresToDelete != null)
            {
                _context.MovieGenre.RemoveRange(movieGenresToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
}
