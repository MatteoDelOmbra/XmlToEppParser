namespace XmlToEpp.DTOs;
public class ContractorXml
{
    public string? ContractorProgramId { get; set; }
    public string? ContractorId { get; set; }
    public string? ShortName { get; set; }
    public string? FullName { get; set; }
    public string? Supplier { get; set; }
    public string? Customer { get; set; }
    public string? VatNumber { get; set; }
    public string? City { get; set; }
    public string? Postcode { get; set; }
    public string? Street { get; set; }
    public string? CountryIso3166A2 { get; set; }
    public List<BankAccount> BankAccounts { get; set; } = [];
}

public class BankAccount
{
    public string? Name { get; set; }
    public string? Number { get; set; }
}
