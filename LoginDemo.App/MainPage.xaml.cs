using LoginDemo.Services;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using LoginDemo.Models;

namespace LoginDemo.App
{
    public sealed partial class MainPage : Page
    {
        // SignIn Service
        public SignInService SignInService { get; set; }

        public MainPage()
        {
            this.InitializeComponent();

            SignInService = new SignInService();
        }

        private async void SignInButton_Clicked(object sender, RoutedEventArgs e)
        {
            UpdateUIBeforeSignIn();

            // Try Sign In
            var result = await SignInService.SignInAsync(UsernameTextBox.Text, PasswordTextBox.Text);

            UpdateUIAfterSignIn(result);
        }

        private void UpdateUIAfterSignIn(bool result)
        {
            // Hide progress bar
            LoginProgressBar.Visibility = Visibility.Collapsed;

            // Enable the sign in button
            SignInButton.IsEnabled = true;

            // Success
            if (result)
            {
                // Show success 
                SuccessResultPanel.Visibility = Visibility.Visible;

                // Hide failure
                FailureResultPanel.Visibility = Visibility.Collapsed;
            }
            // Failure
            else
            {
                // Hide success
                SuccessResultPanel.Visibility = Visibility.Collapsed;

                // Show failure
                FailureResultPanel.Visibility = Visibility.Visible;
            }
        }

        private void UpdateUIBeforeSignIn()
        {
            // Show progress bar
            LoginProgressBar.Visibility = Visibility.Visible;

            // Disable the sign in button while API call in progress
            SignInButton.IsEnabled = false;

            // Hide result
            SuccessResultPanel.Visibility = Visibility.Collapsed;
            FailureResultPanel.Visibility = Visibility.Collapsed;
        }
    }
}
