using System.ComponentModel.DataAnnotations;

namespace ParkingWeb.Data.Entities
{
    public class ParkingCell
    {
        public int Id { get; set; }

        [Display(Name = "Celda de parqueo")]
        [MaxLength(30, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; }

        public ParkingLot ParkingLot { get; set; }

        public Vehicle? Vehicle { get; set; }  

        public bool IsOccupied { get; set; } = false;

        public VehicleType VehicleType { get; set; }
    }
}
