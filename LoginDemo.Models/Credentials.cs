using LoginDemo.Common;

namespace LoginDemo.Models
{
    public class Credentials : Observable
    {
        private string _username;

        public string Username
        {
            get => _username;
            set
            {
                if (_username == value) 
                    return;
                
                _username = value;
                OnPropertyChanged();
            } 
        }

        private string _password;

        public string Password
        {
            get => _password;
            set
            {
                if (_password == value)
                    return;

                _password = value;
                OnPropertyChanged();
            }
        }
    }

    
}
