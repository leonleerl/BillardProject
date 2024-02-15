using BilliardProject.Common;
using System.Windows.Controls;

namespace BilliardProject.Views
{
    /// <summary>
    /// Interaction logic for PaymentView.xaml
    /// </summary>
    public partial class PaymentView : UserControl
    {
        public PaymentView()
        {
            InitializeComponent();
            this.DataContext = DataBlock.Instance.PaymentViewModel;
        }
    }
}
