using ApiStudy.Model;
using ApiStudy.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiStudy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private IBookServices _bookService;
        private readonly ILogger<BooksController> _logger;

        public BooksController(
            IBookServices bookService,
            ILogger<BooksController> logger)
        {
            _bookService = bookService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("Getting all books");
            return Ok(_bookService.FindAll());
        }
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            _logger.LogInformation("Getting book by ID {id}", id);
            var book = _bookService.FindById(id);
            if (book == null)
            {
                _logger.LogWarning("Book with ID {id} not found", id);
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Book book)
        {
            _logger.LogInformation("Creating {Title} by {Author}", book.Title, book.Author);
            var createdBook = _bookService.Create(book);
            if (createdBook == null)
            {
                _logger.LogError("Failed to create book {Title} by {Author}", book.Title, book.Author);
                return NotFound();
            }
            return Ok(createdBook);
        }
        [HttpPut]
        public IActionResult Put([FromBody] Book book)
        {
            _logger.LogInformation("Updating {Title} by {Author}", book.Title, book.Author);
            var updatedBook = _bookService.Update(book);
            if (updatedBook == null)
            {
                _logger.LogError("Failed to update book {Title} by {Author}", book.Title, book.Author);
                return NotFound();
            }
            return Ok(book);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _logger.LogInformation("Deleting book with ID {id}", id);
            _bookService.Delete(id);
            return NoContent();
        }
    }
}
