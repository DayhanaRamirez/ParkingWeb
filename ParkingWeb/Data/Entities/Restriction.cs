using System.ComponentModel.DataAnnotations;

namespace ParkingWeb.Data.Entities
{
    public class Restriction
    {
        public int Id { get; set; }

        [Display(Name = "Día")]
        [MaxLength(10, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Day { get; set; }

        [Display(Name = "Vehículo 1")]
        [MaxLength(1, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Car1 { get; set; }

        [Display(Name = "Vehículo 2")]
        [MaxLength(1, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Car2 { get; set; }

        [Display(Name = "Motocicleta 1")]
        [MaxLength(1, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Motorcycle1 { get; set; }

        [Display(Name = "Motocicleta 2")]
        [MaxLength(1, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Motorcycle2 { get; set; }
    }
}
