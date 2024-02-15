using BilliardProject.Models;
using BilliardProject.ViewModels;
using System.Windows;
using System.Windows.Input;

namespace BilliardProject.Views
{
    /// <summary>
    /// Interaction logic for ModifyBalanceView.xaml
    /// </summary>
    public partial class ModifyBalanceView : Window
    {
        public ModifyBalanceView()
        {
            InitializeComponent();
        }

        public ModifyBalanceView(CustomerModel customerModel)
        {
            InitializeComponent();
            this.DataContext = new ModifyBalanceViewModel(customerModel);
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
