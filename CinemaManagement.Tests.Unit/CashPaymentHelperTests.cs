using CinemaManagement.Common.Helpers;

namespace CinemaManagement.Tests.Unit;

public class CashPaymentHelperTests
{
    [Theory]
    [InlineData("300000", 300000)]
    [InlineData("300.000", 300000)]
    [InlineData("300,000", 300000)]
    [InlineData(" 1 000 000 ", 1000000)]
    [InlineData("0", 0)]
    public void TryParseAmount_AcceptsPlainAndGroupedNumbers(string text, int expected)
    {
        Assert.True(CashPaymentHelper.TryParseAmount(text, out decimal amount));
        Assert.Equal(expected, amount);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData("abc")]
    [InlineData("-5000")]
    [InlineData("12a34")]
    [InlineData("1234567890123")]   // quá dài
    public void TryParseAmount_RejectsEmptyNegativeAndInvalid(string? text)
    {
        Assert.False(CashPaymentHelper.TryParseAmount(text, out _));
    }

    [Fact]
    public void CalculateChange_ReceivedGreaterThanTotal_ReturnsChange()
    {
        Assert.Equal(60000m, CashPaymentHelper.CalculateChange(240000m, 300000m));
    }

    [Fact]
    public void CalculateChange_ExactAmount_ReturnsZero()
    {
        Assert.Equal(0m, CashPaymentHelper.CalculateChange(240000m, 240000m));
        Assert.True(CashPaymentHelper.IsEnough(240000m, 240000m));
    }

    [Fact]
    public void CalculateChange_Insufficient_IsNegativeAndNotEnough()
    {
        Assert.Equal(-40000m, CashPaymentHelper.CalculateChange(240000m, 200000m));
        Assert.False(CashPaymentHelper.IsEnough(240000m, 200000m));
    }
}
