﻿using LoginDemo.ViewModels;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace LoginDemo.App
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MvvmMainPage : Page
    {
        public MainPageMvvmToolkitViewModel Vm => DataContext as MainPageMvvmToolkitViewModel;

        public MvvmMainPage()
        {
            this.InitializeComponent();

            DataContext = new MainPageMvvmToolkitViewModel();
        }
    }
}
