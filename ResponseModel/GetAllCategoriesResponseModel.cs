using EcommerceOfficial.Entities;

namespace EcommerceOfficial.ResponseModel
{
    public class GetAllCategoriesResponseModel
    {
        public List<Category> Categories { get; set; } = new List<Category>();
    }
}
