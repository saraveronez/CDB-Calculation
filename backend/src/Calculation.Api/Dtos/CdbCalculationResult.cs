namespace Calculation.Api.Dtos;

public class CdbCalculationResult
{
    public decimal NetValueTotal { get; set; }
    public decimal GrossValueTotal { get; set; }
    public decimal NetProfit { get; set; }
    public decimal GrossProfit { get; set; }
    public decimal Taxes { get; set; }
}