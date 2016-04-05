namespace NewsDb.DesktopClient
{
    using System.ComponentModel;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Windows;
    using Microsoft.Practices.Prism.Commands;
    using NewsDb.Data;
    using NewsDb.Models;

    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private NewsDbData newsDbData;

        public MainViewModel()
        {
            this.LoadNewsCommand = new DelegateCommand(this.LoadNews);
            this.SaveNewsCommand = new DelegateCommand(this.SaveNews, () => this.CurrentNews != null);
            this.newsDbData = new NewsDbData();
            this.newsDbData.Database.Initialize(false);
        }

        public DelegateCommand LoadNewsCommand { get; set; }

        public DelegateCommand SaveNewsCommand { get; set; }

        public News CurrentNews { get; set; }

        private async void LoadNews()
        {
            this.newsDbData = new NewsDbData();
            this.CurrentNews = await this.newsDbData.News.FirstAsync();
            this.OnPropertyChanged("CurrentNews");
            this.SaveNewsCommand.RaiseCanExecuteChanged();
        }

        private async void SaveNews()
        {
            try
            {
                await this.newsDbData.SaveChangesAsync();
                MessageBox.Show("Successfully updated.");
            }
            catch (DbUpdateConcurrencyException)
            {
                MessageBox.Show("Update conflict. Please try again.");
                this.LoadNews();
            }
        }
        
        private void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
