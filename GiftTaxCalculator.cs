namespace Øvelse_7._1;

/// <summary>
/// Regler for gaver og julegaver fra arbejdsgiver i 2026:
/// Hvis den samlede årlige værdi overstiger 1.400 kr., beskattes hele beløbet.
/// Julegaven beskattes dog ikke, hvis den højst koster 1.000 kr., selvom den samlede
/// værdi overstiger 1.400 kr. I så fald beskattes kun værdien af de øvrige gaver.
/// </summary>
public static class GiftTaxCalculator
{
    private const decimal AnnualGiftLimit = 1400m;
    private const decimal ChristmasGiftExemptionLimit = 1000m;

    public static decimal CalculateTaxableAmount(decimal christmasGift, decimal otherGifts)
    {

        if (christmasGift < 0 || otherGifts < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(christmasGift), "Gaveværdier må ikke være negative.");
        }

        var totalGifts = christmasGift + otherGifts;
        if (totalGifts <= AnnualGiftLimit)
        {
            return 0m;
        }

        return christmasGift < ChristmasGiftExemptionLimit
            ? otherGifts
            : totalGifts;
    }
}