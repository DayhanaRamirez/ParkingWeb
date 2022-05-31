using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace ParkingWeb.Models
{
    public class EditUserViewModel
    {
        public string Id { get; set; }

        [Display(Name = "Documento")]
        [MaxLength(20, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Document { get; set; }

        [Display(Name = "Nombres")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string FirstName { get; set; }

        [Display(Name = "Apellidos")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string LastName { get; set; }

        [Display(Name = "Foto")]
        public Guid ImageId { get; set; }

        [Display(Name = "Foto")]
        public string ImageFullPath => ImageId == Guid.Empty
            ? $"https://localhost:7117/images/no-image.png"
            : $"https://parkingweb.blob.core.windows.net/users/{ImageId}";

        [Display(Name = "Foto")]
        public IFormFile? ImageFile { get; set; }

        public IEnumerable<SelectListItem>? Vehicles { get; set; }

        public IEnumerable<SelectListItem>? VehicleTypes { get; set; }

    }
}
