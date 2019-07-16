using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Data.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MvcMovie.Controllers
{
    public class CarsController : Controller
    {
        private readonly CardealershipContext _carDealershipContext;

        public CarsController(CardealershipContext context)
        {
            _carDealershipContext = context;
        }

        private bool CarExists(int id)
        {
            return _carDealershipContext.Cars.Any(c => c.Id == id);
        }

        public async Task<IActionResult> Index()
        {
            return View(await _carDealershipContext.Cars.ToListAsync());
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _carDealershipContext.Cars.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }
        // GET: Cars1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Make,Model,Quantity,YearProduced,Price,Luxury")] Car car)
        {
            if (id != car.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _carDealershipContext.Update(car);
                    await _carDealershipContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarExists(car.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(car);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _carDealershipContext.Cars.FirstOrDefaultAsync(c => c.Id == id);
            if(movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _carDealershipContext.Cars.FirstOrDefaultAsync(c => c.Id == id);

            if (car == null)
            {
                return NotFound();
            }

        return View(car);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var car = await _carDealershipContext.Cars.FindAsync(id);
            _carDealershipContext.Cars.Remove(car);
            await _carDealershipContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}