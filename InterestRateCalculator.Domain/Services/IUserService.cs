using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestRateCalculator.Domain.Services
{
    public interface IUserService
    {
        public ApplicationUser CurrentUser { get; }
    }
}
