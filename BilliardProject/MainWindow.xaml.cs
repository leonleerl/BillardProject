using BilliardProject.ViewModels;
using BilliardProject.Views;
using System.Windows;
using System.Windows.Input;

namespace BilliardProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainWindowViewModel();
        }

        private void Button_ClickClose(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private bool IsMaximize = false;
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                if (IsMaximize)
                {
                    this.WindowState = WindowState.Normal;
                    this.Width = 1200;
                    this.Height = 800;
                    IsMaximize = false;
                }
                else
                {
                    this.WindowState = WindowState.Maximized;
                    IsMaximize = true;
                }
            }
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void Click_Hide(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Click_ChangeState(object sender, RoutedEventArgs e)
        {
            if (IsMaximize)
            {
                this.WindowState = WindowState.Normal;
                this.Width = 1000;
                this.Height = 800;
                IsMaximize = false;
            }
            else
            {
                this.WindowState = WindowState.Maximized;
                IsMaximize = true;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ActivateView activateView = new ActivateView();
            activateView.ShowDialog();
        }
    }
}
