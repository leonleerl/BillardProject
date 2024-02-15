using BilliardProject.ViewModels;
using System.Windows.Controls;

namespace BilliardProject.Views
{
    /// <summary>
    /// Interaction logic for SnookerView.xaml
    /// </summary>
    public partial class SnookerView : UserControl
    {
        public SnookerView()
        {
            InitializeComponent();
        }
        public SnookerView(string tableIndex)
        {
            InitializeComponent();
            //DataBlock.Instance.SnookerViewModel = new SnookerViewModel(tableIndex);
            this.DataContext = new SnookerViewModel(tableIndex);
        }
    }
}
