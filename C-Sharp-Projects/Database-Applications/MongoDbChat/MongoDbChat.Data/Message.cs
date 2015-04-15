namespace MongoDbChat.Data
{
    using System;
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class Message
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Text { get; set; }

        public DateTime Date { get; set; }

        public string Username { get; set; }

        public override string ToString()
        {
            var date = this.Date.ToString("d.MM.yyyy hh:mm:ss");
            return string.Format("[{0}] {1}: {2}", date, this.Username, this.Text);
        }
    }
}
