using System.ComponentModel.DataAnnotations;

namespace ParkingWeb.Data.Entities
{
    public class Vehicle
    {
        public int Id { get; set; }

        [Display(Name = "Matrícula")]
        [MaxLength(6, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string LicensePlate { get; set; }

        [Display(Name = "Modelo")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Model { get; set; }

        public User User { get; set; }

        public VehicleType VehicleType { get; set; }    
    }
}
