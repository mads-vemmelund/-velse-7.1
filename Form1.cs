namespace Øvelse_7._1;

public partial class Form1 : Form
{
    private readonly NumericUpDown christmasGiftInput = CreateAmountInput();
    private readonly NumericUpDown otherGiftsInput = CreateAmountInput();
    private readonly Label resultLabel = new()
    {
        AutoSize = true,
        Font = new Font("Segoe UI", 14, FontStyle.Bold),
        Text = "Skattepligtigt beløb: 0,00 kr."
    };
    private readonly Label detailsLabel = new()
    {
        AutoSize = true,
        MaximumSize = new Size(420, 0),
        Text = "Indtast beløbene for at beregne, hvor meget der skal beskattes."
    };

    public Form1()
    {
        InitializeComponent();
        Text = "Beregning af gavebeskatning";
        StartPosition = FormStartPosition.CenterScreen;
        ClientSize = new Size(500, 380);
        MinimumSize = new Size(500, 380);
        Font = new Font("Segoe UI", 10);

        var layout = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            Padding = new Padding(24),
            ColumnCount = 1,
            RowCount = 7,
            AutoSize = false
        };
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 38));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 32));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 42));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 32));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 42));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 54));
        layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));

        var heading = new Label
        {
            AutoSize = true,
            Font = new Font("Segoe UI", 16, FontStyle.Bold),
            Text = "Gavebeskatning 2026"
        };
        var christmasLabel = new Label { AutoSize = true, Text = "Værdi af julegave (kr.)" };
        var otherLabel = new Label { AutoSize = true, Text = "Værdi af andre gaver (kr.)" };
        var calculateButton = new Button
        {
            AutoSize = true,
            Text = "Beregn beskatning",
            Padding = new Padding(10, 4, 10, 4)
        };
        calculateButton.Click += (_, _) => CalculateTaxableAmount();

        layout.Controls.Add(heading, 0, 0);
        layout.Controls.Add(christmasLabel, 0, 1);
        layout.Controls.Add(christmasGiftInput, 0, 2);
        layout.Controls.Add(otherLabel, 0, 3);
        layout.Controls.Add(otherGiftsInput, 0, 4);
        layout.Controls.Add(calculateButton, 0, 5);

        var resultPanel = new FlowLayoutPanel
        {
            AutoSize = true,
            Dock = DockStyle.Fill,
            FlowDirection = FlowDirection.TopDown,
            WrapContents = false,
            Padding = new Padding(0, 10, 0, 0)
        };
        resultPanel.Controls.Add(resultLabel);
        resultPanel.Controls.Add(detailsLabel);
        layout.Controls.Add(resultPanel, 0, 6);
        Controls.Add(layout);
    }

    private static NumericUpDown CreateAmountInput() => new()
    {
        DecimalPlaces = 2,
        Maximum = 1_000_000,
        Minimum = 0,
        ThousandsSeparator = true,
        Width = 220
    };

    private void CalculateTaxableAmount()
    {
        var taxableAmount = GiftTaxCalculator.CalculateTaxableAmount(
            christmasGiftInput.Value,
            otherGiftsInput.Value);

        resultLabel.Text = $"Skattepligtigt beløb: {taxableAmount:N2} kr.";
        detailsLabel.Text = taxableAmount == 0
            ? "Det samlede beløb overstiger ikke 1.400 kr. Ingen af gaverne beskattes."
            : "Beløbet er den del af gaverne, der skal beskattes. Selve skatten afhænger af din skatteprocent.";
    }
}
