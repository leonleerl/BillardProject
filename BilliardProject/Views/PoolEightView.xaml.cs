using BilliardProject.ViewModels;
using System.Windows.Controls;

namespace BilliardProject.Views
{
    /// <summary>
    /// Interaction logic for PoolEightView.xaml
    /// </summary>
    public partial class PoolEightView : UserControl
    {
        public PoolEightView()
        {
            InitializeComponent();
        }
        public PoolEightView(string tableIndex)
        {
            InitializeComponent();
            //DataBlock.Instance.PoolEightViewModel = new PoolEightViewModel(tableIndex);
            this.DataContext = new PoolEightViewModel(tableIndex);
        }
    }
}
