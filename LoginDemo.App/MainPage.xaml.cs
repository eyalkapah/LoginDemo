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

            AfterSignIn();

            if (result)
            {
                SuccessFontIcon.Visibility = Visibility.Visible;
                FailureFontIcon.Visibility = Visibility.Collapsed;
            }
            else
            {
                FailureFontIcon.Visibility = Visibility.Visible;
                SuccessFontIcon.Visibility = Visibility.Collapsed;
            }
        }

        private void AfterSignIn()
        {
            LoginProgressBar.Visibility = Visibility.Collapsed;
            SignInButton.IsEnabled = true;
            ValidationPanel.Visibility = Visibility.Visible;
        }

        private void BeforeSignIn()
        {
            LoginProgressBar.Visibility = Visibility.Visible;
            SignInButton.IsEnabled = false;
            ValidationPanel.Visibility = Visibility.Collapsed;
        }
    }
}
