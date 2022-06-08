using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using LoginDemo.Services;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace LoginDemo.App
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public SignInService SignInService { get; set; }

        public MainPage()
        {
            this.InitializeComponent();

            SignInService = new SignInService();
        }

        private async void SignInButton_Clicked(object sender, RoutedEventArgs e)
        {
            BeforeSignIn();

            var result = await SignInService.SignInAsync(UsernameTextBox.Text, PasswordTextBox.Text);

            AfterSignIn(result);
        }

        private void AfterSignIn(bool result)
        {
            // Hide progress bar
            LoginProgressBar.Visibility = Visibility.Collapsed;

            // Enable the sign in button
            SignInButton.IsEnabled = true;

            // Show result
            ValidationPanel.Visibility = Visibility.Visible;

            // Success
            if (result)
            {
                // Show success 
                SuccessFontIcon.Visibility = Visibility.Visible;

                // Hide failure
                FailureFontIcon.Visibility = Visibility.Collapsed;
            }
            // Failure
            else
            {
                // Show failure
                FailureFontIcon.Visibility = Visibility.Visible;

                // Hide success
                SuccessFontIcon.Visibility = Visibility.Collapsed;
            }
        }

        private void BeforeSignIn()
        {
            // Show progress bar
            LoginProgressBar.Visibility = Visibility.Visible;

            // Disable the sign in button while API call in progress
            SignInButton.IsEnabled = false;

            // Hide result
            ValidationPanel.Visibility = Visibility.Collapsed;
        }
    }
}
