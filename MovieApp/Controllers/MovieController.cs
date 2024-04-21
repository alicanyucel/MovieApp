using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApp.DataAccess;
using MovieApp.Models;

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
        [HttpPost]
        public async Task<int> Like([FromBody] LikeDislLikeModel model)
        {
            var film = await _dataContext.Movies.FindAsync(model.FilmId);
            if(model.IsLike)
            {
                film.LikeCount++;
            }
            else
            {
                film.DisLikeCountTotal++;
            }
            await _dataContext.SaveChangesAsync();
            return model.IsLike ? film.LikeCount : film.DisLikeCountTotal;
        }
    }
}
