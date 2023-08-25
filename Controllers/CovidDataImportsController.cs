using CoronaStatsAustria.DataAccess;
using CoronaStatsAustria.Mappers;
using CoronaStatsAustria.Models;
using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace CoronaStatsAustria.Controllers
{
    [ApiController]
    [Route("api")]
    public class CovidDataImportsController : ControllerBase
    {
        private readonly CovidDataContext context;
        private readonly string url = "https://github.com/asjadnaqvi/COVID19-European-Regional-Tracker/blob/master/01_raw/Austria/CovidFaelle_GKZ.csv";

        public CovidDataImportsController(CovidDataContext context)
        {
            this.context = context;
        }

        [HttpPost("importData")]
        public async Task<IActionResult> ImportCSV()
        {
            
        }
    }
}
