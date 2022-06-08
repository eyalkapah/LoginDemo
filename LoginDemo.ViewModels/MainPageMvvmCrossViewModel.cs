using LoginDemo.Models;
using LoginDemo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.ViewModels;
using LoginDemo.Common;
using MvvmCross.Commands;

namespace LoginDemo.ViewModels
{
    public class MainPageMvvmCrossViewModel : MvxViewModel
    {
        // Model
        public Credentials Credentials { get; set; }

        // SignIn Command
        public ICommand SignInCommand { get; set; }

        // SignIn Service
        public SignInService SignInService { get; set; }


        // C'tpr
        //
        public MainPageMvvmCrossViewModel()
        {
            // Initialization
            Credentials = new Credentials
            {
                Username = "test",
                Password = "password"
            };

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
