using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data
{
    public class CoreMongoContext
    {
        public MongoClient MongoClient { get; set; }
        public IMongoDatabase Database { get; set; }

        public CoreMongoContext(IMongoDatabase database)
        {
            Database = database;
        }
    }
}
