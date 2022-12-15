using IAGRO.Challenge.Domain.Core.Interfaces;

namespace IAGRO.Challenge.Database.Core
{
    public class DataSource : IDataSource
    {
        public DataSource()
        {
            var path =  Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            JsonData = File.ReadAllText(path+"/Core/books.json");
        }

        public string JsonData { get; internal set; }
    }
}
