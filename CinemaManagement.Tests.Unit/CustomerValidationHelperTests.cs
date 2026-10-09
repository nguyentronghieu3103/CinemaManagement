using CinemaManagement.Common.Helpers;

namespace CinemaManagement.Tests.Unit;

public class CustomerValidationHelperTests
{
    [Theory]
    [InlineData("0901234567")]
    [InlineData("090 123 4567")]
    [InlineData("090.123.4567")]
    [InlineData("+84901234567")]
    public void IsValidPhone_AcceptsVietnamesePhoneNumbers(string phone)
    {
        Assert.True(CustomerValidationHelper.IsValidPhone(phone));
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("901234567")]        // thiếu số 0 đầu
    [InlineData("090123456")]        // 9 số
    [InlineData("09012345678")]      // 11 số
    [InlineData("09012345ab")]
    public void IsValidPhone_RejectsInvalidPhoneNumbers(string? phone)
    {
        Assert.False(CustomerValidationHelper.IsValidPhone(phone));
    }

    [Fact]
    public void NormalizePhone_StripsSeparatorsAndConvertsPlus84()
    {
        Assert.Equal("0901234567", CustomerValidationHelper.NormalizePhone(" 090-123 4567 "));
        Assert.Equal("0901234567", CustomerValidationHelper.NormalizePhone("+84901234567"));
    }

    [Theory]
    [InlineData(null, true)]
    [InlineData("", true)]
    [InlineData("a@b.com", true)]
    [InlineData("khach hang@b.com", false)]
    [InlineData("khong-phai-email", false)]
    [InlineData("a@b", false)]
    public void IsValidOptionalEmail_EmptyIsOk_OtherwiseMustBeWellFormed(string? email, bool expected)
    {
        Assert.Equal(expected, CustomerValidationHelper.IsValidOptionalEmail(email));
    }

    [Fact]
    public void NormalizeName_CollapsesWhitespace()
    {
        Assert.Equal("Nguyễn Văn A", CustomerValidationHelper.NormalizeName("  Nguyễn   Văn  A "));
    }
}
