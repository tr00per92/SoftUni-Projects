namespace MongoDbChat.DesktopClient.ViewModels
{
    public class MainViewModel : ViewModel
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

        public ViewModel CurrentViewModel { get; set; }
    }
}
