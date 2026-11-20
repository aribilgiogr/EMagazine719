using BLL.DTOs;
using DAL.UnitOfWorks;

namespace BLL.Services
{
    public interface ICategoryService
    {
        Task<Reply> CreateAsync(NewCategoryDto newCategory);
        EditCategoryDto? GetForEdit(int id);
        Task<Reply> UpdateAsync(int id, EditCategoryDto editCategory);
        Task<Reply> DeleteAsync(int id);
        IEnumerable<CategoryDto> GetList(bool justActive = true);
    }
}
