using InterestRateCalculator.Domain.Models;
using InterestRateCalculator.Domain.Repositories;
using InterestRateCalculator.Domain.Services;
using InterestRateCalculator.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace InterestRateCalculator.WebApp.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class InterestCalculatorController : ControllerBase
    {
        protected readonly IInterestCalculatorService interestCalculatorService;
        protected readonly IRepository<CalculationSession> calculationSessionRepository;

        public InterestCalculatorController(IInterestCalculatorService interestCalculator,
            IRepository<CalculationSession> calculationSessionRepository)
        {
            this.interestCalculatorService = interestCalculator;
            this.calculationSessionRepository = calculationSessionRepository;
        }

        [HttpGet]
        public CalculationSessionsListViewModel Get(int page = 0, int itemCount = 10)
        {
            return new CalculationSessionsListViewModel { 
                Count = this.calculationSessionRepository.Count(),
                Sessions = this.calculationSessionRepository.Get(page, itemCount) 
            };
        }

        [HttpGet("GetById/{id}")]
        public CalculationSession GetById(Guid id)
        {
            return this.calculationSessionRepository.Get(id);
        }

        [HttpPost]
        public CalculationSession Post([FromBody] SessionSaveViewModel session)
        {
            var rVal = this.interestCalculatorService.SaveCalculationSession(session.Value, session.Years, session.Results);

            return rVal;
        }
    }
}
