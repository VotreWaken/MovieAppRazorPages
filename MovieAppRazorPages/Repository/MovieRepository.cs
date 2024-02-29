using MovieAppRazorPages.Models;
using Microsoft.EntityFrameworkCore;

namespace MovieAppRazorPages.Repository
{
    public class MovieRepository : IMovieRepository
    {
        // Context
        private readonly MovieContext _context;

        // Constructor
        public MovieRepository(MovieContext context)
        {
            _context = context;
        }

        // Get All Movies
        public async Task<List<Movie>> GetAll()
        {
            return await _context.Movie.ToListAsync();
        }
        public async Task<Movie> GetMovieWithGenres(int movieId)
        {
            var movie = await _context.Movie
                .Where(m => m.Id == movieId)
                .FirstOrDefaultAsync();

            if (movie == null)
            {
                return null;
            }

            var genreIds = await _context.MovieGenre
                .Where(mg => mg.MovieId == movie.Id)
                .Select(mg => mg.GenreId)
                .ToListAsync();

            var genres = await _context.Genre
                .Where(g => genreIds.Contains(g.Id))
                .ToListAsync();

            var movieGenres = genres.Select(g => new MovieGenre
            {
                Genre = g,
                Movie = movie
            }).ToList();

            movie.MovieGenres = movieGenres;

            return movie;
        }
        public async Task<IEnumerable<Movie>> GetMoviesWithGenres()
        {
            var movies = await _context.Movie.ToListAsync();

            foreach (var movie in movies)
            {
                var genreIds = await _context.MovieGenre
                    .Where(mg => mg.MovieId == movie.Id)
                    .Select(mg => mg.GenreId)
                    .ToListAsync();

                var genres = await _context.Genre
                    .Where(g => genreIds.Contains(g.Id))
                    .ToListAsync();

                var movieGenres = genres.Select(g => new MovieGenre
                {
                    Genre = g,
                    Movie = movie
                }).ToList();

                movie.MovieGenres = movieGenres;
            }

            return movies;
        }

        // Get Movie By Id
        public async Task<Movie> GetById(int id)
        {
            return await _context.Movie.FindAsync(id);
        }

        // Create Movie
        public async Task<Movie> Create(Movie movie)
        {
            if (movie == null)
            {
                throw new ArgumentNullException(nameof(movie));
            }

            await _context.Movie.AddAsync(movie);
            await _context.SaveChangesAsync();
            return movie;
        }
        // Update Movie
        public async Task Update(Movie movie)
        {
            if (movie == null)
            {
                throw new ArgumentNullException(nameof(movie));
            }

            _context.Movie.Update(movie);
            await _context.SaveChangesAsync();
        }
        // Delete Movie
        public async Task Delete(int id)
        {
            var movie = await GetById(id);
            if (movie != null)
            {
                _context.Movie.Remove(movie);
                await _context.SaveChangesAsync();
            }
        }
    }
}
