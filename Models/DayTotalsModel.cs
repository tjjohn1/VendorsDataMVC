using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CasinoDataMVC.Models
{
    public class DayTotalsModel
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("vendor")]
        public string vendor { get; set; }
        [BsonElement("date")]
        public string date { get; set; }
        [BsonElement("grand_total")]
        public double grand_total { get; set; }
        [BsonElement("terminals")]
        public TerminalModel[] terminals { get; set; }
    }
}