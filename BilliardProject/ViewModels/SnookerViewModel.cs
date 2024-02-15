using BilliardProject.Common;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Threading;

namespace BilliardProject.ViewModels
{
    public class SnookerViewModel : ViewModelBase
    {
        public SnookerViewModel(string tableIndex)
        {
            TableIndex = tableIndex;
        }

        public BaseCommand Command_Fun
        {
            get { return new BaseCommand(Command_Fun_Executed); }
        }

        private void Command_Fun_Executed(object obj)
        {
            string str = obj.ToString();
            switch (str)
            {
                case "Start":
                    DoStart();
                    break;
                case "Stop":
                    DoStop();
                    break;
            }
        }

        DispatcherTimer timer = new DispatcherTimer();
        DispatcherTimer timer2 = new DispatcherTimer();

        int sec2 = 1;
        private void DoStart()
        {
            DataBlock.Instance.LogViewModel.StartTime = DateTime.Now;
            DataBlock.Instance.LogViewModel.TableIndex = TableIndex;
            IsStartEnabled = false;
            IsStopEnabled = true;
            if (string.IsNullOrEmpty(ItemSelected))
            {
                timer = new DispatcherTimer();
                timer.Tick += Timer_Tick;
                timer.Interval = TimeSpan.FromSeconds(1);
                timer.Start();
            }
            else
            {
                sec2 = int.Parse(ItemSelected.Substring(0, 1)) * 3600;
                timer2 = new DispatcherTimer();
                timer2.Tick += Timer_Tick2;
                timer2.Interval = TimeSpan.FromSeconds(1);
                timer2.Start();
            }

        }

        private void Timer_Tick2(object? sender, EventArgs e)
        {
            TimeSpan ts = new TimeSpan(0, 0, sec2);
            Time = ts.ToString(@"hh\:mm\:ss");
            int totalSeconds = (int)ts.TotalSeconds;
            if (totalSeconds == 0)
            {
                MessageBox.Show("时间到");
                timer2.Stop();
                return;
            }
            sec2--;
        }

        int sec = 1;
        private void Timer_Tick(object? sender, EventArgs e)
        {

            TimeSpan ts = new TimeSpan(0, 0, sec);
            Time = ts.ToString(@"hh\:mm\:ss");
            sec++;
        }
        int res = 0;
        private void DoStop()
        {
            timer.Stop();
            timer2.Stop();
            if (sec == 1)
            {
                // 处理倒计时
                int startTime;
                int.TryParse(ItemSelected.Substring(0, 1), out startTime);
                res = startTime * 3600 - sec2;
            }
            else
            {
                // 处理顺数时间
                res = sec;
            }
            CalculatePayment(res);
            Time = "";
            IsStartEnabled = true;
            IsStopEnabled = false;
            sec = 1;
        }

        private void CalculatePayment(int res)
        {
            int feihuiyuan = (9 * ((res / 600) + 1));
            int huiyuan = (8 * ((res / 600) + 1));
            DataBlock.Instance.PaymentViewModel.TableIndex = TableIndex;
            DataBlock.Instance.LogViewModel.TableIndex = TableIndex;
            DataBlock.Instance.PaymentViewModel.Feihuiyuan = feihuiyuan;
            DataBlock.Instance.PaymentViewModel.Huiyuan = huiyuan;

            MessageBox.Show($"非会员价：￥{feihuiyuan}，会员价：￥{huiyuan}");
        }
        #region  绑定的数据
        private string _time = "";
        private List<string> _timeLimitation = new List<string> { "", "1", "2", "3", "4", "5", "6" };

        private bool _isStartEnabled = true;
        private bool _isStopEnabled = false;
        private string _itemSelected;
        private string _tableIndex;
        public string Time
        {
            get { return _time; }
            set
            {
                _time = value;
                onPropertyChanged(nameof(Time));
            }
        }
        public List<string> TimeLimitation
        {
            get { return _timeLimitation; }
            set
            {
                _timeLimitation = value;
                onPropertyChanged(nameof(TimeLimitation));
            }
        }
        public bool IsStartEnabled
        {
            get { return _isStartEnabled; }
            set
            {
                _isStartEnabled = value;
                onPropertyChanged(nameof(IsStartEnabled));
            }
        }
        public bool IsStopEnabled
        {
            get { return _isStopEnabled; }
            set
            {
                _isStopEnabled = value;
                onPropertyChanged(nameof(IsStopEnabled));
            }
        }
        public string ItemSelected
        {
            get { return _itemSelected; }
            set
            {
                _itemSelected = value;
                onPropertyChanged(nameof(ItemSelected));
            }
        }
        public string TableIndex
        {
            get { return _tableIndex; }
            set
            {
                _tableIndex = value;
                onPropertyChanged(nameof(TableIndex));
            }
        }
        #endregion
    }
}
