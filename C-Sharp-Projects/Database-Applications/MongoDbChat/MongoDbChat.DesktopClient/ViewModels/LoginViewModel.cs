namespace MongoDbChat.DesktopClient.ViewModels
{
    using System;
    using Microsoft.Practices.Prism.Commands;

    public class LoginViewModel : ViewModel
    {
        public event EventHandler LoggedIn;

        public LoginViewModel()
        {
            this.Username = "Pesho";
            this.LoginCommand = new DelegateCommand(this.Login);
        }

        public string Username { get; set; }

        public DelegateCommand LoginCommand { get; set; }

        private void Login()
        {
            if (this.LoggedIn != null)
            {
                this.LoggedIn(this, EventArgs.Empty);
            }
        }
    }
}
