using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF_UserManagement.Models;
using WPF_UserManagement.repositories;

namespace WPF_UserManagement.ViewModel
{
    public class LoginViewModel : ViewModel_UserManagement
    {
        //Fields
        private string _username;
        private SecureString _password; //Microsofe no longer supports the use of SecureString in XAML cuz in some point it will
                                        //nessesary to convert the content to plain text for example to do validation restored in database
                                        // and from .Net core secure string is no longer encrypted in memory.ö

        private string _errormessage;
        private bool _isViewVisible = true;
        private readonly IUserRepository UserRepository;


        //Properties
        public string Username

        {
            get
            {
                return _username;
            }

            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public SecureString Password

        {
            get
            {
                return _password;
            }

            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));

            }
        }

        public string Errormessage

        {
            get
            {
                return _errormessage;
            }
            set
            {
                _errormessage = value;
                OnPropertyChanged(nameof(Errormessage));
            }
        }

        public bool IsViewVisible

        {
            get
            {
                return _isViewVisible;
            }
            set
            {
                _isViewVisible = value;
                OnPropertyChanged(nameof(IsViewVisible));
            }
        }

        //-> Commands
        public ICommand LoginCommand { get; }
        public ICommand RecoverPasswordCommand { get; }
        public ICommand ShowPasswordCommand { get; }
        public ICommand RememberPasswordCommand { get; }

        //Constructors
        public LoginViewModel()
        {
            UserRepository = new UserRepository();


            LoginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
            RecoverPasswordCommand = new ViewModelCommand(p => ExecuteRecoverPasswordCommand("", ""));


        }

        //Methods
        private bool CanExecuteLoginCommand(object obj)
        {
            bool validData;
            if (string.IsNullOrWhiteSpace(Username) || Username.Length < 3 || Password == null || Password.Length < 3)
            {
                validData = false;
                return validData;
            }
            else
            {
                validData = true;
                return validData;
            }
        }


        private void ExecuteLoginCommand(object obj)
        {
            var isValidUser = UserRepository.AuthenticateUser(new NetworkCredential(Username, Password));
            if (isValidUser)
            {
                Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(Username), null);
                IsViewVisible = false;
            }
            else
            {
                Errormessage = "Invalid username or password";
            }
        }

        private void ExecuteRecoverPasswordCommand(string username, string email)
        {
            throw new NotImplementedException();
        }


    }
}
