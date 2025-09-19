using AutoMapper;
using Library.Models;
using Library.Services;
using Library.Web.Models.AuthorsViewModel;
using Library.Web.Models.AuthorsViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Library.Web.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;
        private IMapper _mapper;

        public AuthorController(IAuthorService authorService, IMapper mapper)
        {
            _authorService = authorService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var authors = await _authorService.GetAllAuthors();
            var authorViewModel = _mapper.Map<List<AuthorViewModel>>(authors);
            return Json(new { data = authorViewModel });
        }

        [HttpGet]
        public async Task<IActionResult> GetAuthorById(Guid id)
        {
            // Id	{a3da8db9-6b87-4d9d-89df-7007b0dadaf1}	System.Guid
            var author = await _authorService.GetAuthor(id);
            // Author{Id: 5c595a13-2911-4ead-be8e-cf4f30eee859} 		
            var authorViewModel = _mapper.Map<AuthorViewModel>(author);
            return Json(authorViewModel);
            // Id lấy khác với Id được trả lại, biết rằng cả 2 id đều tồn tại trong cơ sở dữ liệu
        }

        [HttpPost]
        public async Task<IActionResult> Create(AuthorCreateViewModel authorViewModel)
        {
            if (ModelState.IsValid)
            {
                var author = _mapper.Map<Author>(authorViewModel);
                author.Id = Guid.NewGuid();
                await _authorService.AddAuthor(author);
                return Json(new { success = true, message = "Create Successful" });
            }
            return Json(new { success = false, message = "Create Not Successful" });
        }

        [HttpPost]
        public async Task<IActionResult> Update(AuthorViewModel authorViewModel)
        {
            if (ModelState.IsValid)
            {
                var author = _mapper.Map<Author>(authorViewModel);
                await _authorService.UpdateAuthor(author);
                return Json(new { success = true, message = "Update Successful" });
            }
            return Json(new { success = false, message = "Update Not Successful" });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var author = await _authorService.GetAuthor(id);
            if (author == null)
            {
                return Json(new { success = false, message = "Delete Not Successful" });
            }
            await _authorService.DeleteAuthor(id);
            return Json(new { success = true, message = "Delete Successful" });
        }
    }
}
