using BilliardProject.Common;
using BilliardProject.Enum;
using BilliardProject.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace BilliardProject.ViewModels
{
    public class LogViewModel : ViewModelBase
    {
        public LogViewModel()
        {
            LogList = DataBlock.Instance.LogList;
            TempList = new ObservableCollection<LogModel>();
            Category = System.Enum.GetNames(typeof(LogCategory));
            SelectedItem = "电话号码";
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
                case "RefreshCommand":
                    RefreshAsync();
                    break;
                case "SearchCommand":
                    Search(SelectedItem);
                    break;
            }
        }

        private void Search(string selectedItem)
        {
            TempList.Clear();
            if (string.IsNullOrEmpty(SearchContent))
            {
                LogList = DataBlock.Instance.LogList;
                return;
            }
            if (selectedItem == "电话号码")
            {
                foreach (var item in DataBlock.Instance.LogList)
                {
                    string tel = item.Tel.Substring(0, 3) + item.Tel.Substring(7, 4);
                    if (tel.Contains(SearchContent))
                        TempList.Add(item);
                }
                LogList = TempList;
                return;
            }
            if (selectedItem == "项目类型")
            {
                foreach (var item in DataBlock.Instance.LogList)
                {
                    if (item.EntertainmentType == SearchContent)
                        TempList.Add(item);
                }
                LogList = TempList;
                return;
            }
            if (selectedItem == "桌号")
            {
                foreach (var item in DataBlock.Instance.LogList)
                {
                    if (item.TableIndex.Contains(SearchContent))
                        TempList.Add(item);
                }
                LogList = TempList;
                return;
            }
            if (selectedItem == "时间")
            {
                foreach (var item in DataBlock.Instance.LogList)
                {
                    string startTime = item.StartTime.ToString();
                    string endTime = item.EndTime.ToString();
                    if (startTime.Contains(SearchContent) || endTime.Contains(SearchContent))
                        TempList.Add(item);
                }
                LogList = TempList;
                return;
            }
        }


        private async Task RefreshAsync()
        {
            IEnumerable<LogModel> logModels = await DataBlock.Instance.LogRepository.GetAll();
            LogList = logModels.ToObservableCollection();
            DataBlock.Instance.LogList = LogList;
        }

        #region 绑定的数据
        private ObservableCollection<LogModel> _logList;
        private ObservableCollection<LogModel> _tempList;
        private string _selectedItem;
        private string[] _category;
        private string _searchContent;
        private string? _tel;
        //private string? _entertainmentType;
        private string? _tableIndex;
        private DateTime? _startTime;
        private DateTime? _endTime;
        private int _income;

        public ObservableCollection<LogModel> LogList
        {
            get { return _logList; }
            set
            {
                _logList = value;
                onPropertyChanged(nameof(LogList));
            }
        }
        public ObservableCollection<LogModel> TempList
        {
            get { return _tempList; }
            set
            {
                _tempList = value;
                onPropertyChanged(nameof(TempList));
            }
        }
        public string SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                onPropertyChanged(nameof(SelectedItem));
            }
        }
        public string[] Category
        {
            get { return _category; }
            set
            {
                _category = value;
                onPropertyChanged(nameof(Category));
            }
        }
        public string? SearchContent
        {
            get { return _searchContent; }
            set
            {
                _searchContent = value;
                onPropertyChanged(nameof(SearchContent));
            }
        }
        public string Tel
        {
            get { return _tel; }
            set
            {
                _tel = value;
                onPropertyChanged(nameof(Tel));
            }
        }
        //public string EntertainmentType
        //{
        //    get { return _entertainmentType; }
        //    set
        //    {
        //        _entertainmentType = value;
        //        onPropertyChanged(nameof(EntertainmentType));
        //    }
        //}
        public string TableIndex
        {
            get { return _tableIndex; }
            set
            {
                _tableIndex = value;
                onPropertyChanged(nameof(TableIndex));
            }
        }
        public DateTime? StartTime
        {
            get { return _startTime; }
            set
            {
                _startTime = value;
                onPropertyChanged(nameof(StartTime));
            }
        }
        public DateTime? EndTime
        {
            get { return _endTime; }
            set
            {
                _endTime = value;
                onPropertyChanged(nameof(EndTime));
            }
        }
        public int Income
        {
            get { return _income; }
            set
            {
                _income = value;
                onPropertyChanged(nameof(Income));
            }
        }

        #endregion
    }
}
