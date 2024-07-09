using AspNet_CleanArchitecture.Domain;

namespace AspNet_CleanArchitecture.Application.Interfaces;


public interface IReportService<T> where T: BaseEntity
{
    Task<MemoryStream> GetCsvReport(List<T> records);

}