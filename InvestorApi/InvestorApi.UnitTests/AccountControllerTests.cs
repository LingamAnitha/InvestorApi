using System;
using Xunit; 
using Investor.Api.Repository;
using Moq;
using Investor.Api.Controllers;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Investor.Api.Model;

namespace InvestorApi.UnitTests
{
    public class AccountControllerTests
    {
         private readonly Mock<InMemRepository> repositoryStub = new();
        [Fact]
        public void GetCurrentInvestsentsByAmount()
        {
           var repositsoryStub=new Mock<InMemRepository>();
           repositsoryStub.Setup(repo => repo.GetCurrInvesByAmt(It.IsAny<decimal>()));
           var controller= new AccountController(repositsoryStub.Object);
           var result = controller.GetCurrentInvestsentsByAmount(100);   
           Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void GetCurrInvesByInst()
        {
           var repositsoryStub=new Mock<InMemRepository>();
           repositsoryStub.Setup(repo => repo.GetCurrInvesByInst(It.IsAny<Constants.Institution>()));
           var controller= new AccountController(repositsoryStub.Object);
           var result = controller.GetCurrentInvestsentsByInstitution(Constants.Institution.Google);   
           Assert.IsType<NotFoundResult>(result);
        }

         [Fact]
        public void GetCurrInvesByCurency()
        {
           var repositsoryStub=new Mock<InMemRepository>();
           repositsoryStub.Setup(repo => repo.GetCurrInvesByCurency(It.IsAny<Constants.Currency>()));
           var controller= new AccountController(repositsoryStub.Object);
           var result = controller.GetCurrentInvestsentsByCurrency(Constants.Currency.EURO);   
           Assert.IsType<NotFoundResult>(result);
        }
    }
}
