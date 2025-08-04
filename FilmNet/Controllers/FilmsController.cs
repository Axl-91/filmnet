using FilmNet.Data.Service;
using FilmNet.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmNet.Controllers
{
    public class FilmsController(IFilmsService filmsService): Controller
    {
        public async Task<IActionResult> Index()
        {
            var films = await filmsService.GetAllFilmsAsync();
            return View(films);
        }
        
        public async Task<IActionResult> Show(int id)
        {
            var film = await filmsService.GetFilmByIdAsync(id);
            return View(film);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Film film)
        {
            if (ModelState.IsValid)
            {
                await filmsService.AddFilmAsync(film);
                return RedirectToAction("Index");
            }
            return View(film);
        }
        
        // GET: Films/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var film = await filmsService.GetFilmByIdAsync(id);
        
            if (film == null)
            {
                return NotFound();
            }
        
            return View(film);
        }

        // POST: Films/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Film film)
        {
            if (ModelState.IsValid)
            {
                await filmsService.UpdateFilmAsync(film);
                return RedirectToAction("Index");
            }
        
            return View(film);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var film = await filmsService.GetFilmByIdAsync(id);
            if (film == null)
            {
                return NotFound();
            }
            await filmsService.DeleteFilmAsync(film);
            return RedirectToAction("Index");
        }
        
        
    }
}
