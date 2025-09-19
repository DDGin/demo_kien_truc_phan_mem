using Library.Models;
using Library.Repositories.UnitOfWorkPattern;

namespace Library.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task AddAuthor(Author author)
        {
            await _unitOfWork.GenericRepository<Author>().AddAsync(author);
            _unitOfWork.Save();
        }

        public async Task DeleteAuthor(Guid id)
        {
            var author = await _unitOfWork.GenericRepository<Author>().GetByIdAsync(filter: x => x.Id == id);
            _unitOfWork.GenericRepository<Author>().Delete(author);
            _unitOfWork.Save();
        }

        public async Task<IEnumerable<Author>> GetAllAuthors()
        {
            return await _unitOfWork.GenericRepository<Author>().GetAll();
        }

        public async Task<Author> GetAuthor(Guid id)
        {
            return await _unitOfWork.GenericRepository<Author>().GetByIdAsync(filter: x => x.Id == id);
        }

        public async Task UpdateAuthor(Author author)
        {
            var AuthorFromDb = await _unitOfWork.GenericRepository<Author>().GetByIdAsync(filter: x => x.Id == author.Id);
            if (AuthorFromDb != null)
            {
                AuthorFromDb.Name = author.Name;
                AuthorFromDb.Bio = author.Bio;
                _unitOfWork.GenericRepository<Author>().Update(AuthorFromDb);
                _unitOfWork.Save();
            }
        }
    }
}