using BilliardProject.ViewModels;
using System.Windows.Controls;

namespace BilliardProject.Views
{
    /// <summary>
    /// Interaction logic for MembershipView.xaml
    /// </summary>
    public partial class MembershipView : UserControl
    {
        public MembershipView()
        {
            InitializeComponent();
            //this.DataContext = Global.MembershipViewModel;
            this.DataContext = new MembershipViewModel();
        }
    }
}
