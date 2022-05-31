using System.ComponentModel.DataAnnotations;

namespace ParkingWeb.Models
{
    public class ParkingLotViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Tipo de parqueadero")]
        [MaxLength(30, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; }

        public int CampusId { get; set; }



    }
}
