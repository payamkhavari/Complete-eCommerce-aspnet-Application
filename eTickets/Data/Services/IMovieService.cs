using eTickets.Models;

namespace eTickets.Data.Services
{
    public interface IMovieService
    {
        Movie GetMovie(int id);
        List<Movie> GetMovies();
        Movie Update(Movie movie);
    }
}
