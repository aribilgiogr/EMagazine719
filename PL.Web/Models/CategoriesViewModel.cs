using BLL.DTOs;

namespace PL.Web.Models
{
    public class CategoriesViewModel
    {
        public IEnumerable<CategoryDto> Categories { get; set; } = [];
        public NewCategoryDto? NewCategory { get; set; }
        public EditCategoryDto? EditCategory { get; set; }
    }
}
