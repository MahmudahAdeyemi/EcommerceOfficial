using System.ComponentModel.DataAnnotations;

namespace EcommerceOfficial.RequestModel
{
    public class CategoryRequestModel
    {
        [Required]
        public string Name { get; set; }
    }
}
