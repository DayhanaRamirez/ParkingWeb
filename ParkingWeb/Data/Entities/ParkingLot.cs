using System.ComponentModel.DataAnnotations;

namespace ParkingWeb.Data.Entities
{
    public class ParkingLot
    {
        public int Id { get; set; }

        [Display(Name = "Tipo de parqueadero")]
        [MaxLength(30, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; }

        public Campus Campus { get; set; }

        public ICollection<ParkingCell> ParkingCells { get; set; }

        [Display(Name = "Celdas de parqueo")]
        public int ParkingCellsNumber => ParkingCells == null ? 0 : ParkingCells.Count;

        public VehicleType VehicleType { get; set; }

        public ICollection<ParkingLotRestriction> ParkingLotRestrictions { get; set; }
    }
}
