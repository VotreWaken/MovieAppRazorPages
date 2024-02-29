using Microsoft.EntityFrameworkCore;
using MovieAppRazorPages.Models;

namespace MovieAppRazorPages.Repository
{
    public class GenreRepository : IGenreRepository
    {
        // Context
        private readonly MovieContext _context;

        // Constructor
        public GenreRepository(MovieContext context)
        {
            _context = context;
        }
        // Get All Genres
        public async Task<List<Genre>> GetAll()
        {
            return await _context.Genre.ToListAsync();
        }

        // Get Genre By Id
        public async Task<Genre> GetById(int id)
        {
            return await _context.Genre.FindAsync(id);
        }

        // Create Genre
        public async Task<Genre> Create(Genre genre)
        {
            if (genre == null)
            {
                throw new ArgumentNullException(nameof(genre));
            }

            await _context.Genre.AddAsync(genre);
            await _context.SaveChangesAsync();
            return genre;
        }
        // Update Genre
        public async Task Update(Genre genre)
        {
            if (genre == null)
            {
                throw new ArgumentNullException(nameof(genre));
            }

            _context.Genre.Update(genre);
            await _context.SaveChangesAsync();
        }
        // Delete Genre
        public async Task Delete(int id)
        {
            var genre = await GetById(id);
            if (genre != null)
            {
                _context.Genre.Remove(genre);
                await _context.SaveChangesAsync();
            }
        }
    }
}
