using FilmNet.Data;
using FilmNet.Data.Service;
using FilmNet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FilmNet.Controllers
{
    public class FilmsController(IFilmsService filmsService): Controller
    {
        public async Task<IActionResult> Index()
        {
            var films = await filmsService.GetAllFilmsAsync();
            return View(films);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Film film)
        {
            if (ModelState.IsValid)
            {
                await filmsService.AddFilmAsync(film);
                return RedirectToAction("Index");
            }
            return View(film);
        }
    }
}
