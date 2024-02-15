using BilliardProject.Models;
using BilliardProject.Repository;
using BilliardProject.ViewModels;
using BilliardProject.Views;
using System;
using System.Collections.ObjectModel;

namespace BilliardProject.Common
{
    public class DataBlock
    {
        public static DataBlock Instance = new Lazy<DataBlock>(() => new DataBlock()).Value;

        // 全局变量
        public string ConfigKeyPath { get; set; } = AppDomain.CurrentDomain.BaseDirectory + "key.dat";
        public bool IsActivated { get; set; } = false;
        public ObservableCollection<CustomerModel>? CustomerList { get; set; }
        public ObservableCollection<LogModel>? LogList { get; set; }
        public string DbPath { get; set; } = AppDomain.CurrentDomain.BaseDirectory + "billiard.db";


        // Repository
        public CustomerRepository? CustomerRepository { get; set; }
        public LogRepository? LogRepository { get; set; }
        public LoginRepository? LoginRepository { get; set; }


        // View
        public MainWindow? MainWindow { get; set; }
        public TablesView? TablesView { get; set; }
        public MembershipView? MembershipView { get; set; }
        public LogView? LogView { get; set; }
        public SettingView? ThemeSettingView { get; set; }


        // ViewModel
        public PaymentViewModel? PaymentViewModel { get; set; }
        public MembershipViewModel? MembershipViewModel { get; set; }
        public LogViewModel? LogViewModel { get; set; }
        public SettingViewModel? ThemeSettingViewModel { get; set; }
    }
}
