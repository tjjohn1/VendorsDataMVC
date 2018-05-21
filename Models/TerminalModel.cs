using MongoDB.Bson.Serialization.Attributes;

namespace CasinoDataMVC.Models
{
    public class TerminalModel
    {
        [BsonElement("terminal")]
        public int terminal { get; set; }
        [BsonElement("ones")]
        public int ones { get; set; }
        [BsonElement("fives")]
        public int fives { get; set; }
        [BsonElement("tens")]
        public int tens { get; set; }
        [BsonElement("twenties")]
        public int twenties { get; set; }
        [BsonElement("fifties")]
        public int fifties { get; set; }
        [BsonElement("hundreds")]
        public int hundreds { get; set; }
        [BsonElement("total")]
        public int total { get; set; }
    }
}