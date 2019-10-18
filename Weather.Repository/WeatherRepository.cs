using System.Linq;
using Weather.Domain;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Weather.Repository
{
    public class WeatherRepository : IWeatherRepository
    {
        private readonly WeatherContext _context;
        public WeatherRepository(WeatherContext context)
        {
            _context = context;
            //No tracker = Não ser mudança rastreada para não travar recurso no EntityFramework 
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<Cities[]> GetAllCitiesAsync()
        {
            IQueryable<Cities> query = _context.Cities.OrderBy(x => x.Name);

            return await query.ToArrayAsync();
        }

        public async Task<Cities> GetCityAsync(int cityId)
        {
            IQueryable<Cities> query = _context.Cities.Where(x => x.CityId == cityId);

            return await query.FirstOrDefaultAsync();
        }
    }
}