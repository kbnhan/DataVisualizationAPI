using DataVisualizationAPI.Models;
using DataVisualizationAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace DataVisualizationAPI.Services
{
    public class FmrService
    {
        private readonly DataViz_ProjectContext _context;

        public FmrService(DataViz_ProjectContext context)
        {
            _context = context;
        }

        public FairMarketRent? GetById(int id)
        {
            return _context.FairMarketRents
                .AsNoTracking()
                .Single(f => f.Id == id);
        }

        public IQueryable<FairMarketRent> GetAreanames(string state)
        {
            return _context.FairMarketRents
                .AsNoTracking()
                .Where(f => f.State == state);
        }

        public IQueryable<FairMarketRent> GetFairMarketRents(string areaname, short year)
        {
            return _context.FairMarketRents
                .AsNoTracking()
                .Where
                (
                    f => f.Areaname == areaname 
                    && f.Year == year
                );
        }

        public IQueryable<FairMarketRent> GetFairMarketRents(string areaname, short startYear, short endYear)
        {
            return _context.FairMarketRents
                .AsNoTracking()
                .Where
                (
                    f => f.Areaname == areaname
                    && f.Year >= startYear
                    && f.Year <= endYear
                );
        }
    }
}