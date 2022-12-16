using IAGRO.Challenge.Domain.Catalog.Entities;
using IAGRO.Challenge.Domain.Core.Interfaces;
using System.Text.Json;

namespace IAGRO.Challenge.Database.Core
{
    public class DataSource : IDataSource
    {
        private readonly string jsonData;
        public DataSource()
        {
            var path =  Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            jsonData = File.ReadAllText(path+"/Core/books.json");
        }

        public T JsonToObject<T>()
        {
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            options.Converters.Add(new CustomDateTimeConverter("MMMM dd, yyyy"));

            return JsonSerializer.Deserialize<T>(jsonData, options);
        }
    }
}
