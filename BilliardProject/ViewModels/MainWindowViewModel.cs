using BilliardProject.Common;
using System.Windows;
using System.Windows.Controls;

namespace BilliardProject.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            if (!DataBlock.Instance.IsActivated)
            {
                IsActivated = Visibility.Visible;
            }
            else
            {
                IsActivated = Visibility.Collapsed;
            }
            CurrentView = DataBlock.Instance.MembershipView;
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
                case "ShowMembership":
                    CurrentView = DataBlock.Instance.TablesView;
                    break;
                case "ShowTables":
                    CurrentView = DataBlock.Instance.MembershipView;
                    break;
                case "ShowLog":
                    CurrentView = DataBlock.Instance.LogView;
                    break;
                case "ThemeSetting":
                    CurrentView = DataBlock.Instance.ThemeSettingView;
                    break;
            }
        }


        #region 绑定的数据
        private UserControl? _currentView;
        private Visibility _isActivated;

        public UserControl? CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                onPropertyChanged(nameof(CurrentView));
            }
        }
        public Visibility IsActivated
        {
            get { return _isActivated; }
            set
            {
                _isActivated = value;
                onPropertyChanged(nameof(IsActivated));
            }
        }

    }
    #endregion

}
