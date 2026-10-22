using Øvelse_7._1;

namespace Gavebeskatning.Tests;

public class GiftTaxCalculatorTests
{
    [Theory]
    [InlineData(500, 900, 0)]
    [InlineData(500, 901, 901)]
    [InlineData(1000, 500, 500)]
    [InlineData(1001, 500, 1501)]
    [InlineData(0, 1401, 1401)]
    public void CalculateTaxableAmount_ReturnsExpectedAmount(
        decimal christmasGift,
        decimal otherGifts,
        decimal expectedAmount)
    {
        var result = GiftTaxCalculator.CalculateTaxableAmount(christmasGift, otherGifts);

        Assert.Equal(expectedAmount, result);
    }

    [Theory]
    [InlineData(-1, 0)]
    [InlineData(0, -1)]
    public void CalculateTaxableAmount_ThrowsForNegativeAmounts(decimal christmasGift, decimal otherGifts)
    {
        Assert.Throws<ArgumentOutOfRangeException>(
            () => GiftTaxCalculator.CalculateTaxableAmount(christmasGift, otherGifts));

    }
}
