using CoronaStatsAustria.DataAccess;
using CoronaStatsAustria.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace CoronaStatsAustria.Controllers
{
    [ApiController]
    [Route("api/states")]
    public class FederalStatesController : ControllerBase
    {
        private readonly CovidDataContext context;

        public FederalStatesController(CovidDataContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<FederalState>> GetAllFederalStates()
        {
            var states = await context.States
                .Include(s => s.Districts)
                .AsNoTracking()
                .ToArrayAsync();

            return states;
        }

        [HttpGet("{id}/cases")]
        public async Task<IEnumerable<CovidStats>> GetCasesByState(int id)
        {
            var state = await context.States
                .Include(s => s.Districts)
                    .ThenInclude(d => d.CovidStatistics)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (state is null)
            {
                return (IEnumerable<CovidStats>)NotFound();
            }

            var cases = state.Districts
                .Select(d => d.CovidStatistics)
                .OrderBy(c => c.DistrictId);

            return cases;
        }
    }
}
