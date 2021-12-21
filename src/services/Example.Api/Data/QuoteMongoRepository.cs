using Core.Api.Data;
using Example.Api.Interfaces;
using Example.Api.Models;
using MongoDB.Driver;

namespace Example.Api.Data
{
    public class QuoteMongoRepository : GenericMongoRepository<Quote>, IQuoteMongoRepository
    {
        public QuoteMongoRepository(ExampleMongoContext exampleMongoContext) : base(exampleMongoContext)
        {
        }
    }
}
