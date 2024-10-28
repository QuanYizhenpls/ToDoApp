using Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApplication.Command;
using ToDoApplication.Views;

namespace ToDoApplication.ViewModels
{
    class AuthorizationViewModel : ViewModelBase
    {
        public AuthorizationViewModel()
        {
            LoginCommand = new RelayCommand(o =>
            {
                var user = UserService.Find(login, password);
                if (user != null)
                    new MainView().ShowDialog();
            });
            RegisterCommand = new RelayCommand(o =>
            {
                UserService.AddUser(lastName, firstName, midddleName, login, password);
            });
        }

        private string firstName = string.Empty;
        private string lastName = string.Empty;
        private string midddleName = string.Empty;
        private string login = string.Empty;
        private string password = string.Empty;

        public string FirstName { get => firstName; set => Set(ref firstName, value, nameof(firstName)); }
        public string LastName { get => lastName; set => Set(ref lastName, value, nameof(lastName)); }
        public string MidddleName { get => midddleName; set => Set(ref midddleName, value, nameof(midddleName)); }
        public string Login { get => login; set => Set(ref login, value, nameof(login)); }
        public string Password { get => password; set => Set(ref password, value, nameof(password)); }

        public RelayCommand LoginCommand { get; }
        public RelayCommand RegisterCommand { get; }
    }
}
