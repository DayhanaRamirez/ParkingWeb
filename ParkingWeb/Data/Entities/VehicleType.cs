using System.ComponentModel.DataAnnotations;

namespace ParkingWeb.Data.Entities
{
    public class VehicleType
    {
        public int Id { get; set; }

        [Display(Name = "Tipo de vehículo")]
        [MaxLength(20, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; }
    }
}
