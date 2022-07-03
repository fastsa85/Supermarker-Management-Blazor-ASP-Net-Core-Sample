using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.TransactionsUseCases.UseCaseInterfaces;

namespace UseCases.UsersUseCases
{
    public class GetCashiersUseCase : IGetCashiersUseCase
    {
        private readonly UserManager<IdentityUser> _userManager;

        public GetCashiersUseCase(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IEnumerable<IdentityUser>> ExecuteAsync()
        {
            var cashiers = await _userManager.GetUsersForClaimAsync(new System.Security.Claims.Claim("Position", "Cashier"));
            return cashiers;
        }
    }
}
