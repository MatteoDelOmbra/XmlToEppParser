using System.Runtime.CompilerServices;
using XmlToEpp.DTOs;

namespace XmlToEpp;
public class EppWriter(string filePath, List<ContractorXml> xmlContractors, List<DocumentXml> xmlDocuments, MetadataXml metadataXml)
{
    private readonly StreamWriter writer = new(filePath);
    private readonly List<ContractorXml> Contractors = xmlContractors;
    private readonly List<DocumentXml> Documents = xmlDocuments;
    private readonly MetadataXml Metadata = metadataXml;

    public string WriteEppFile()
    {
        WriteInfoSection();
        foreach (DocumentXml doc in Documents)
        {
            WriteDocumentSection(doc);
        }
        // WriteContractorsSectcion();
        // WriteContractorGroupsSection();
        // WriteContractorPropertiesSection();
        // WriteProductsSection();
        // WritePriceListSection();
        // WriteProductsGroupsSection();
        // WriteProductsPropertiesSection();
        // WriteEmployeesSection();
        // WriteOfficesSection();
        // WritePaymentIdsSection();
        // WriteEndDatesSection();
        // WriteBuyersIdsSection();
        // WriteCorrectionsReasonsSection();
        // WriteContractorAddonsSection();
        // WriteProductsAddonsSections();
        // WriteFiscalVatDocumentsSection();
        // WriteAdditionalFeesSection();
        // WriteSpecialFeesSection();
        // WriteMppRequirednessSection();
        // WriteCnProductsCodesSection();
        // WriteJpkVatGroupsSection();
        // WriteJpkVatDocumentTagsSection();
        // WriteSpreadDeliveryFmSection();
        // WriteSugerFeeSection();
        // WriteWstoProductSpecificationSection();
        // WritePaymentsSection();
        // WriteWstoInformationSection();
        // WriteForeignVatStakeSection();
        // WriteCorrectionAddDatesSection();
        writer.Flush();
        return filePath;
    }

    private void WriteSection(string sectionName, Action writeContent)
    {
        writer.WriteLine("[NAGLOWEK]");
        writer.WriteLine($"{sectionName}");
        writer.WriteLine();
        writer.WriteLine("[ZAWARTOSC]");
        writeContent.Invoke();
        writer.WriteLine();
    }

    #region SectionWriters
    private void WriteInfoSection()
    {
        writer.WriteLine("[INFO]");
        writer.WriteLine(CreateInfoHeaderData());
        writer.WriteLine();
    }
    private void WriteDocumentSection(DocumentXml document)
    {
        var documentHeader = CreateDocumentHeaderData(document);
        WriteSection(documentHeader, () =>
        {
            foreach (var item in document.VatRegistries.Select((value, index) => new { value, index }))
            {
                writer.WriteLine(CreateRegistryContentData(document, item.value, item.index));
            }
        });
    }
    private void WriteContractorsSectcion()
    {
        WriteSection("KONTRAHENCI", () =>
        {
            foreach (ContractorXml contractor in Contractors)
            {
                writer.WriteLine("Dane zawartości");
            }
        });
    }
    private void WriteContractorGroupsSection()
    {
        WriteSection("GRUPYKONTRAHENTOW", () =>
        {
            writer.WriteLine("Dane zawartości");
        });
    }
    private void WriteContractorPropertiesSection()
    {
        WriteSection("CECHYKONTRAHENTOW", () =>
        {
            writer.WriteLine("Dane zawartości");
        });
    }
    private void WriteProductsSection()
    {
        WriteSection("TOWARY", () =>
        {
            writer.WriteLine("Dane zawartości");
        });
    }
    private void WritePriceListSection()
    {
        WriteSection("CENNIK", () =>
        {
            writer.WriteLine("Dane zawartości");
        });
    }
    private void WriteProductsGroupsSection()
    {
        WriteSection("GRUPYTOWAROW", () =>
        {
            writer.WriteLine("Dane zawartości");
        });
    }
    private void WriteProductsPropertiesSection()
    {
        WriteSection("CECHYTOWAROW", () =>
        {
            writer.WriteLine("Dane zawartości");
        });
    }
    private void WriteEmployeesSection()
    {
        WriteSection("PRACOWNICY", () =>
        {
            writer.WriteLine("Dane zawartości");
        });
    }
    private void WriteOfficesSection()
    {
        WriteSection("URZEDY", () =>
        {
            writer.WriteLine("Dane zawartości");
        });
    }
    private void WritePaymentIdsSection()
    {
        WriteSection("IDENTYFIKATORYPLATNOSCI", () =>
        {
            writer.WriteLine("Dane zawartości");
        });
    }
    private void WriteEndDatesSection()
    {
        WriteSection("DATYZAKONCZENIA", () =>
        {
            writer.WriteLine("Dane zawartości");
        });
    }
    private void WriteBuyersIdsSection()
    {
        WriteSection("NUMERYIDENTYFIKACYJNENABYWCOW", () =>
        {
            writer.WriteLine("Dane zawartości");
        });
    }
    private void WriteCorrectionsReasonsSection()
    {
        WriteSection("PRZYCZYNYKOREKT", () =>
        {
            writer.WriteLine("Dane zawartości");
        });
    }
    private void WriteContractorAddonsSection()
    {
        WriteSection("DODATKOWEKONTRAHENTOW", () =>
        {
            writer.WriteLine("Dane zawartości");
        });
    }
    private void WriteProductsAddonsSections()
    {
        WriteSection("DODATKOWETOWAROW", () =>
        {
            writer.WriteLine("Dane zawartości");
        });
    }
    private void WriteFiscalVatDocumentsSection()
    {
        WriteSection("DOKUMENTYFISKALNEVAT", () =>
        {
            writer.WriteLine("Dane zawartości");
        });
    }
    private void WriteAdditionalFeesSection()
    {
        WriteSection("OPLATYDODATKOWE", () =>
        {
            writer.WriteLine("Dane zawartości");
        });
    }
    private void WriteSpecialFeesSection()
    {
        WriteSection("OPLATYSPECJALNE", () =>
        {
            writer.WriteLine("Dane zawartości");
        });
    }
    private void WriteMppRequirednessSection()
    {
        WriteSection("WYMAGALNOSCMPP", () =>
        {
            writer.WriteLine("Dane zawartości");
        });
    }
    private void WriteCnProductsCodesSection()
    {
        WriteSection("TOWARYKODYCN", () =>
        {
            writer.WriteLine("Dane zawartości");
        });
    }
    private void WriteJpkVatGroupsSection()
    {
        WriteSection("TOWARYGRUPYJPKVAT", () =>
        {
            writer.WriteLine("Dane zawartości");
        });
    }
    private void WriteJpkVatDocumentTagsSection()
    {
        WriteSection("DOKUMENTYZNACZNIKIJPKVAT", () =>
        {
            writer.WriteLine("Dane zawartości");
        });
    }
    private void WriteSpreadDeliveryFmSection()
    {
        WriteSection("DOSTAWYMARZOWEDLAFM", () =>
        {
            writer.WriteLine("Dane zawartości");
        });
    }
    private void WriteSugerFeeSection()
    {
        WriteSection("OPLATACUKROWA", () =>
        {
            writer.WriteLine("Dane zawartości");
        });
    }
    private void WriteWstoProductSpecificationSection()
    {
        WriteSection("SPECYFIKACJATOWAROWAWSTO", () =>
        {
            writer.WriteLine("Dane zawartości");
        });
    }
    private void WritePaymentsSection()
    {
        WriteSection("PLATNOSCI", () =>
        {
            writer.WriteLine("Dane zawartości");
        });
    }
    private void WriteWstoInformationSection()
    {
        WriteSection("INFORMACJEWSTO", () =>
        {
            writer.WriteLine("Dane zawartości");
        });
    }
    private void WriteForeignVatStakeSection()
    {
        WriteSection("STAWKIVATZAGRANICZNE", () =>
        {
            writer.WriteLine("Dane zawartości");
        });
    }
    private void WriteCorrectionAddDatesSection()
    {
        WriteSection("DATYUJECIAKOREKT", () =>
        {
            writer.WriteLine("Dane zawartości");
        });
    }
    #endregion SectionWriters

    #region Creators
    private string CreateInfoHeaderData()
    {
        //based on table 2 from docs
        var version = $"\"{Metadata.Version}\"";
        var communicationGoal = "3";
        var codingPage = "1250";
        var creatingProgramInfo = "\"Subiekt GT\"";
        var idCode = "\"GT\"";
        var senderShortName = "\"baza\"";
        var senderFullName = "\"Firma przykładowa systemu InsERT GT\"";
        var senderCity = "\"Wrocław\"";
        var senderPostcode = "\"54-445\"";
        var senderAddress = "\"Bławatkowa 25/3\"";
        var senderNip = "\"111-111-11-11\"";
        var magazineCode = "\"MAG\"";
        var magazineName = "\"Główny\"";
        var magazineDescription = "\"Magazyn główny\"";
        var magazineAnalytics = string.Empty;
        var dataFromPeriod = "1";
        var periodStart = "20250120084236";
        var periodEnd = "20250120084236";
        var whoMadeCommunication = "\"Szef\"";
        var whenMadeCommunication = "20250120084236";
        var country = "\"Polska\"";
        var countryPrefix = "\"PL\"";
        var senderUeNip = "\"1111111111\"";
        var isSenderUe = "0";

        var result =
            version + "," +
            communicationGoal + "," +
            codingPage + "," +
            creatingProgramInfo + "," +
            idCode + "," +
            senderShortName + "," +
            senderFullName + "," +
            senderCity + "," +
            senderPostcode + "," +
            senderAddress + "," +
            senderNip + "," +
            magazineCode + "," +
            magazineName + "," +
            magazineDescription + "," +
            magazineAnalytics + "," +
            dataFromPeriod + "," +
            periodStart + "," +
            periodEnd + "," +
            whoMadeCommunication + "," +
            whenMadeCommunication + "," +
            country + "," +
            countryPrefix + "," +
            senderUeNip + "," +
            isSenderUe;

        return result;
    }
    private string CreateDocumentHeaderData(DocumentXml document)
    {
        var contractor = Contractors
            .Where(c => c.ContractorId == document?.Contractor?.ContractorId)
            .FirstOrDefault() ?? throw new Exception("Contractor not found");

        //based on table 3 from docs
        var documentType = MapDocumentType(document.DocumentType?.Type ?? string.Empty);
        var documentStatus = "1";
        var fiscalRegistrationStatus = "0";
        var documentNumber = "3";
        var supplierDocumentNumber = "234234234234234";
        var userExtendedNumber = string.Empty;
        var fullDocumentNumber = "3/2025";
        var correctedDocumentNumber = string.Empty;
        var correctedDocumentIssueDate = string.Empty;
        var orderNumber = string.Empty;
        var targetWarehouseSymbol = string.Empty;
        var contractorIdentificationCode = "NOVUM";
        var contractorShortName = contractor.ShortName;
        var contractorFullName = contractor.FullName;
        var contractorCity = contractor.City;
        var contractorPostalCode = contractor.Postcode;
        var contractorStreetAddress = contractor.Street;
        var contractorVatNumber = contractor.VatNumber;
        var categoryName = "Zakup";
        var categorySubtitle = "Zakup towarów lub usług";
        var issueLocation = "Sosnowiec";
        var issueDate = "20250117000000";
        var saleDate = "20250117000000";
        var receiptDate = "20250117000000";
        var itemCount = "1";
        var isNetPricing = "1";
        var activePriceName = "Cena ostatniej dost.";
        var netValue = "1.0000";
        var vatValue = "0.2300";
        var grossValue = "1.2300";
        var costValue = "0.0000";
        var discountName = string.Empty;
        var discountPercentage = "0.0000";
        var paymentMethodName = string.Empty;
        var paymentDueDate = "20250117000000";
        var amountPaidOnReceipt = "0.0000";
        var amountDue = "1.2300";
        var amountDueRounding = "0";
        var vatRounding = "0";
        var autoCalculatedVatTableAndValue = "1";
        var extendedAndSpecialDocumentStatuses = "3";
        var issuingPersonName = "Irena Kołodziej";
        var receivingPersonName = "Szef";
        var documentIssueBasis = string.Empty;
        var issuedPackagingValue = "0.0000";
        var returnedPackagingValue = "0.0000";
        var currencySymbol = "PLN";
        var currencyExchangeRate = "1.0000";
        var remarks = string.Empty;
        var comment = string.Empty;
        var documentSubtitle = string.Empty;
        var notUsed = string.Empty;
        var documentImportCompleted = "1";
        var exportDocument = "0";
        var transactionType = "0";
        var cardPaymentName = string.Empty;
        var cardPaymentAmount = "0.0000";
        var creditPaymentName = string.Empty;
        var creditPaymentAmount = "0.0000";
        var contractorCountry = "Polska";
        var contractorEuCountryPrefix = "PL";
        var isContractorFromEu = "0";

        var result =
        $"\"{documentType}\"" + "," +
        $"{documentStatus}" + "," +
        $"{fiscalRegistrationStatus}" + "," +
        $"{documentNumber}" + "," +
        $"\"{supplierDocumentNumber}\"" + "," +
        $"{userExtendedNumber}" + "," +
        $"\"{fullDocumentNumber}\"" + "," +
        $"{correctedDocumentNumber}" + "," +
        $"{correctedDocumentIssueDate}" + "," +
        $"{orderNumber}" + "," +
        $"{targetWarehouseSymbol}" + "," +
        $"\"{contractorIdentificationCode}\"" + "," +
        $"\"{contractorShortName}\"" + "," +
        $"\"{contractorFullName}\"" + "," +
        $"\"{contractorCity}\"" + "," +
        $"\"{contractorPostalCode}\"" + "," +
        $"\"{contractorStreetAddress}\"" + "," +
        $"\"{contractorVatNumber}\"" + "," +
        $"\"{categoryName}\"" + "," +
        $"\"{categorySubtitle}\"" + "," +
        $"\"{issueLocation}\"" + "," +
        $"{issueDate}" + "," +
        $"{saleDate}" + "," +
        $"{receiptDate}" + "," +
        $"{itemCount}" + "," +
        $"{isNetPricing}" + "," +
        $"\"{activePriceName}\"" + "," +
        $"{netValue}" + "," +
        $"{vatValue}" + "," +
        $"{grossValue}" + "," +
        $"{costValue}" + "," +
        $"{discountName}" + "," +
        $"{discountPercentage}" + "," +
        $"{paymentMethodName}" + "," +
        $"{paymentDueDate}" + "," +
        $"{amountPaidOnReceipt}" + "," +
        $"{amountDue}" + "," +
        $"{amountDueRounding}" + "," +
        $"{vatRounding}" + "," +
        $"{autoCalculatedVatTableAndValue}" + "," +
        $"{extendedAndSpecialDocumentStatuses}" + "," +
        $"\"{issuingPersonName}\"" + "," +
        $"\"{receivingPersonName}\"" + "," +
        $"{documentIssueBasis}" + "," +
        $"{issuedPackagingValue}" + "," +
        $"{returnedPackagingValue}" + "," +
        $"\"{currencySymbol}\"" + "," +
        $"{currencyExchangeRate}" + "," +
        $"{remarks}" + "," +
        $"{comment}" + "," +
        $"{documentSubtitle}" + "," +
        $"{notUsed}" + "," +
        $"{documentImportCompleted}" + "," +
        $"{exportDocument}" + "," +
        $"{transactionType}" + "," +
        $"{cardPaymentName}" + "," +
        $"{cardPaymentAmount}" + "," +
        $"{creditPaymentName}" + "," +
        $"{creditPaymentAmount}" + "," +
        $"\"{contractorCountry}\"" + "," +
        $"\"{contractorEuCountryPrefix}\"" + "," +
        $"{isContractorFromEu}";

        return result;
    }
    private static string CreateRegistryContentData(DocumentXml document, VatRegistry registry, int position)
    {
        //based on table 7 from docs
        var itemOrderNumber = "1";
        var itemType = "2";
        var itemIdentificationCode = string.Empty;
        var discountPercentageLogical = "1";
        var discountFromPriceLogical = "1";
        var cumulativeItemDiscountWithDocumentDiscount = "0";
        var discountLockedForItem = "1";
        var itemDiscountValue = "0.0000";
        var itemDiscountPercentage = "0.0000";
        var unitOfMeasure = "szt.";
        var quantityInUnitOfMeasure = "1.0000";
        var quantityInWarehouseUnit = "1.0000";
        var warehouseItemPrice = "0.0000";
        var itemNetPrice = "1.0000";
        var itemGrossPrice = "1.2300";
        var vatRatePercentage = registry.Rate;
        var itemNetValue = registry.Netto;
        var vatValue = registry.Vat;
        var itemGrossValue = "1.2300";
        var itemCost = "0.0000";
        var oneTimeServiceDescription = string.Empty;
        var oneTimeServiceName = $"pozycja {position}";

        var result =
        $"{itemOrderNumber}," +
        $"{itemType}," +
        $"{itemIdentificationCode}," +
        $"{discountPercentageLogical}," +
        $"{discountFromPriceLogical}," +
        $"{cumulativeItemDiscountWithDocumentDiscount}," +
        $"{discountLockedForItem}," +
        $"{itemDiscountValue}," +
        $"{itemDiscountPercentage}," +
        $"\"{unitOfMeasure}\"," +
        $"{quantityInUnitOfMeasure}," +
        $"{quantityInWarehouseUnit}," +
        $"{warehouseItemPrice}," +
        $"{itemNetPrice}," +
        $"{itemGrossPrice}," +
        $"{vatRatePercentage}," +
        $"{itemNetValue}," +
        $"{vatValue}," +
        $"{itemGrossValue}," +
        $"{itemCost}," +
        $"{oneTimeServiceDescription}," +
        $"\"{oneTimeServiceName}\"";

        return result;
    }
    private static string CreateContractorContentData(ContractorXml contractor)
    {
        //based on table 14 from docs
        return $"Dane konrahenta: {contractor.ContractorId}";
    }
    #endregion Creators

    #region Mappers
    private static string MapDocumentType(string type)
    {
        return type switch
        {
            "INVOICE_COST" => "FZ",
            _ => "Unknown",
        };
    }

    #endregion Mappers
}