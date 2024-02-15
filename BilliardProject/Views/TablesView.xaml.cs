using BilliardProject.ViewModels;
using System.Windows.Controls;

namespace BilliardProject.Views
{
    /// <summary>
    /// Interaction logic for TablesView.xaml
    /// </summary>
    public partial class TablesView : UserControl
    {
        public TablesView()
        {
            InitializeComponent();
            this.DataContext = new TablesViewModel();
        }
    }
}
