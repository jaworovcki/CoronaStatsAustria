﻿using CoronaStatsAustria.DataAccess;
using CoronaStatsAustria.Mappers;
using CoronaStatsAustria.Models;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Net.Http.Headers;

namespace CoronaStatsAustria.Controllers
{
    [ApiController]
    [Route("api")]
    public class CovidDataImportsController : ControllerBase
    {
        private readonly CovidDataContext context;
        private readonly string filePath = "covid19.csv";

        public CovidDataImportsController(CovidDataContext context)
        {
            this.context = context;
        }

        [HttpPost("importData")]
        public async Task<IActionResult> ImportCSV()
        {

            using (var reader = new StreamReader(filePath))
            {
                using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    BadDataFound = null
                }))
                {
                    csv.Context.RegisterClassMap<CovidStatsMap>();
                    var records = await Task.Run(csv.GetRecords<CovidStats>().ToArray);
                    foreach (var record in records)
                    {
                        var district = await context.Districts
                            .FirstOrDefaultAsync(d => d.Code == record.District.Code);

                        if (district is not null)
                        {
                            record.District = district;
                        }
                        else
                        {
                            return StatusCode(500);
                        }
                    }

                    await context.CovidStatistics.AddRangeAsync(records);

                    await context.SaveChangesAsync();
                }
            }

            return Ok("Data successfully imported");
        }

        [HttpGet("states/cases")]
        public async Task<IEnumerable<CovidStats>> GetTotalCases()
        {
            var cases = await context.CovidStatistics
                .AsNoTracking()
                .ToArrayAsync();

            if (cases.Any())
            {
                return cases;
            }
            else
            {
                return (IEnumerable<CovidStats>)NotFound("No cases");
            }
        }
    }
}
