using Dapper.CX.Abstract;
using Microsoft.Data.SqlClient;
using System.Text.Json;

namespace BlazorAO.App.Services
{
    public class StateDictionary : DbDictionary<string>
    {
        public StateDictionary(string connectionString) : base(() => new SqlConnection(connectionString), "dbo.StateDictionary")
        {
        }

        protected override TValue Deserialize<TValue>(string value) => JsonSerializer.Deserialize<TValue>(value);


        protected override string Serialize<TValue>(TValue value) => JsonSerializer.Serialize(value);
    }
}
