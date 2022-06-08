using LoginDemo.Services;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

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
            BeforeSignIn();

            // Try Sign In
            var result = await SignInService.SignInAsync(UsernameTextBox.Text, PasswordTextBox.Text);

            AfterSignIn(result);
        }

        private void AfterSignIn(bool result)
        {
            // Hide progress bar
            LoginProgressBar.Visibility = Visibility.Collapsed;

            // Enable the sign in button
            SignInButton.IsEnabled = true;

            // Success
            if (result)
            {
                // Show success 
                SuccessValidationPanel.Visibility = Visibility.Visible;

                // Hide failure
                FailureValidationPanel.Visibility = Visibility.Collapsed;
            }
            // Failure
            else
            {
                // Hide success
                SuccessValidationPanel.Visibility = Visibility.Collapsed;

                // Show failure
                FailureValidationPanel.Visibility = Visibility.Visible;
            }
        }

        private void BeforeSignIn()
        {
            // Show progress bar
            LoginProgressBar.Visibility = Visibility.Visible;

            // Disable the sign in button while API call in progress
            SignInButton.IsEnabled = false;

            // Hide result
            SuccessValidationPanel.Visibility = Visibility.Collapsed;
            FailureValidationPanel.Visibility = Visibility.Collapsed;
        }
    }
}
