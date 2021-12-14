using Core.Data;
using Example.Api.Interfaces;
using Example.Api.Models;
using MongoDB.Driver;

namespace Example.Api.Data
{
    public class QuoteMongoRepository : GenericMongoRepository<Quote>, IQuoteMongoRepository
    {
        public QuoteMongoRepository(IMongoClient mongoClient) : base(mongoClient, "example_api")
        {
        }
    }
}
