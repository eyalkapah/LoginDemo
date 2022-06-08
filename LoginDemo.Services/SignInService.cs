using System;
using System.Threading.Tasks;

namespace LoginDemo.Services
{
    public class SignInService
    {
        private const string Username = "eykapah";
        private const string Password = "123456";

        public async Task<bool> SignInAsync(string username, string password)
        {
            await Task.Delay(5000);

            return string.Equals(username, Username, StringComparison.CurrentCultureIgnoreCase)
                   && string.Equals(password, Password);
        }
    }
}
