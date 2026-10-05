using CinemaManagement.Common.DTOs.Sales;
using CinemaManagement.Common.Helpers;

namespace CinemaManagement.Tests.Unit;

public class CartPricingHelperTests
{
    private static List<ComboDto> Catalog() => new()
    {
        new ComboDto { ComboId = 1, TenCombo = "Solo", Gia = 60000m },
        new ComboDto { ComboId = 2, TenCombo = "Couple", Gia = 120000m },
        new ComboDto { ComboId = 3, TenCombo = "Family", Gia = 180000m }
    };

    [Fact]
    public void BuildComboLines_ComputesThanhTienFromCatalogPrice()
    {
        var lines = CartPricingHelper.BuildComboLines(Catalog(), new Dictionary<int, int> { [2] = 3 });

        var line = Assert.Single(lines);
        Assert.Equal(2, line.ComboId);
        Assert.Equal(3, line.SoLuong);
        Assert.Equal(120000m, line.DonGia);
        Assert.Equal(360000m, line.ThanhTien);
    }

    [Fact]
    public void BuildComboLines_SkipsZeroNegativeAndUnknownCombos()
    {
        var quantities = new Dictionary<int, int>
        {
            [1] = 0,      // chưa chọn
            [2] = -5,     // số âm không bao giờ vào giỏ
            [99] = 4      // combo không có trong danh sách
        };

        var lines = CartPricingHelper.BuildComboLines(Catalog(), quantities);

        Assert.Empty(lines);
    }

    [Fact]
    public void BuildComboLines_KeepsCatalogOrder()
    {
        var quantities = new Dictionary<int, int> { [3] = 1, [1] = 2 };

        var lines = CartPricingHelper.BuildComboLines(Catalog(), quantities);

        Assert.Equal(new[] { 1, 3 }, lines.Select(l => l.ComboId).ToArray());
    }

    [Fact]
    public void SumComboTotal_AddsAllLines_AndIsZeroWhenEmpty()
    {
        var lines = CartPricingHelper.BuildComboLines(Catalog(), new Dictionary<int, int> { [1] = 1, [3] = 2 });

        Assert.Equal(60000m + 2 * 180000m, CartPricingHelper.SumComboTotal(lines));
        Assert.Equal(0m, CartPricingHelper.SumComboTotal(new List<CartComboItemDto>()));
    }
}
