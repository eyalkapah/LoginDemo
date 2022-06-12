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

        private bool? _isSuccess;

        public bool? IsSuccess
        {
            get => _isSuccess;
            set
            {
                if (_isSuccess != value)
                {
                    _isSuccess = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool _isLoading;

        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                if (_isLoading != value)
                {
                    _isLoading = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool _isSignInEnabled = true;

        public bool IsSignInEnabled
        {
            get => _isSignInEnabled;
            set
            {
                if (_isSignInEnabled != value)
                {
                    _isSignInEnabled = value;
                    OnPropertyChanged();
                }
            }
        }

        public MainPageViewModel()
        {
            Credentials = new Credentials();

            SignInService = new SignInService();
            SignInCommand = new RelayCommand(SignInAsync);
        }

        

        private async void SignInAsync()
        {
            BeforeSignIn();

            var result = await SignInService.SignInAsync(Credentials.Username, Credentials.Password);
            
            AfterSignIn(result);
        }

        private void BeforeSignIn()
        {
            // Show progress bar
            IsLoading = true;

            // Disable the sign in button while API call in progress
            IsSignInEnabled = false;

            // Hide success result panel
            IsSuccess = null;
        }

        private void AfterSignIn(bool result)
        {
            // Hide progress bar
            IsLoading = false;

            // Enable the sign in button
            IsSignInEnabled = true;

            // Show result
            IsSuccess = result;
        }
    }
}
