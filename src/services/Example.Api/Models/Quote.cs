using Core.Business.Models;

namespace Example.Api.Models
{
    public class Quote : MongoDBEntity
    {
        public string Author { get; set; }
        public string Text { get; set; }
    }
}
