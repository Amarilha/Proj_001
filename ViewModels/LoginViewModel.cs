using gerenciamento_NET_wpf.Models;
using gerenciamento_NET_wpf.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using gerenciamento_NET_wpf.Repositories;
using System.Net;
using System.Security.Principal;
using System.Threading;

namespace gerenciamento_NET_wpf.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        //fields
        private string _username;
        private SecureString _password; //private String _password;
        private string _errorMessage;
        private bool _isViewVisible = true;

        private IUserRepository userRepository;


        public string Username 
        { get
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
        public string ErrorMessage 
        { get
            {
                return _errorMessage;
            }
            set 
            { 
                _errorMessage = value; 
                OnPropertyChanged(nameof(ErrorMessage)); 
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

        //->commands
        public ICommand LoginCommand { get; }
        public ICommand RecoverPasswordCommand { get; }
        public ICommand ShowPasswordCommand { get; }
        public ICommand RememberPasswordCommand { get; }

        //Constructor
        public LoginViewModel()
        {
            userRepository = new UserRepository();
            LoginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
            RecoverPasswordCommand = new ViewModelCommand(p => ExecuteRecoverPassCommand("", ""));
        }



        private bool CanExecuteLoginCommand(object obj)
        {
            bool validData;
            if (string.IsNullOrWhiteSpace(Username) || Username.Length < 3 ||
                Password == null || Password.Length < 3)
                validData = false;
            else
                validData = true;
            return validData;
        }

        private void ExecuteLoginCommand(object obj)
        {
            var isValidUser = userRepository.AuthenticateUser(new NetworkCredential(Username,Password)); 
            if (isValidUser)
            {
                Thread.CurrentPrincipal = new GenericPrincipal(
                    new GenericIdentity(Username), null);
                IsViewVisible = false;
            }
            else
            {
                ErrorMessage= "* Invalid username or password";
            }
        }

        private void ExecuteRecoverPassCommand(string username, string email)
        {
            throw new NotImplementedException();
        }

    }
}

