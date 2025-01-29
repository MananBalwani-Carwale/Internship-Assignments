using Moq;
using FluentAssertions;
using BusinessAccessLayer.Service;
using DataAccessLayer.Repository;
using System.Runtime.InteropServices.Marshalling;
namespace BusinessAccessLayer.Tests;

public class StockServiceTests
{
    private readonly Mock<IStockRepository> _stockStub;
    public StockServiceTests()
    {
        _stockStub = new Mock<IStockRepository>();
    }
    [Fact]
    public void IsValueForMoney_WithAllConditionsSatisfied_ReturnsTrue()
    {
        //Assign
        int kms = 9999;
        int price = 190000;
        IStockService stockService = new StockService(_stockStub.Object);
        //Act
        bool isValueForMoney = stockService.GetIsValueForMoney(kms,price);
        //Assert
        isValueForMoney.Should().Be(true);
    }
    [Fact]
    public void IsValueForMoney_WithAllConditionsUnSatisfied_ReturnsFalse()
    {
        //Assign
        int kms = 100000;
        int price = 2100000;
        IStockService stockService = new StockService(_stockStub.Object);
        //Act
        bool isValueForMoney = stockService.GetIsValueForMoney(kms,price);
        //Assert
        isValueForMoney.Should().Be(false);
    }
    [Fact]
    public void IsValueForMoney_WithKmsConditionUnSatisfied_ReturnsFalse()
    {
        //Assign
        int kms = 100000;
        int price = 150000;
        IStockService stockService = new StockService(_stockStub.Object);
        //Act
        bool isValueForMoney = stockService.GetIsValueForMoney(kms,price);
        //Assert
        isValueForMoney.Should().Be(false);
    }
    [Fact]
    public void IsValueForMoney_WithPriceConditionUnSatisfied_ReturnsFalse()
    {
        //Assign
        int kms = 9000;
        int price = 2100000;
        IStockService stockService = new StockService(_stockStub.Object);
        //Act
        bool isValueForMoney = stockService.GetIsValueForMoney(kms,price);
        //Assert
        isValueForMoney.Should().Be(false);
    }
}
