namespace MongoDbChat.DesktopClient.ViewModels
{
    using System;
    using System.Collections.ObjectModel;
    using System.Windows.Threading;
    using Microsoft.Practices.Prism;
    using Microsoft.Practices.Prism.Commands;
    using MongoDbChat.Data;

    public class ChatViewModel : ViewModelBase
    {
        private readonly MongoDbContext mongoDbContext;

        public ChatViewModel(string username)
        {
            this.Username = username;
            this.Message = string.Empty;
            this.mongoDbContext = new MongoDbContext();
            this.PostMessageCommand = new DelegateCommand(this.PostMessage);
            this.Messages = new ObservableCollection<Message>();
            this.GetMessages();
            this.StartTimer();
        }

        public DelegateCommand PostMessageCommand { get; set; }

        public string Message { get; set; }

        public string Username { get; set; }

        public ObservableCollection<Message> Messages { get; set; }

        private void PostMessage()
        {
            this.mongoDbContext.AddMessage(new Message
            {
                Text = this.Message,
                Username = this.Username,
                Date = DateTime.Now
            });

            this.Message = string.Empty;
            this.OnPropertyChanged("Message");
        }

        private async void GetMessages()
        {
            var messages = await this.mongoDbContext.GetMessagesAsync();
            this.Messages.Clear();
            this.Messages.AddRange(messages);
        }

        private void StartTimer()
        {
            var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
            timer.Tick += this.UpdateMessages;
            timer.Start();
        }

        private async void UpdateMessages(object sender, EventArgs eventArgs)
        {
            if (await this.mongoDbContext.HasNewMessagesAsync())
            {
                this.GetMessages();
            }
        }
    }
}
