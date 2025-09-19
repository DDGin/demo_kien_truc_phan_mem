using AutoMapper;
using Library.Models;
using Library.Services;
using Library.Web.Models.BooksViewModel;
using Library.Web.Models.BooksViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Library.Web.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        private readonly ICategoryService _categoryService;
        private readonly IAuthorService _authorService;
        private IMapper _mapper;

        public BookController(IBookService bookService, IMapper mapper, ICategoryService categoryService, IAuthorService authorService)
        {
            _bookService = bookService;
            _mapper = mapper;
            _categoryService = categoryService;
            _authorService = authorService;
        }
        public async Task<IActionResult> Index()
        {
            var books = await _bookService.GetAllBooks();
            var bookViewModel = _mapper.Map<List<BookViewModel>>(books);
            return View(bookViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var books = await _bookService.GetAllBooks();

            var bookViewModel = _mapper.Map<List<BookViewModel>>(books);
            return Json(new { data = bookViewModel });
        }
        [HttpGet]
        public async Task<IActionResult> GetBookById(Guid id)
        {
            var book = await _bookService.GetBook(id);
            var bookViewModel = _mapper.Map<BookViewModel>(book);
            return Json(bookViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(BookCreateViewModel bookViewModel)
        {
            if (ModelState.IsValid)
            {
                var book = _mapper.Map<Book>(bookViewModel);
                book.Id = Guid.NewGuid();
                book.PublicationDate = DateTime.UtcNow;
                await _bookService.AddBook(book);
                return Json(new { success = true, message = "Create Successful" });
            }
            return Json(new { success = false, message = "Create Not Successful" });
        }
        [HttpPost]
        public async Task<IActionResult> Update(BookViewModel bookViewModel)
        {
            if (ModelState.IsValid)
            {
                var book = _mapper.Map<Book>(bookViewModel);
                await _bookService.UpdateBook(book);
                return Json(new { success = true, message = "Update Successful" });
            }
            return Json(new { success = false, message = "Update Not Successful" });
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var book = await _bookService.GetBook(id);
            if (book == null)
            {
                return Json(new { success = false, message = "Delete Not Successful" });
            }
            await _bookService.DeleteBook(id);
            return Json(new { success = true, message = "Delete Successful" });
        }


    }
}
