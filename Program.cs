//current documentation is here: https://xls-epp.pl/info.pdf
using XmlToEpp;

var xmlFilePath = @"C:\Users\mateusz\Documents\MyDocs\Internal\AsioweZadanie\XmlToEpp\testData\exmpleInput.xml";
XmlReader xmlReader = new(xmlFilePath);

string eppFilePath = Path.Combine(Directory.GetCurrentDirectory(), $"example-${Guid.NewGuid()}.epp");
EppWriter eppWriter = new(eppFilePath, xmlReader.Contractors, xmlReader.Documents, xmlReader.Metadata);

var resultPath = eppWriter.WriteEppFile();
Console.WriteLine(resultPath);