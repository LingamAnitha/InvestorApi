using System;
using System.Collections.Generic;

namespace Investor.Api.Model
{
    public class Account
    {
          public Guid AccountNumber { get; set;}      
          public decimal Deposit {get; set;}

          public decimal Balance {get;}

          public List<Investment> Investments {get; set;}          
    }

    public class Investment
    {
          public Guid InvestmentId { get; set;}

          public Constants.Institution Institution {get; set;}    

          public Constants.Currency Currency {get; set;}
          
          public decimal InvestmentAmount {get; set;}          
    }
}