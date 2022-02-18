using Microsoft.AspNetCore.Mvc;
using DataVisualizationAPI.Models;
using DataVisualizationAPI.Services;

namespace DataVisualizationAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FmrController : ControllerBase
    {
        FmrService _service;

        public FmrController(FmrService service)
        {
            _service = service;
        }

        [HttpGet("{id:int}")]
        public ActionResult<FairMarketRent> Get(int id)
        {
            var fmr = _service.GetById(id);

            if (fmr == null)
                return NotFound();

            return fmr;
        }

        [HttpGet("areanames/{state}")]
        public ActionResult<List<string>> Get(string state)
        {
            var fmrs = _service.GetAreanames(state);

            if (fmrs == null)
                return NotFound();

            return fmrs.Select(f => f.Areaname).Distinct().ToList();
        }

        [HttpGet("search/{areaname}/{year:int}")]
        public ActionResult<IEnumerable<FairMarketRent>> Get(string areaname, short year)
        {
            var fmrs = _service.GetFairMarketRents(areaname, year);

            if (fmrs == null)
                return NotFound();

            return fmrs.ToList();
        }
    }
}

