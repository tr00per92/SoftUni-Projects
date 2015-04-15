namespace MongoDbChat.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using MongoDB.Driver;
    using MongoDB.Driver.Linq;

    public class MongoDbContext
    {
        private readonly MongoCollection<Message> messages;
        private long messagesCount;

        public MongoDbContext()
        {
            var mongoClient = new MongoClient("mongodb://chatUser:chat@ds039301.mongolab.com:39301/chat");
            var db = mongoClient.GetServer().GetDatabase("chat");
            this.messages = db.GetCollection<Message>("messages");
            this.messagesCount = this.messages.Count();
        }

        public void AddMessage(Message message)
        {
            this.messages.Insert(message);
        }

        public Task<IQueryable<Message>> GetMessagesAsync(DateTime startDate, DateTime endDate)
        {
            return Task.Factory.StartNew(() => this.messages.AsQueryable().Where(m => m.Date >= startDate && m.Date <= endDate));
        }

        public Task<IQueryable<Message>> GetMessagesAsync()
        {
            return Task.Factory.StartNew(() => this.messages.AsQueryable());
        }
        
        public Task<bool> HasNewMessagesAsync()
        {
            return Task.Factory.StartNew(() =>
            {
                var newCount = this.messages.Count();
                if (newCount == this.messagesCount)
                {
                    return false;
                }

                this.messagesCount = newCount;
                return true;
            });
        }
    }
}
