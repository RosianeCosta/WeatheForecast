using Weather.Domain;
using System.Threading.Tasks;

namespace Weather.Repository
{
    public interface IWeatherRepository
    {
        void Add<T>(T entity) where T : class;

        void Update<T>(T entity) where T : class;

        void Delete<T>(T entity) where T : class;

        Task<bool> SaveChangesAsync();

        //Get Cities from Sqlite
        Task<Cities[]> GetAllCitiesAsync();
        Task<Cities> GetCityAsync(int cityId);
    }
}