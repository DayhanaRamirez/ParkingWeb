using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParkingWeb.Data;
using ParkingWeb.Data.Entities;

namespace ParkingWeb.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RestrictionsController : Controller
    {
        private readonly DataContext _context;

        public RestrictionsController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Restrictions.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Restriction restriction)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(restriction);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe un tipo de vehículo con el mismo nombre.");
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
            return View(restriction);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Restriction restriction = await _context.Restrictions.FindAsync(id);
            if (restriction == null)
            {
                return NotFound();
            }


            return View(restriction);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Restriction restriction)
        {
            if (id != restriction.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(restriction);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe un tipo de restricción con el mismo día.");
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

            return View(restriction);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Restriction restriction = await _context.Restrictions.FindAsync(id);
            if (restriction == null)
            {
                return NotFound();
            }

            return View(restriction);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Restriction restriction = await _context.Restrictions.FindAsync(id);
            if (restriction == null)
            {
                return NotFound();
            }

            return View(restriction);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Restriction restriction = await _context.Restrictions.FindAsync(id);
            _context.Restrictions.Remove(restriction);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }




    }
}
