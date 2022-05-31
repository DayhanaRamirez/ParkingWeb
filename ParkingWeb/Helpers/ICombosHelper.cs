using Microsoft.AspNetCore.Mvc.Rendering;

namespace ParkingWeb.Helpers
{
    public interface ICombosHelper
    {
        Task<IEnumerable<SelectListItem>> GetComboCampusesAsync();

        Task<IEnumerable<SelectListItem>> GetComboParkingLotsAsync(int countryId);

        Task<IEnumerable<SelectListItem>> GetComboParkingCellsAsync(int stateId);

        Task<IEnumerable<SelectListItem>> GetComboVehicleTypesAsync();

        Task<IEnumerable<SelectListItem>> GetComboVehiclesAsync(string userId);
    }

}
