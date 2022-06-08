using LoginDemo.Common;
using LoginDemo.Models;
using LoginDemo.Services;

namespace LoginDemo.ViewModels
{
    public class MainPageViewModel : Observable
    {

        public Credentials Credentials { get; set; }

        public RelayCommand SignInCommand { get; set; }
        public SignInService SignInService { get; set; }
      
        public MainPageViewModel()
        {
            Credentials = new Credentials
            {
                Username = "test",
                Password = "password"
            };

            SignInService = new SignInService();
            SignInCommand = new RelayCommand(SignInAsync);
        }

        

        private async void SignInAsync()
        {
            var result = await SignInService.SignInAsync(Credentials.Username, Credentials.Password);
        }
    }
}
