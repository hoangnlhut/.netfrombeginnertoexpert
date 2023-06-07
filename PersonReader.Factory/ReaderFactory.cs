using PersonReader.CSV;
using PersonReader.Interface;
using PersonReader.Service;
using PersonReader.SQLServer;

namespace PersonReader.Factory
{
    public class ReaderFactory
    {
        public IPersonReader GetReader(string readerType)
        {
            switch (readerType)
            {
                case "Service": return new ServiceReader();
                case "CSV": return new CSVReader();
                case "SQLServer": return new SQLServerReader();
                default:
                    throw new ArgumentException($"Invalid reader type: {readerType}");
            }
        }
    }
}