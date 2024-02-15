using BilliardProject.Common;
using BilliardProject.Models;
using System.IO;
using System.Threading.Tasks;
using System.Windows;

namespace BilliardProject.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        public LoginViewModel()
        {

        }

        public BaseCommand Command_Fun
        {
            get { return new BaseCommand(Command_Fun_Executed); }
        }

        private void Command_Fun_Executed(object obj)
        {
            string? str = obj.ToString();
            switch (str)
            {
                case "LoginCommand":
                    Login();
                    break;
                case "RegisterCommand":
                    Register();
                    break;
            }
        }

        private async void Login()
        {
            //User user = await DataBlock.Instance.LoginRepository.Login(Username);
            //if (user is null)
            //{
            //    MessageBox.Show("account doesn't exist");
            //    return;
            //}
            //if (user.Password != Password)
            //{
            //    MessageBox.Show("wrong password");
            //    return;
            //}
            //else
            //{
            //    DataBlock.Instance.MainWindow = new MainWindow();
            //    DataBlock.Instance.MainWindow.ShowDialog();
            //}

            DataBlock.Instance.MainWindow = new MainWindow();
            DataBlock.Instance.MainWindow.ShowDialog();
        }

        private void Register()
        {

        }

        #region Data Binding
        private string _username;
        private string _password;

        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                onPropertyChanged(nameof(Username));
            }
        }
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                onPropertyChanged(nameof(Password));
            }
        }

        #endregion
    }
}
