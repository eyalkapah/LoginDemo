using CommunityToolkit.Mvvm.ComponentModel;

namespace LoginDemo.Models
{
    public partial class CredentialsMvvmToolkit : ObservableObject
    {
        [ObservableProperty]
        private string _username;

        [ObservableProperty]
        private string _password;
    }
}
