using System.IO.Enumeration;

namespace SpeedyAir.Infrastructure.Datasource
{
    public sealed class LoadDatasource
    {
        private const string filename = "coding-assigment-orders.json";

        public static string LoadJsonDatasource()
        => File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "Datasource", $"{filename}"));
    }
}
