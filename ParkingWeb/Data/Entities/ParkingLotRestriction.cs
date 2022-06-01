namespace ParkingWeb.Data.Entities
{
    public class ParkingLotRestriction
    {

        public int Id { get; set; }

        public ParkingLot ParkingLot { get; set; }

        public Restriction Restriction { get; set; }

    }
}
