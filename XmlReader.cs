using System.Xml.Linq;
using XmlToEpp.DTOs;

namespace XmlToEpp;

public class XmlReader
{
    public List<DocumentXml> Documents { get; set; }
    public List<ContractorXml> Contractors { get; set; }
    public MetadataXml Metadata { get; set; }
    private readonly XDocument xmlDocument;

    public XmlReader(string filePath)
    {
        xmlDocument = XDocument.Load(filePath);
        Documents = ParseDocuments();
        Contractors = ParseContractors();
        Metadata = ParseMetadata();
    }

    private List<DocumentXml> ParseDocuments()
    {
        List<DocumentXml> list = [];
        var documents = xmlDocument.Root?.Element("DOCUMENTS");
        if (documents is null) return list;
        foreach (var childElement in documents.Elements("DOCUMENT"))
        {
            var doc = new DocumentXml()
            {
                DocumentId = childElement.Element("DOCUMENT_ID")?.Value,
                Number = childElement.Element("NUMBER")?.Value,
                IssueDate = childElement.Element("ISSUE_DATE")?.Value,
                SaleDate = childElement.Element("SALE_DATE")?.Value,
                PaymentDate = childElement.Element("PAYMENT_DATE")?.Value,
                ReceiveDate = childElement.Element("RECEIVE_DATE")?.Value,
                DocumentType = new DocumentType()
                {
                    Id = childElement.Element("DOCUMENT_TYPE")?.Element("ID")?.Value,
                    Name = childElement.Element("DOCUMENT_TYPE")?.Element("NAME")?.Value,
                    ShortName = childElement.Element("DOCUMENT_TYPE")?.Element("SHORT_NAME")?.Value,
                    Type = childElement.Element("DOCUMENT_TYPE")?.Element("TYPE")?.Value
                },
                Classification = childElement.Element("CLASSIFICATION")?.Value,
                Contractor = new Contractor()
                {
                    ContractorId = childElement.Element("CONTRACTOR")?.Element("CONTRACTOR_ID")?.Value,
                    ContractorProgramId = childElement.Element("CONTRACTOR")?.Element("CONTRACTOR_PROGRAM_ID")?.Value
                },
                BankAccounts = childElement.Element("BANK_ACCOUNTS")?.Descendants("BANK_ACCOUNT").Select(x => x.Value).ToList() ?? [],
                Category = childElement.Element("CATEGORY")?.Value,
                Registry = childElement.Element("REGISTRY")?.Value,
                Folder = new Folder()
                {
                    Month = childElement.Element("FOLDER")?.Element("MONTH")?.Value,
                    Year = childElement.Element("FOLDER")?.Element("YEAR")?.Value
                },
                Sum = childElement.Element("SUM")?.Value,
                VatRegistries =
                 childElement.Element("VAT_REGISTRIES")?.Descendants("VAT_REGISTRY").Select(x => new VatRegistry()
                 {
                     Rate = x.Element("RATE")?.Value,
                     Netto = x.Element("NETTO")?.Value,
                     Vat = x.Element("VAT")?.Value,
                 }).ToList() ?? [],
                CurrencyIso4217 = childElement.Element("CURRENCY_ISO4217")?.Value,
                PaymentType = childElement.Element("PAYMENT_TYPE")?.Value,
                Stage = childElement.Element("STAGE")?.Value,
                Exported = childElement.Element("EXPORTED")?.Value,
                Source = childElement.Element("SOURCE")?.Value,
                PageCount = childElement.Element("PAGE_COUNT")?.Value,
                PreviewUrls = childElement.Element("PREVIEWS")?.Descendants("PREVIEW_URL").Select(x => x.Value).ToList() ?? [],
                LangIso6391 = childElement.Element("LANG_ISO639_1")?.Value
            };

            list.Add(doc);
        }
        return list;
    }

    private List<ContractorXml> ParseContractors()
    {
        List<ContractorXml> list = [];
        var contractors = xmlDocument.Root?.Element("CONTRACTORS");
        if (contractors is null) return list;
        foreach (var childElement in contractors.Elements("CONTRACTOR"))
        {
            var contractor = new ContractorXml()
            {
                ContractorProgramId = childElement.Element("CONTRACTOR_PROGRAM_ID")?.Value,
                ContractorId = childElement.Element("CONTRACTOR_ID")?.Value,
                ShortName = childElement.Element("SHORT_NAME")?.Value,
                FullName = childElement.Element("FULL_NAME")?.Value,
                Supplier = childElement.Element("SUPPLIER")?.Value,
                Customer = childElement.Element("CUSTOMER")?.Value,
                VatNumber = childElement.Element("VAT_NUMBER")?.Value,
                City = childElement.Element("CITY")?.Value,
                Postcode = childElement.Element("POSTCODE")?.Value,
                Street = childElement.Element("STREET")?.Value,
                CountryIso3166A2 = childElement.Element("COUNTRY_ISO3166A2")?.Value,
                BankAccounts = childElement.Element("BANK_ACCOUNTS")?.Descendants("BANK_ACCOUNT").Select(x => new BankAccount()
                {
                    Name = x.Element("NAME")?.Value,
                    Number = x.Element("NUMBER")?.Value,
                }).ToList() ?? [],
            };

            list.Add(contractor);
        }
        return list;
    }

    private MetadataXml ParseMetadata()
    {
        var metadata = xmlDocument.Root?.Element("METAINF");
        MetadataXml result = new()
        {
            Producer = metadata?.Element("PRODUCER")?.Value,
            Timestamp = metadata?.Element("TIMESTAMP")?.Value,
            Operation = metadata?.Element("OPERATION")?.Value,
            Version = metadata?.Element("VERSION")?.Value,
            CompanyProgramId = metadata?.Element("PARAMETERS")?.Descendants("PARAMETER")
                .Where(x => x.Element("NAME")?.Value == "company_program_id")
                .Select(x => x.Element("VALUE")?.Value).FirstOrDefault(),
            ReqId = metadata?.Element("PARAMETERS")?.Descendants("PARAMETER")
                .Where(x => x.Element("NAME")?.Value == "req_id")
                .Select(x => x.Element("VALUE")?.Value).FirstOrDefault(),
            Policy = metadata?.Element("PARAMETERS")?.Descendants("PARAMETER")
                .Where(x => x.Element("NAME")?.Value == "policy")
                .Select(x => x.Element("VALUE")?.Value).FirstOrDefault(),
            Username = metadata?.Element("PARAMETERS")?.Descendants("PARAMETER")
                .Where(x => x.Element("NAME")?.Value == "username")
                .Select(x => x.Element("VALUE")?.Value).FirstOrDefault(),

        };
        return result;
    }
}