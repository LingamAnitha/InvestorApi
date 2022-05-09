using System;
using System.Collections;
using System.Collections.Generic;
using Investor.Api.Model;
using System.Linq;

namespace Investor.Api.Repository
{
    public class InMemRepository
    {
      private  List<Account> accounts = new List<Account>();     

     public void CreateAccount(Account account)
     {
       try
       {
      List<Investment> investments = new List<Investment>();
         foreach(Investment ins in account.Investments) 
          {
                Investment investment = new ()
                {
                   InvestmentId = Guid.NewGuid(),
                   Institution = ins.Institution,
                   Currency = ins.Currency,
                   InvestmentAmount =ins.InvestmentAmount
                };
                investments.Add(investment);
          }

       Account newAccount = new()
       {    
           AccountNumber = Guid.NewGuid(),
           Deposit = account.Deposit,
           Investments = account.Investments,                  
       };
       accounts.Add(newAccount);
       }
       catch(Exception ex)
       {

       }
     }

     public void Invest(Account account)
     {
       try
       {
      List<Investment> investments = new List<Investment>();
         foreach(Investment ins in account.Investments) 
          {
                Investment investment = new ()
                {
                   InvestmentId = Guid.NewGuid(),
                   Institution = ins.Institution,
                   Currency = ins.Currency,
                   InvestmentAmount =ins.InvestmentAmount
                };
                investments.Add(investment);
          }

       Account newAccount = new()
       {    
           AccountNumber = Guid.NewGuid(),
           Deposit = account.Deposit,
           Investments = account.Investments,        
       };
       accounts.Add(newAccount);
       }
       catch(Exception ex)
       {

       }
     }
      public decimal GetCurrentBalance(Guid accountNumber)
      {
        try
        {
          Account acct = accounts.Where(item => item.AccountNumber == accountNumber && item.Investments.Any(x => x.InvestmentAmount != 0 )).FirstOrDefault();
          decimal balance = 0;
          
          foreach(Investment ins in acct.Investments)
          {
            balance = balance + ins.InvestmentAmount;
          }
           return acct.Deposit - balance;         
        }
        catch(Exception ex) 
        {
          return 0;
        }
      }   

      public List<Account> GetCurrInvesByInst(Constants.Institution institutionName)
      {     
        try
        {   
          return  accounts.Where(item => item.Investments.Any(y => y.Institution == institutionName)).ToList();                  
        }
        catch (Exception ex)     
        {
              return null;
        }          
      } 
      public List<Account> GetCurrInvesByCurency(Constants.Currency currency)
      {
        try
        {
          return  accounts.Where(item => item.Investments.Any(y => y.Currency == currency)).ToList();     
        }
        catch(Exception ex)        
        {
          return null;
        }                    
      } 
      public List<Account> GetCurrInvesByAmt(decimal amount)
      {
        try
        {
         return  accounts.Where(item => item.Investments.Any(y => y.InvestmentAmount == amount)).ToList();  
        }
        catch(Exception ex)       
        {
            return null;
        }                        
      } 
    }
}