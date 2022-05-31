#nullable disable
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParkingWeb.Data;
using ParkingWeb.Data.Entities;
using ParkingWeb.Models;

namespace ParkingWeb.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CampusesController : Controller
    {
        private readonly DataContext _context;

        public CampusesController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Campuses.Include(c => c.ParkingLots).ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Campus campus = await _context.Campuses.Include(c => c.ParkingLots).ThenInclude(p => p.ParkingCells).FirstOrDefaultAsync(m => m.Id == id);
            if (campus == null)
            {
                return NotFound();
            }

            return View(campus);
        }

        public async Task<IActionResult> DetailsParkingLot(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ParkingLot parkingLot = await _context.ParkingLots.Include(p => p.Campus).Include(p => p.ParkingCells).FirstOrDefaultAsync(m => m.Id == id);
            if (parkingLot == null)
            {
                return NotFound();
            }

            return View(parkingLot);
        }

        public async Task<IActionResult> DetailsParkingCell(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ParkingCell parkingCell = await _context.ParkingCells.Include(p => p.ParkingLot).FirstOrDefaultAsync(p => p.Id == id);
            if (parkingCell == null)
            {
                return NotFound();
            }

            return View(parkingCell);
        }

        public IActionResult Create()
        {
            Campus campus = new()
            {
                ParkingLots = new List<ParkingLot>()
            };
            return View(campus);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Campus campus)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(campus);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe un campus con el mismo nombre.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }
            return View(campus);
        }

        public async Task<IActionResult> AddParkingLot(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Campus campus = await _context.Campuses.FindAsync(id);
            if (campus == null)
            {
                return NotFound();
            }

            ParkingLotViewModel model = new()
            {
                CampusId = campus.Id,
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddParkingLot(ParkingLotViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ParkingLot parkingLot = new()
                    {
                        ParkingCells = new List<ParkingCell>(),
                        Campus = await _context.Campuses.FindAsync(model.CampusId),
                        Name = model.Name,
                    };
                    _context.Add(parkingLot);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Details), new { Id = model.CampusId });
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe un tipo de parqueadero con el mismo nombre.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }
            return View(model);
        }

        public async Task<IActionResult> AddParkingCell(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ParkingLot parkingLot = await _context.ParkingLots.FindAsync(id);
            if (parkingLot == null)
            {
                return NotFound();
            }

            ParkingCellViewModel model = new()
            {
                ParkingLotId = parkingLot.Id,
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddParkingCell(ParkingCellViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ParkingCell parkingCell = new()
                    {
                        ParkingLot = await _context.ParkingLots.FindAsync(model.ParkingLotId),
                        Name = model.Name,
                    };
                    _context.Add(parkingCell);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(DetailsParkingLot), new { Id = model.ParkingLotId });
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe una celda de parqueo con el mismo nombre.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Campus campus = await _context.Campuses.Include(c => c.ParkingLots).FirstOrDefaultAsync(c => c.Id == id);
            if (campus == null)
            {
                return NotFound();
            }
            return View(campus);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Campus campus)
        {
            if (id != campus.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(campus);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe un campus con el mismo nombre.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }
            return View(campus);
        }

        public async Task<IActionResult> EditParkingLot(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ParkingLot parkingLot = await _context.ParkingLots.Include(p => p.Campus).FirstOrDefaultAsync(p => p.Id == id);
            if (parkingLot == null)
            {
                return NotFound();
            }

            ParkingLotViewModel model = new()
            {
                CampusId = parkingLot.Campus.Id,
                Id = parkingLot.Id,
                Name = parkingLot.Name,

            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditParkingLot(int id, ParkingLotViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    ParkingLot parkingLot = new()
                    {
                        Id = model.Id,
                        Name = model.Name,

                    };
                    _context.Update(parkingLot);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Details), new { Id = model.CampusId });
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe un tipo de parqueadero con el mismo nombre.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }
            return View(model);
        }

        public async Task<IActionResult> EditParkingCell(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ParkingCell parkingCell = await _context.ParkingCells.Include(p => p.ParkingLot).FirstOrDefaultAsync(p => p.Id == id);
            if (parkingCell == null)
            {
                return NotFound();
            }

            ParkingCellViewModel model = new()
            {
                ParkingLotId = parkingCell.ParkingLot.Id,
                Id = parkingCell.Id,
                Name = parkingCell.Name,

            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditParkingCell(int id, ParkingCellViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    ParkingCell parkingCell = new()
                    {
                        Id = model.Id,
                        Name = model.Name,
                    };
                    _context.Update(parkingCell);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(DetailsParkingLot), new { Id = model.ParkingLotId });
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe una celda de parqueo con el mismo nombre.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Campus campus = await _context.Campuses.Include(c => c.ParkingLots).FirstOrDefaultAsync(c => c.Id == id);
            if (campus == null)
            {
                return NotFound();
            }

            return View(campus);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Campus campus = await _context.Campuses.FindAsync(id);
            _context.Campuses.Remove(campus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeleteParkingLot(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ParkingLot parkingLot = await _context.ParkingLots.Include(p => p.Campus).FirstOrDefaultAsync(p => p.Id == id);
            if (parkingLot == null)
            {
                return NotFound();
            }

            return View(parkingLot);
        }

        [HttpPost, ActionName("DeleteParkingLot")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteParkingLotConfirmed(int id)
        {
            ParkingLot parkingLot = await _context.ParkingLots.Include(p => p.Campus).FirstOrDefaultAsync(p => p.Id == id);
            _context.ParkingLots.Remove(parkingLot);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Details), new { Id = parkingLot.Campus.Id });
        }

        public async Task<IActionResult> DeleteParkingCell(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ParkingCell parkingCell = await _context.ParkingCells.Include(p => p.ParkingLot).FirstOrDefaultAsync(p => p.Id == id);
            if (parkingCell == null)
            {
                return NotFound();
            }

            return View(parkingCell);
        }

        [HttpPost, ActionName("DeleteParkingCell")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteParkingCellConfirmed(int id)
        {
            ParkingCell parkingCell = await _context.ParkingCells.Include(p => p.ParkingLot).FirstOrDefaultAsync(p => p.Id == id);
            _context.ParkingCells.Remove(parkingCell);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(DetailsParkingLot), new { Id = parkingCell.ParkingLot.Id });
        }
    }
}
