using BilliardProject.Common;
using BilliardProject.Views;
using System.Windows.Controls;

namespace BilliardProject.ViewModels
{
    public class TablesViewModel : ViewModelBase
    {
        public TablesViewModel()
        {
            IsActivated = DataBlock.Instance.IsActivated;
            PoolEightViewOne = new PoolEightView("1号桌");
            PoolEightViewTwo = new PoolEightView("2号桌");
            PoolEightViewThree = new PoolEightView("3号桌");
            PoolEightViewFour = new PoolEightView("4号桌");
            PoolEightViewFive = new PoolEightView("5号桌");
            PoolEightViewSix = new PoolEightView("6号桌");
            PoolEightViewSeven = new PoolEightView("7号桌");
            SnookerViewOne = new SnookerView("8号桌");
            SnookerViewTwo = new SnookerView("9号桌");
            SnookerViewThree = new SnookerView("10号桌");
            SnookerViewFour = new SnookerView("11号桌");
            PaymentView = new PaymentView();
        }
        #region 绑定的数据
        private bool _isActivated;
        private UserControl? _poolEightViewOne = new PoolEightView("1号桌");
        private UserControl? _poolEightViewTwo = new PoolEightView("2号桌");
        private UserControl? _poolEightViewThree = new PoolEightView("3号桌");
        private UserControl? _poolEightViewFour = new PoolEightView("4号桌");
        private UserControl? _poolEightViewFive = new PoolEightView("5号桌");
        private UserControl? _poolEightViewSix = new PoolEightView("6号桌");
        private UserControl? _poolEightViewSeven = new PoolEightView("7号桌");
        private UserControl? _snookerViewOne = new SnookerView("8号桌");
        private UserControl? _snookerViewTwo = new SnookerView("9号桌");
        private UserControl? _snookerViewThree = new SnookerView("10号桌");
        private UserControl? _snookerViewFour = new SnookerView("11号桌");
        private UserControl? _paymentView = new PaymentView();

        public bool IsActivated
        {
            get { return _isActivated; }
            set
            {
                _isActivated = value;
                onPropertyChanged(nameof(IsActivated));
            }
        }
        public UserControl? PoolEightViewOne
        {
            get { return _poolEightViewOne; }
            set
            {
                _poolEightViewOne = value;
                onPropertyChanged(nameof(PoolEightViewOne));
            }
        }
        public UserControl? PoolEightViewTwo
        {
            get { return _poolEightViewTwo; }
            set
            {
                _poolEightViewTwo = value;
                onPropertyChanged(nameof(PoolEightViewTwo));
            }
        }
        public UserControl? PoolEightViewThree
        {
            get { return _poolEightViewThree; }
            set
            {
                _poolEightViewThree = value;
                onPropertyChanged(nameof(PoolEightViewThree));
            }
        }
        public UserControl? PoolEightViewFour
        {
            get { return _poolEightViewFour; }
            set
            {
                _poolEightViewFour = value;
                onPropertyChanged(nameof(PoolEightViewFour));
            }
        }
        public UserControl? PoolEightViewFive
        {
            get { return _poolEightViewFive; }
            set
            {
                _poolEightViewFive = value;
                onPropertyChanged(nameof(PoolEightViewFive));
            }
        }
        public UserControl? PoolEightViewSix
        {
            get { return _poolEightViewSix; }
            set
            {
                _poolEightViewSix = value;
                onPropertyChanged(nameof(PoolEightViewSix));
            }
        }
        public UserControl? PoolEightViewSeven
        {
            get { return _poolEightViewSeven; }
            set
            {
                _poolEightViewSeven = value;
                onPropertyChanged(nameof(PoolEightViewSeven));
            }
        }
        public UserControl? SnookerViewOne
        {
            get { return _snookerViewOne; }
            set
            {
                _snookerViewOne = value;
                onPropertyChanged(nameof(SnookerViewOne));
            }
        }
        public UserControl? SnookerViewTwo
        {
            get { return _snookerViewTwo; }
            set
            {
                _snookerViewTwo = value;
                onPropertyChanged(nameof(SnookerViewTwo));
            }
        }
        public UserControl? SnookerViewThree
        {
            get { return _snookerViewThree; }
            set
            {
                _snookerViewThree = value;
                onPropertyChanged(nameof(SnookerViewThree));
            }
        }
        public UserControl? SnookerViewFour
        {
            get { return _snookerViewFour; }
            set
            {
                _snookerViewFour = value;
                onPropertyChanged(nameof(SnookerViewFour));
            }
        }
        public UserControl? PaymentView
        {
            get { return _paymentView; }
            set
            {
                _paymentView = value;
                onPropertyChanged(nameof(PaymentView));
            }
        }
        #endregion


    }
}
