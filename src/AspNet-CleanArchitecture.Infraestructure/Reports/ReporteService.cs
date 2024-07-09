using System.Globalization;
using AspNet_CleanArchitecture.Application;
using AspNet_CleanArchitecture.Application.Interfaces;
using AspNet_CleanArchitecture.Domain;
using CsvHelper;

namespace AspNet_CleanArchitecture.Infraestructure.Reports;


public class ReportService<T> : IReportService<T> where T : BaseEntity
{
    public Task<MemoryStream> GetCsvReport(List<T> records)
    {
        using var  memoryStream = new MemoryStream();
        using var textWriter = new StreamWriter(memoryStream);
        using var csvWriter = new CsvWriter(textWriter, CultureInfo.InvariantCulture);
        csvWriter.WriteRecords(records);
        textWriter.Flush();

        memoryStream.Seek(0, SeekOrigin.Begin);

        return Task.FromResult(memoryStream);

    }
}