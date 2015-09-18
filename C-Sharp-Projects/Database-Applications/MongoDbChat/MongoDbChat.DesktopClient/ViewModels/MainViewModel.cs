namespace MongoDbChat.DesktopClient.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            var loginViewModel = new LoginViewModel();
            loginViewModel.LoggedIn += delegate
            {
                this.CurrentViewModel = new ChatViewModel(loginViewModel.Username);
                this.OnPropertyChanged("CurrentViewModel");
            };

            this.CurrentViewModel = loginViewModel;
        }

        public ViewModelBase CurrentViewModel { get; set; }
    }
}
