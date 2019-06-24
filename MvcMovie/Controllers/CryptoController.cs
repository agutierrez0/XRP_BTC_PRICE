using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Data.Models;
using MvcMovie.Models;
using Nancy.Json;

namespace MvcMovie.Controllers
{
    public class CryptoController : Controller
    {
        private readonly MvcMovieContext _context;
        private readonly CardealershipContext _carDealershipContext;

        public CryptoController(CardealershipContext context)
        {
            _carDealershipContext = context;
        }
        /*
        // GET: Movies
        public async Task<IActionResult> Index()
        {
            return View(await _context.Movie.ToListAsync());
        }
        */
        public async Task<IActionResult> Index()
        {
            List<CryptonatorClass> listOfCryptos = new List<CryptonatorClass>();

            /*
            string baseURL = "https://api.cryptonator.com/api/ticker/btc-usd";
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage res = await client.GetAsync(baseURL))
            using (HttpContent content = res.Content)
            {
                var entity = await content.ReadAsStringAsync();

                JavaScriptSerializer serializer = new JavaScriptSerializer();
                var entity2 = serializer.Deserialize<CryptonatorClass>(entity);

                listOfCryptos.Add(entity2);
            }

            
            string baseURL2 = "https://api.cryptonator.com/api/ticker/xrp-usd";
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage res = await client.GetAsync(baseURL2))
            using (HttpContent content = res.Content)
            {
                var entity = await content.ReadAsStringAsync();

                JavaScriptSerializer serializer = new JavaScriptSerializer();
                var entity2 = serializer.Deserialize<CryptonatorClass>(entity);

                listOfCryptos.Add(entity2);
            }
            */
            return View(listOfCryptos);

        }

        // GET: Movies/Details/5
        public async Task<IActionResult> BTCPrice()
        {
            List<CryptonatorClass> listOfCryptos = new List<CryptonatorClass>();

            string baseURL = "https://api.cryptonator.com/api/ticker/btc-usd";
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage res = await client.GetAsync(baseURL))
            using (HttpContent content = res.Content)
            {
                var entity = await content.ReadAsStringAsync();

                JavaScriptSerializer serializer = new JavaScriptSerializer();
                var entity2 = serializer.Deserialize<CryptonatorClass>(entity);

                listOfCryptos.Add(entity2);
            }

            return View(listOfCryptos);
        }

        public async Task<IActionResult> XRPPrice()
        {
            List<CryptonatorClass> listOfCryptos = new List<CryptonatorClass>();

            string baseURL = "https://api.cryptonator.com/api/ticker/xrp-usd";
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage res = await client.GetAsync(baseURL))
            using (HttpContent content = res.Content)
            {
                var entity = await content.ReadAsStringAsync();

                JavaScriptSerializer serializer = new JavaScriptSerializer();
                var entity2 = serializer.Deserialize<CryptonatorClass>(entity);

                listOfCryptos.Add(entity2);
            }

            return View(listOfCryptos);
        }

        public async Task<IActionResult> Cars()
        {
            /*
            ServicePointManager.ServerCertificateValidationCallback += (o, c, ch, er) => true;

            List<Car> listOfCryptos = new List<Car>();

            string baseURL = "http://localhost:61104/cars";
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage res = await client.GetAsync(baseURL))
            using (HttpContent content = res.Content)
            {
                var entity = await content.ReadAsStringAsync();

                JavaScriptSerializer serializer = new JavaScriptSerializer();
                var entity2 = serializer.Deserialize<Car>(entity);

                listOfCryptos.Add(entity2);
            }

            return View(listOfCryptos);
            */
            return View(await _carDealershipContext.Cars.ToListAsync());
        }


        // GET: Movies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,ReleaseDate,Genre,Price")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,ReleaseDate,Genre,Price")] Movie movie)
        {
            if (id != movie.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.ID))
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
            return View(movie);
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie
                .FirstOrDefaultAsync(m => m.ID == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _context.Movie.FindAsync(id);
            _context.Movie.Remove(movie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
            return _context.Movie.Any(e => e.ID == id);
        }
    }
}
