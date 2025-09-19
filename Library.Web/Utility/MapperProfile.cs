using AutoMapper;
using Library.Models;
using Library.Web.Models.AuthorsViewModel;
using Library.Web.Models.AuthorsViewModels;
using Library.Web.Models.BooksViewModel;
using Library.Web.Models.BooksViewModels;
using Library.Web.Models.CategoriesViewModel;
using Library.Web.Models.CategoriesViewModels;

namespace Library.ViewModels.Utility
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Book, BookViewModel>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Author.Name));
            CreateMap<BookViewModel, Book>();
            CreateMap<BookCreateViewModel, Book>();
            CreateMap<Author, AuthorViewModel>().ReverseMap();
            CreateMap<Author, AuthorCreateViewModel>().ReverseMap();
            CreateMap<Category, CategoryViewModel>().ReverseMap();
            CreateMap<Category, CategoryCreateViewModel>().ReverseMap();
        }
    }
}
