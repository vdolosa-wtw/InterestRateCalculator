using InterestRateCalculator.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterestRateCalculator.WebApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CalculateInterestController : ControllerBase
    {
        protected IInterestCalculator interestCalculator;

        public CalculateInterestController(IInterestCalculator interestCalculator)
        {
            this.interestCalculator = interestCalculator;
        }

        /// <summary>
        /// Calculate and get the result
        /// </summary>
        /// <param name="value">The base value/amount</param>
        /// <param name="years">The maturity years</param>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<CalculationResult> Get(decimal value, int years)
        {
            return this.interestCalculator.Calculate(value, years);
        }
    }
}
