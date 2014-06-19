
namespace CinemaBookingSystem
{
    interface ICinemaList
    {
        void Add(Movie movie);
        void Remove(int index);
        void RemoveRange(int start, int end);
        Movie FindMovie(string name);
    }
}
