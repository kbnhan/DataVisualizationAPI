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
    }
}