using BilliardProject.Common;
using BilliardProject.Models;
using System.Windows;
using System.Windows.Input;

namespace BilliardProject.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void Button_ClickClose(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private async void Login_Click(object sender, RoutedEventArgs e)
        {
            //User user = await DataBlock.Instance.LoginRepository.Login(tbUsername.Text);
            //if (user is null)
            //{
            //    MessageBox.Show("account doesn't exist");
            //    return;
            //}
            //if (user.Password != tbPassword.Password)
            //{
            //    MessageBox.Show("wrong password");
            //    return;
            //}

            //else
            //{
            DataBlock.Instance.MainWindow = new MainWindow();
            DataBlock.Instance.MainWindow.ShowDialog();
            this.Close();
            //}
        }

    }
}
