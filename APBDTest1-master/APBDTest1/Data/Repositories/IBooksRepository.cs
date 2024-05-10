using APBDTest1.Data;
using APBDTest1.Models;
using Microsoft.EntityFrameworkCore;

public interface IBooksRepository
{
    Task<IEnumerable<BookEdition>> GetBookEditionsAsync(int bookId);
    Task<Book> AddBookAsync(Book book, BookEdition edition);
}

public class BooksRepository : IBooksRepository
{
    private readonly ApplicationDbContext _context;

    public BooksRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<BookEdition>> GetBookEditionsAsync(int bookId)
    {
        return await _context.BookEditions
            .Include(e => e.PublishingHouse)
            .Where(e => e.BookId == bookId)
            .ToListAsync();
    }

    public async Task<Book> AddBookAsync(Book book, BookEdition edition)
    {
        var addedBook = _context.Books.Add(book);
        await _context.SaveChangesAsync();

        edition.BookId = addedBook.Entity.Id;
        _context.BookEditions.Add(edition);
        await _context.SaveChangesAsync();

        return addedBook.Entity;
    }
}
