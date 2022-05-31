using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ParkingWeb.Data;

namespace ParkingWeb.Helpers
{
    public class CombosHelper : ICombosHelper
    {
        private readonly DataContext _context;

        public CombosHelper(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SelectListItem>> GetComboVehicleTypesAsync()
        {
            List<SelectListItem> list = await _context.VehicleTypes.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = $"{x.Id}"
            })
                .OrderBy(x => x.Text)
                .ToListAsync();

            list.Insert(0, new SelectListItem
            {
                Text = "[Seleccione una tipo...]",
                Value = "0"
            });

            return list;
        }


        public async Task<IEnumerable<SelectListItem>> GetComboCampusesAsync()
        {
            List<SelectListItem> list = await _context.Campuses.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = $"{x.Id}"
            })
                .OrderBy(x => x.Text)
                .ToListAsync();

            list.Insert(0, new SelectListItem
            {
                Text = "[Seleccione un campus...]",
                Value = "0"
            });

            return list;
        }

        public async Task<IEnumerable<SelectListItem>> GetComboParkingLotsAsync(int campusId)
        {
            List<SelectListItem> list = await _context.ParkingLots
                .Where(x => x.Campus.Id == campusId)
                .Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = $"{x.Id}"
                })
                .OrderBy(x => x.Text)
                .ToListAsync();

            list.Insert(0, new SelectListItem
            {
                Text = "[Seleccione un parqueadero...]",
                Value = "0"
            });

            return list;
        }

        public async Task<IEnumerable<SelectListItem>> GetComboParkingCellsAsync(int parkingLotId)
        {
            List<SelectListItem> list = await _context.ParkingCells
                .Where(x => x.ParkingLot.Id == parkingLotId)
                .Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = $"{x.Id}"
                })
                .OrderBy(x => x.Text)
                .ToListAsync();

            list.Insert(0, new SelectListItem
            {
                Text = "[Seleccione una celda...]",
                Value = "0"
            });

            return list;
        }

        public async Task<IEnumerable<SelectListItem>> GetComboVehiclesAsync(string userId)
        {
            List<SelectListItem> list = await _context.Vehicles
                .Where(x => x.User.Id == userId)
                .Select(x => new SelectListItem
                {
                    Text = x.LicensePlate,
                    Value = $"{x.Id}"
                })
                .OrderBy(x => x.Text)
                .ToListAsync();

            list.Insert(0, new SelectListItem
            {
                Text = "[Seleccione un vehículo...]",
                Value = "0"
            });

            return list;
        }
    }
}
