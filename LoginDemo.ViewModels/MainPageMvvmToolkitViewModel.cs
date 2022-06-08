using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LoginDemo.Models;
using LoginDemo.Services;
using System.Threading.Tasks;

namespace LoginDemo.ViewModels
{
    public partial class MainPageMvvmToolkitViewModel : ObservableObject
    {
        // Model
        public CredentialsMvvmToolkit Credentials { get; set; } = new();

        // SignIn Service
        public SignInService SignInService { get; set; } = new();

        [ObservableProperty]
        private bool _isLoading;

        [ObservableProperty]
        private bool? _isSuccess;

        [ObservableProperty]
        private bool _isSignInEnabled = true;
        

        [RelayCommand]
        private async Task SignIn()
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

            // Hide result panel
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
