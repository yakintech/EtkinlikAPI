using System.ComponentModel.DataAnnotations;

namespace EtkinlikAPI.Models.DTO
{
    public class CreateCategoryRequestDto
    {

       // [Required(ErrorMessage = "Name is required")]  dilerseniz validationlari bu bolgeye de yazabilirsiniz
        public string Name { get; set; }
    }
}
