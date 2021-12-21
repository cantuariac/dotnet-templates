using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Api.Data
{
    public class CoreMongoContext
    {
        private MongoClient? MongoClient { get; set; }
        public IMongoDatabase? Database { get; set; }
        public string Name { get; set; }

        public CoreMongoContext(string name)
        {
            Name = name;
        }

        public CoreMongoContext()
        {
            Name = "mongo_db";
        }

        public void Configure(string connectionString)
        {
            MongoClient = new MongoClient(connectionString);
            Database = MongoClient.GetDatabase(Name);
        }
    }
}
