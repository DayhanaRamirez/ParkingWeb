using System.ComponentModel.DataAnnotations;

namespace ParkingWeb.Models
{
    public class ParkingCellViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Celda de parqueo")]
        [MaxLength(30, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]

        public string Name { get; set; }

        public int ParkingLotId { get; set; }

    }
}
