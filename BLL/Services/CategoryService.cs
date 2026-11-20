using BLL.DTOs;
using DAL.Entities;
using DAL.UnitOfWorks;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Reply> CreateAsync(NewCategoryDto newCategory)
        {
            var category = new Category
            {
                Name = newCategory.Name,
                Description = newCategory.Description,
            };
            var repo = unitOfWork.GetRepository<Category>();
            await repo.InsertOneAsync(category);
            return await unitOfWork.CommitAsync();
        }

        public async Task<Reply> DeleteAsync(int id)
        {
            var repo = unitOfWork.GetRepository<Category>();
            var category = await repo.Query().FirstOrDefaultAsync(x => x.Id == id);
            if (category != null)
            {
                repo.DeleteOne(category);
                return await unitOfWork.CommitAsync();
            }
            return Reply.Fail("Category not found!");
        }

        public EditCategoryDto? GetForEdit(int id)
        {
            var repo = unitOfWork.GetRepository<Category>();
            var category = repo.Query().FirstOrDefault(x => x.Id == id);
            if (category != null)
            {
                return new EditCategoryDto
                {
                    Id = id,
                    Name = category.Name,
                    Description = category.Description,
                };
            }
            return null;
        }

        public IEnumerable<CategoryDto> GetList(bool justActive = true)
        {
            var repo = unitOfWork.GetRepository<Category>();
            var categories = repo.Query()
                               .Where(justActive ? (x => x.Active) : (_ => true))
                               .Include(x => x.Posts);

            return categories.Select(x => new CategoryDto
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                PostCount = x.Posts.Count
            });
        }

        public async Task<Reply> UpdateAsync(int id, EditCategoryDto editCategory)
        {
            var repo = unitOfWork.GetRepository<Category>();
            var category = await repo.Query().FirstOrDefaultAsync(x => x.Id == id);
            if (category != null && id == editCategory.Id)
            {
                category.Name = editCategory.Name;
                category.Description = editCategory.Description ?? category.Description;
                repo.UpdateOne(category);
                return await unitOfWork.CommitAsync();
            }
            return Reply.Fail("Category not found!");
        }
    }
}
