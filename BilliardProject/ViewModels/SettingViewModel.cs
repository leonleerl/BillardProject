using BilliardProject.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace BilliardProject.ViewModels
{
    public class SettingViewModel : ViewModelBase
    {
        public SettingViewModel()
        {
            LeftParenthesis = "(";
            RightParenthesis = ")";
            LeftParenthesisVisibility = Visibility.Collapsed;
            CountDownVisibility = Visibility.Collapsed;
            RightParenthesisVisibility = Visibility.Collapsed;
        }

        public BaseCommand Command_Fun
        {
            get { return new BaseCommand(Command_Fun_Executed); }
        }

        private void Command_Fun_Executed(object obj)
        {
            string? str = obj.ToString();
            switch (str)
            {
                case "ShutdownTimeChangedCommand":
                    ShutdownTimeChanged();
                    break;
            }
        }

        private DispatcherTimer timer;
        private int sec = 0;
        private void ShutdownTimeChanged()
        {
            if (IsShutdownChecked)
            {
                if (ShutdownTime <= 0 || ShutdownTime > 24)
                {
                    MessageBox.Show("自动关机时间为1-24小时");
                    return;
                }
                sec = ShutdownTime * 3600;
                timer = new DispatcherTimer();
                timer.Tick += Timer_Tick;
                timer.Interval = TimeSpan.FromSeconds(1);
                timer.Start();
                Tools.ShutdownPC(false, (uint)ShutdownTime * 3600);
            }
            else
            {
                timer.Stop();
                CountDown = string.Empty;
                LeftParenthesisVisibility = Visibility.Collapsed;
                CountDownVisibility = Visibility.Collapsed;
                RightParenthesisVisibility = Visibility.Collapsed;
                Tools.ShutdownPC(true, default);
            }
        }


        private void Timer_Tick(object? sender, EventArgs e)
        {

            TimeSpan ts = new TimeSpan(0, 0, sec);
            CountDown = ts.ToString(@"hh\:mm\:ss");
            LeftParenthesisVisibility = Visibility.Visible;
            CountDownVisibility = Visibility.Visible;
            RightParenthesisVisibility = Visibility.Visible;
            sec--;
        }


        #region 绑定的数据
        private int _shutdownTime;
        private bool _isShutdownChecked;
        private string _leftParenthesis;
        private string _countDown;
        private string _rightParenthesis;
        private Visibility _leftParenthesisVisibility;
        private Visibility _countDownVisibility;
        private Visibility _rightParenthesisVisibility;

        public int ShutdownTime
        {
            get { return _shutdownTime; }
            set
            {
                _shutdownTime = value;
                onPropertyChanged(nameof(ShutdownTime));
            }
        }
        public bool IsShutdownChecked
        {
            get { return _isShutdownChecked; }
            set
            {
                _isShutdownChecked = value;
                onPropertyChanged(nameof(IsShutdownChecked));
            }
        }
        public string LeftParenthesis
        {
            get { return _leftParenthesis; }
            set
            {
                _leftParenthesis = value;
                onPropertyChanged(nameof(LeftParenthesis));
            }
        }
        public string CountDown
        {
            get { return _countDown; }
            set
            {
                _countDown = value;
                onPropertyChanged(nameof(CountDown));
            }
        }
        public string RightParenthesis
        {
            get { return _rightParenthesis; }
            set
            {
                _rightParenthesis = value;
                onPropertyChanged(nameof(RightParenthesis));
            }
        }
        public Visibility LeftParenthesisVisibility
        {
            get { return _leftParenthesisVisibility; }
            set
            {
                _leftParenthesisVisibility = value;
                onPropertyChanged(nameof(LeftParenthesisVisibility));
            }
        }
        public Visibility CountDownVisibility
        {
            get { return _countDownVisibility; }
            set
            {
                _countDownVisibility = value;
                onPropertyChanged(nameof(CountDownVisibility));
            }
        }
        public Visibility RightParenthesisVisibility
        {
            get { return _rightParenthesisVisibility; }
            set
            {
                _rightParenthesisVisibility = value;
                onPropertyChanged(nameof(RightParenthesisVisibility));
            }
        }
        #endregion

    }
}
