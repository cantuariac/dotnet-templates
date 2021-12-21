using Core.Api.Data;
using MongoDB.Driver;

namespace Example.Api.Data
{
    public class ExampleMongoContext : CoreMongoContext
    {
        public ExampleMongoContext() : base("example_mongo_db")
        {
        }
    }
}
