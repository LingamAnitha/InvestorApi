using Microsoft.AspNetCore.Mvc;
using Investor.Api.Repository;
using System.Collections.Generic;
using Investor.Api.Model;
using System;

namespace Investor.Api.Controllers
{
   [ApiController]
   [Route("[Controller]")]
    public class AccountController : ControllerBase
    { 
      private readonly InMemRepository repository;

      public AccountController(InMemRepository newRepository)
      {
          this.repository = newRepository;
      }      
      
        [HttpPost()]
        [Route("CreateAccount")]
        public void CreateAccount(Account account)
        {
          repository.CreateAccount(account);
        }

       [HttpPost()]
      [Route("Invest")]
        public void Invest(Account account)
        {
          repository.Invest(account);
        }

      [HttpGet()]
      [Route("GetCurrentBalance")]
      public decimal GetCurrentBalance(Guid accountNumber)
      {
        var account = repository.GetCurrentBalance(accountNumber);
        return account;
      }

       [HttpGet()]
      [Route("GetCurrentInvestsentsByInstitution")]
      public List<Account> GetCurrentInvestsentsByInstitution(Constants.Institution institutionName)
      {
        var investments = repository.GetCurrInvesByInst(institutionName);
        return investments;
      }

       [HttpGet()]
       [Route("GetCurrentInvestsentsByCurrency")]
      public List<Account> GetCurrentInvestsentsByCurrency(Constants.Currency currency)
      {
        var investments = repository.GetCurrInvesByCurency(currency);
        return investments;
      }

       [HttpGet()]
      [Route("GetCurrentInvestsentsByAmount")]
      public List<Account> GetCurrentInvestsentsByAmount(decimal amount)
      {
        var investments = repository.GetCurrInvesByAmt(amount);
        return investments;
      }
    }
}