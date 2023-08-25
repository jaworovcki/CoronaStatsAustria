using CoronaStatsAustria.DataAccess;
using CoronaStatsAustria.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace CoronaStatsAustria.Controllers
{
    [ApiController]
    [Route("api/federalStates")]
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
    }
}
