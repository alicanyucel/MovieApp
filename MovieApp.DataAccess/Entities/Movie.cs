using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace MovieApp.DataAccess.Entities
{
    public class Movie
    {
        public int Id {  get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public string? ImageUrl { get; set; }
        public int LikeCount { get; set; }
        public int DisLikeCountTotal { get; set; }
    }
}
