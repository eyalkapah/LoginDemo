using LoginDemo.Models;
using LoginDemo.Services;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using System.Windows.Input;

namespace LoginDemo.ViewModels
{
    public class MainPageMvvmCrossViewModel : MvxViewModel
    {
        // Model
        public CredentialsMvvmCross Credentials { get; set; }

        // SignIn Command
        public ICommand SignInCommand { get; set; }

        // SignIn Service
        public SignInService SignInService { get; set; }

        private bool _isLoading;

        public bool IsLoading
        {
            get => _isLoading;
            set => SetProperty(ref _isLoading, value);
        }

        private bool _isSignInEnabled = true;

        public bool IsSignInEnabled
        {
            get => _isSignInEnabled;
            set => SetProperty(ref _isSignInEnabled, value);
        }

        private bool? _isSuccess;

        public bool? IsSuccess
        {
            get => _isSuccess;
            set => SetProperty(ref _isSuccess, value);
        }

        // C'tor
        //
        public MainPageMvvmCrossViewModel()
        {
            // Initialization
            Credentials = new CredentialsMvvmCross();

            SignInService = new SignInService();
            SignInCommand = new MvxCommand(SignInAsync);
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
