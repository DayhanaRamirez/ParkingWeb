using System.ComponentModel.DataAnnotations;

namespace ParkingWeb.Data.Entities
{
    public class Campus
    {
        public int Id { get; set; }

        [Display(Name ="Campus")]
        [MaxLength(30, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; }

        [Display(Name = "Dirección")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Addres { get; set; }

        public ICollection<ParkingLot> ParkingLots { get; set; }

        [Display(Name = "Tipos de parqueaderos")]
        public int ParkingLotsNumber => ParkingLots == null ? 0: ParkingLots.Count;
    }
}
