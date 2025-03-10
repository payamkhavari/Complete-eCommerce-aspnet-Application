using eTickets.Data.Base;
using eTickets.Data.ViewModels;
using eTickets.Models;

namespace eTickets.Data.Services
{
    public interface IMovieService : IEntityBaseRepository<Movie>
    {
        void UpdateMovie(MovieViewModel movie);
        DropDownMovieViewModel GetNewMovieDropdownValues();

        void AddMovie(MovieViewModel movie);

       
    }
}
