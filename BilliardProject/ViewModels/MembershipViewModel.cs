using BilliardProject.Common;
using BilliardProject.Models;
using BilliardProject.Views;
using System;
using System.Collections.ObjectModel;
using System.Security.Cryptography.X509Certificates;
using System.Windows;
using System.Windows.Controls;

namespace BilliardProject.ViewModels
{
    public class MembershipViewModel : ViewModelBase
    {
        public MembershipViewModel()
        {
            IsActivated = DataBlock.Instance.IsActivated;
            CustomerList = DataBlock.Instance.CustomerList;
            TempCustomerList = new ObservableCollection<CustomerModel>();
        }

        public BaseCommand Command_Fun
        {
            get => new BaseCommand(Command_Fun_Executed);
        }

        public BaseCommand DataGrid_Command_Fun
        {
            get => new BaseCommand(DataGrid_Command_Fun_Executed);
        }

        private void Command_Fun_Executed(object obj)
        {
            string str = obj.ToString();
            switch (str)
            {
                case "AddNewCustomerCommand":
                    AddNewCustomer();
                    break;
                case "SearchCommand":
                    Search();
                    break;
                case "RefreshCommand":
                    Refresh();
                    break;
            }
        }

        private void Refresh()
        {
            CustomerList = DataBlock.Instance.CustomerList;
        }

        private void DataGrid_Command_Fun_Executed(object obj)
        {
            DataGrid dataGrid = obj as DataGrid;
            CustomerModel customer = dataGrid.SelectedItem as CustomerModel;
            ModifyBalanceView modifyBalanceView = new ModifyBalanceView(customer);
            modifyBalanceView.ShowDialog();
        }

        private void Search()
        {
            TempCustomerList.Clear();
            if (string.IsNullOrEmpty(SearchContent))
            {
                CustomerList = DataBlock.Instance.CustomerList;
                return;
            }
            foreach (CustomerModel item in DataBlock.Instance.CustomerList)
            {
                if (item.Tel.Substring(7, 4).Contains(SearchContent))
                {
                    TempCustomerList.Add(item);
                }
            }
           
            CustomerList = TempCustomerList;
        }
        private void AddNewCustomer()
        {
            if (string.IsNullOrEmpty(Tel) || Tel.Length != 11)
            {
                Tel = "";
                InitialBanlance = "";
                MessageBox.Show("电话号码为11位", "温馨提示");
                return;
            }
            if (string.IsNullOrEmpty(InitialBanlance))
            {
                Tel = "";
                InitialBanlance = "";
                MessageBox.Show("金额不能为空", "温馨提示");
                return;
            }
            if (InitialBanlance.Length > 6)
            {
                MessageBox.Show("数值过大");
                return;
            }
            CustomerModel customer = new CustomerModel()
            {
                Id = Guid.NewGuid(),
                Tel = Tel,
                JoinDate = DateTime.Now,
                Balance = int.Parse(InitialBanlance)
            };
            CustomerList.Add(customer);
            int res = DataBlock.Instance.CustomerRepository.Add(customer);
            if (res == 1)
                MessageBox.Show("添加成功");
            else
                MessageBox.Show("添加失败");
            Tel = string.Empty;
            InitialBanlance = string.Empty;

        }

        #region 绑定的数据
        private bool _isActivated;
        private ObservableCollection<CustomerModel>? _customerList;
        private string? _tel;
        private string? _initialBanlance;
        private string? _searchContent;
        private ObservableCollection<CustomerModel>? _tempCustomerList;
        public bool IsActivated
        {
            get { return _isActivated; }
            set
            {
                _isActivated = value;
                onPropertyChanged(nameof(IsActivated));
            }
        }

        public ObservableCollection<CustomerModel>? CustomerList
        {
            get { return _customerList; }
            set
            {
                _customerList = value;
                onPropertyChanged(nameof(CustomerList));
            }
        }
        public string? Tel
        {
            get { return _tel; }
            set
            {
                _tel = value;
                onPropertyChanged(nameof(Tel));
            }
        }
        public string? InitialBanlance
        {
            get { return _initialBanlance; }
            set
            {
                _initialBanlance = value;
                onPropertyChanged(nameof(InitialBanlance));
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
        public ObservableCollection<CustomerModel>? TempCustomerList
        {
            get { return _tempCustomerList; }
            set
            {
                _tempCustomerList = value;
                onPropertyChanged(nameof(TempCustomerList));
            }
        }
        #endregion

    }
}
