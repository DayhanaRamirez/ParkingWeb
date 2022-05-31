using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParkingWeb.Data;
using ParkingWeb.Data.Entities;
using ParkingWeb.Helpers;
using Microsoft.AspNetCore.Identity;

namespace ParkingWeb.Controllers
{
    public class VehicleController : Controller
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;
        private readonly ICombosHelper _combosHelper;

        public VehicleController(DataContext context, IUserHelper userHelper, ICombosHelper combosHelper)
        {
            _context = context;
            _userHelper = userHelper;
            _combosHelper = combosHelper;
        }

        public async Task<IActionResult> Index()
        {
            var userId = User.Identity.Name;
            User user = await _context.Users.FindAsync(userId);
            return View(user);
        }

    }
}

//Campus campus = await _context.Campuses.Include(c => c.ParkingLots).ThenInclude(p => p.ParkingCells).FirstOrDefaultAsync(m => m.Id == id);



//User user = await _userHelper.GetUserAsync(User.Identity.Name);
//if (user == null)
//{
//    return NotFound();
//}