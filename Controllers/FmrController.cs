using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DataVisualizationAPI
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

        [HttpGet("{id}")]
        public ActionResult<FairMarketRent> Get(int id)
        {
            var fmr = _context.FairMarketRents
            .Single(f => f.Id == id);

            if (fmr == null)
                return NotFound();

            return fmr;
        }
    }
}

