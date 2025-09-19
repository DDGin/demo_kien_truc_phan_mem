using AutoMapper;
using Library.Models;
using Library.Services;
using Library.Web.Models.CategoriesViewModel;
using Library.Web.Models.CategoriesViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Library.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAllCategories();
            var categoryViewModel = _mapper.Map<List<CategoryViewModel>>(categories);
            return Json(new { data = categoryViewModel });
        }
        [HttpGet]
        public async Task<IActionResult> GetCategoryById(Guid id)
        {
            var category = await _categoryService.GetCategory(id);
            var categoryViewModel = _mapper.Map<CategoryViewModel>(category);
            return Json(categoryViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreateViewModel categoryViewModel)
        {
            if (ModelState.IsValid)
            {
                var category = _mapper.Map<Category>(categoryViewModel);
                category.Id = Guid.NewGuid();
                await _categoryService.AddCategory(category);
                return Json(new { success = true, message = "Create Successful" });
            }
            return Json(new { success = false, message = "Create Not Successful" });
        }
        [HttpPost]
        public async Task<IActionResult> Update(CategoryViewModel categoryViewModel)
        {
            if (ModelState.IsValid)
            {
                var category = _mapper.Map<Category>(categoryViewModel);
                await _categoryService.UpdateCategory(category);
                return Json(new { success = true, message = "Update Successful" });
            }
            return Json(new { success = false, message = "Update Not Successful" });
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var category = await _categoryService.GetCategory(id);
            if (category != null)
            {
                await _categoryService.DeleteCategory(id);
                return Json(new { success = true, message = "Delete Successful" });
            }
            return Json(new { success = false, message = "Delete Not Successful" });
        }
    }
}
