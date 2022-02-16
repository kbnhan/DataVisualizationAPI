using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataVisualizationAPI.Models;
using DataVisualizationAPI.Data;

namespace DataVisualizationAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FmrController : ControllerBase
    {
        DataViz_ProjectContext _context;

        public FmrController(DataViz_ProjectContext context)
        {
            _context = context;
        }

        [HttpGet("{id:int}")]
        public ActionResult<FairMarketRent> Get(int id)
        {
            var fmr = _context.FairMarketRents
            .AsNoTracking()
            .Single(f => f.Id == id);

            if (fmr == null)
                return NotFound();

            return fmr;
        }

        [HttpGet("areanames/{state}")]
        public ActionResult<List<string>> Get(string state)
        {
            var fmrs = _context.FairMarketRents
            .AsNoTracking()
            .Where(f => f.State == state);

            if (fmrs == null)
                return NotFound();

            return fmrs.Select(f => f.Areaname).Distinct().ToList();
        }
    }
}

