namespace XmlToEpp.DTOs;

public class DocumentXml
{
    public string? DocumentId { get; set; }
    public string? Number { get; set; }
    public string? IssueDate { get; set; }
    public string? SaleDate { get; set; }
    public string? PaymentDate { get; set; }
    public string? ReceiveDate { get; set; }
    public DocumentType? DocumentType { get; set; }
    public string? Classification { get; set; }
    public Contractor? Contractor { get; set; }
    public List<string> BankAccounts { get; set; } = [];
    public string? Category { get; set; }
    public string? Registry { get; set; }
    public Folder? Folder { get; set; }
    public string? Sum { get; set; }
    public List<VatRegistry> VatRegistries { get; set; } = [];
    public string? CurrencyIso4217 { get; set; }
    public string? PaymentType { get; set; }
    public string? Stage { get; set; }
    public string? Exported { get; set; }
    public string? Source { get; set; }
    public string? PageCount { get; set; }
    public List<string> PreviewUrls { get; set; } = [];
    public string? LangIso6391 { get; set; }
}

public class DocumentType
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public string? ShortName { get; set; }
    public string? Type { get; set; }
}

public class Contractor
{
    public string? ContractorId { get; set; }
    public string? ContractorProgramId { get; set; }
}

public class Folder
{
    public string? Month { get; set; }
    public string? Year { get; set; }
}

public class VatRegistry
{
    public string? Rate { get; set; }
    public string? Netto { get; set; }
    public string? Vat { get; set; }
}
