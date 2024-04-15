using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApp.DataAccess;

namespace MovieApp.Controllers
{
    public class MovieController : Controller
    {
        private readonly DataContext _dataContext;

        public MovieController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<IActionResult> Index()
        {
            var allMovies = await _dataContext.Movies.ToListAsync();

            return View(allMovies);
        }
    }
}
