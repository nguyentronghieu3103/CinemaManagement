using CinemaManagement.Common.DTOs.Auth;
using System.Text.RegularExpressions;
using Xunit;

namespace CinemaManagement.Tests.Unit
{
    public class ProfileValidationTests
    {
        [Theory]
        [InlineData(1, "NV000001")]
        [InlineData(42, "NV000042")]
        [InlineData(123456, "NV123456")]
        public void FormattedEmployeeCode_ShouldFormatWithPrefixAndSixDigits(int id, string expected)
        {
            var dto = new UserProfileDto { EmployeeId = id };
            Assert.Equal(expected, dto.FormattedEmployeeCode);
        }

        [Theory]
        [InlineData("0901234567", true)]
        [InlineData("0987654321", true)]
        [InlineData("0123456789", true)]
        [InlineData("090123456", false)] // 9 digits
        [InlineData("09012345678", false)] // 11 digits
        [InlineData("1901234567", false)] // doesn't start with 0
        [InlineData("090123456a", false)] // contains letter
        [InlineData("090-123-456", false)] // contains dashes
        [InlineData("", false)]
        public void PhoneNumber_ValidationRule_ShouldMatchRegex(string phone, bool expectedValid)
        {
            bool isValid = !string.IsNullOrWhiteSpace(phone) && Regex.IsMatch(phone, @"^0\d{9}$");
            Assert.Equal(expectedValid, isValid);
        }

        [Theory]
        [InlineData("Nguyen Van A", true)]
        [InlineData("Thu Ngân Demo", true)]
        [InlineData("", false)]
        [InlineData("   ", false)]
        public void FullName_ValidationRule_ShouldRequireNonEmpty(string name, bool expectedValid)
        {
            bool isValid = !string.IsNullOrWhiteSpace(name) && name.Trim().Length <= 100;
            Assert.Equal(expectedValid, isValid);
        }
    }
}

