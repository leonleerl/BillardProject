using BilliardProject.Common;
using BilliardProject.Data;
using BilliardProject.Models;
using BilliardProject.Repository;
using BilliardProject.ViewModels;
using BilliardProject.Views;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace BilliardProject
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            //ReadConfig();
            Init();
        }

        private void ReadConfig()
        {
            if (!File.Exists(DataBlock.Instance.ConfigKeyPath))
            {
                DataBlock.Instance.IsActivated = false;
                return;
            }
            using (var dbContext = new BilliardDbContext())
            {
                dbContext.Database.EnsureCreated();
            }
            using (StreamReader sr = new StreamReader(DataBlock.Instance.ConfigKeyPath))
            {
                string line = sr.ReadToEnd();
                //if (!line.Equals(Tools.EncryptByAES(Tools.GetMACStr())))
                //{
                //    DataBlock.Instance.IsActivated = false;
                //}
                //else
                //{
                //    DataBlock.Instance.IsActivated = true;
                //}
            }
        }

        private async void Init()
        {
            DataBlock.Instance.IsActivated = true;
            DataBlock.Instance.CustomerRepository = new CustomerRepository();
            DataBlock.Instance.LogRepository = new LogRepository();
            DataBlock.Instance.LoginRepository = new LoginRepository();
            IEnumerable<CustomerModel> Customers = await DataBlock.Instance.CustomerRepository.GetAll();
            DataBlock.Instance.CustomerList = Customers.ToObservableCollection();
            IEnumerable<LogModel> logModels = await DataBlock.Instance.LogRepository.GetAll();
            DataBlock.Instance.LogList = logModels.ToObservableCollection();

            DataBlock.Instance.LogView = new LogView();
            DataBlock.Instance.LogViewModel = new LogViewModel();
            DataBlock.Instance.LogView.DataContext = DataBlock.Instance.LogViewModel;


            DataBlock.Instance.PaymentViewModel = new PaymentViewModel();
            DataBlock.Instance.TablesView = new TablesView();

            DataBlock.Instance.MembershipView = new MembershipView();
            DataBlock.Instance.MembershipView = new MembershipView();
            DataBlock.Instance.MembershipViewModel = new MembershipViewModel();
            DataBlock.Instance.MembershipViewModel.CustomerList = DataBlock.Instance.CustomerList;

            DataBlock.Instance.ThemeSettingView = new SettingView();
            DataBlock.Instance.ThemeSettingViewModel = new SettingViewModel();
            DataBlock.Instance.ThemeSettingView.DataContext = DataBlock.Instance.ThemeSettingViewModel;

            //DataBlock.Instance.MainWindow = new MainWindow();


        }
    }
}
