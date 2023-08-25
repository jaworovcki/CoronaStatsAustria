using CoronaStatsAustria.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace CoronaStatsAustria.Controllers
{
    [ApiController]
    [Route("api/importData")]
    public class CovidDataImportsController : ControllerBase
    {
        private readonly CovidDataContext context;

        public CovidDataImportsController(CovidDataContext context)
        {
            this.context = context;
        }
    }
}
