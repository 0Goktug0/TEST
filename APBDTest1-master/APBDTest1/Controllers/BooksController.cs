using APBDTest1.Data.Repositories;
using APBDTest1.Dtos;
using APBDTest1.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/books")]
public class BooksController : ControllerBase
{
    private readonly IBooksRepository _booksRepository;

    public BooksController(IBooksRepository booksRepository)
    {
        _booksRepository = booksRepository;
    }

    [HttpGet("{id}/editions")]
    public async Task<ActionResult<IEnumerable<BookEdition>>> GetBookEditions(int id)
    {
        var editions = await _booksRepository.GetBookEditionsAsync(id);
        if (!editions.Any())
            return NotFound();

        return Ok(editions);
    }

    [HttpPost]
    public async Task<ActionResult<Book>> AddBook([FromBody] BookCreationDto bookDto)
    {
        var book = new Book { Title = bookDto.BookTitle };
        var edition = new BookEdition
        {
            EditionTitle = bookDto.EditionTitle,
            PublishingHouseId = bookDto.PublishingHouseId,
            ReleaseDate = bookDto.ReleaseDate
        };

        var addedBook = await _booksRepository.AddBookAsync(book, edition);
        return CreatedAtAction(nameof(GetBookEditions), new { id = addedBook.Id }, addedBook);
    }
}
