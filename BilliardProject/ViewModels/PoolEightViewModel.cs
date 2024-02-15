using BilliardProject.Common;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Threading;

namespace BilliardProject.ViewModels
{
    public class PoolEightViewModel : ViewModelBase
    {

        DispatcherTimer timer = new DispatcherTimer();
        DispatcherTimer timer2 = new DispatcherTimer();

        int sec = 1; // 在变，用于顺数
        int sec2 = 1; // 在变，用于倒数
        int sec3 = 0; // 不变，表示倒计时的总秒数，例如一开始选择2小时，则sec3始终为 2 * 3600 = 7200

        public PoolEightViewModel(string tableIndex)
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

        private void DoStart()
        {
            DataBlock.Instance.LogViewModel.StartTime = DateTime.Now;
            DataBlock.Instance.LogViewModel.TableIndex = TableIndex;
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
                sec3 = sec;
                timer2 = new DispatcherTimer();
                timer2.Tick += Timer_Tick2;
                timer2.Interval = TimeSpan.FromSeconds(1);
                timer2.Start();
            }
            IsStartEnabled = false;
            //IsStopEnabled = true;
        }

        private void Timer_Tick2(object? sender, EventArgs e)
        {
            if (sec <= 2)
            {
                IsStopEnabled = false;
            }
            IsStopEnabled = true;
            TimeSpan ts = new TimeSpan(0, 0, sec2);
            Time = ts.ToString(@"hh\:mm\:ss");
            int totalSeconds = (int)ts.TotalSeconds;
            if (totalSeconds == 0)
            {
                timer2.Stop();
                MessageBox.Show("时间到");
                CalculatePayment(sec3);
                // 此处可以添加硬件操控代码，例如关闭对应桌号的灯或者广播提示

                return;
            }
            sec2--;
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            if (sec <= 2)
            {
                IsStopEnabled = false;
            }
            IsStopEnabled = true;
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
            int feihuiyuan = (6 * ((res / 600) + 1));
            int huiyuan = (5 * ((res / 600) + 1));
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
        private string _itemSelected = "";
        private string _tableIndex = "";
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
