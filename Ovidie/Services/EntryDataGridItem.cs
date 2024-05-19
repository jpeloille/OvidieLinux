using System;

namespace Ovidie.Services;

public class EntryDataGridItem
{
    public Guid AccountIdentifier { get; set; }
    public Guid? PayeeIdentifier { get; set; }
    public Guid? MethodIdentifier { get; set; }
    public DateOnly? TransactionDate { get; set; }
    public string? MethodLabel { get; set; }
    public decimal? CheckNumber { get; set; }
    public string? PayeeLabel { get; set; }
    public decimal? Debt { get; set; }
    public decimal? Credit { get; set; }
    public decimal? Balance { get; set; }
}