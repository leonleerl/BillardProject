using BilliardProject.Common;
using System.IO;
using System.Windows;

namespace BilliardProject.Views
{
    /// <summary>
    /// Interaction logic for ActivateView.xaml
    /// </summary>
    public partial class ActivateView : Window
    {
        public ActivateView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //txtSequence.Text = Tools.GetMACStr();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //if (txtActivate.Text == Tools.EncryptByAES(Tools.GetMACStr()))
            //{
            //    using (StreamWriter sr = new StreamWriter(DataBlock.Instance.ConfigKeyPath))
            //    {
            //        sr.Write(txtActivate.Text);
            //    }
            //    MessageBox.Show("恭喜您，注册成功！请重启软件", "温馨提示");
            //}
            //else
            //    MessageBox.Show("请输入正确的注册码", "温馨提示");
        }
    }
}
