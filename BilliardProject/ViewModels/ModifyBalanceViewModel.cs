using BilliardProject.Common;
using BilliardProject.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace BilliardProject.ViewModels
{
    public class ModifyBalanceViewModel : ViewModelBase
    {
        public ModifyBalanceViewModel()
        {

        }

        public ModifyBalanceViewModel(CustomerModel customerModel)
        {
            CustomerModelSelected = customerModel;
            TableIndex = DataBlock.Instance.PaymentViewModel.TableIndex;
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
                case "ChangeStateCommand":
                    ChangeState();
                    break;
                case "ConfirmCommand":
                    Confirm();
                    break;
            }
        }

        private async void Confirm()
        {
            try
            {
                if (IsChecked) // 扣费状态
                {
                    CustomerModelSelected.Balance -= Money;
                    int res = DataBlock.Instance.CustomerRepository.Update(CustomerModelSelected);
                    if (res == 1)
                    {
                        MessageBox.Show("扣费成功");
                    }
                    else
                    {
                        MessageBox.Show("扣费失败");
                    }
                    string entertainmentType = ConvertTableIndexToName(DataBlock.Instance.LogViewModel.TableIndex);
                    LogModel logModel = new LogModel()
                    {
                        Id = Guid.NewGuid(),
                        Tel = CustomerModelSelected.Tel,
                        EntertainmentType = entertainmentType,
                        TableIndex = DataBlock.Instance.LogViewModel.TableIndex,
                        StartTime = DataBlock.Instance.LogViewModel.StartTime,
                        EndTime = DateTime.Now,
                        Income = Money
                    };
                    DataBlock.Instance.LogRepository.Add(logModel);
                    DataBlock.Instance.LogList.Add(logModel);
                }
                else // 充值状态
                {
                    CustomerModelSelected.Balance += Money;
                    int res = DataBlock.Instance.CustomerRepository.Update(CustomerModelSelected);
                    if (res == 1)
                    {
                        MessageBox.Show("充值成功");
                    }
                    else
                    {
                        MessageBox.Show("充值失败");
                    }
                }
                IEnumerable<CustomerModel> Customers = await DataBlock.Instance.CustomerRepository.GetAll();
                DataBlock.Instance.CustomerList = Customers.ToObservableCollection();
                //Global.MembershipViewModel.CustomerList = Global.CustomerList;
            }
            catch (Exception)
            {
                MessageBox.Show("不正确的数值");
            }
        }

        private string ConvertTableIndexToName(string tableIndex)
        {
            int num;
            string str = tableIndex.Substring(0, tableIndex.Length - 2);
            int.TryParse(str, out num);
            if (1 <= num && num <= 7)
                return "黑八";
            else
                return "斯诺克";

        }

        private void ChangeState()
        {
            if (IsChecked) // 扣费状态
            {
                IsRechargeSelected = Visibility.Collapsed;
                IsDeductSelected = Visibility.Visible;
                BGColor.Color = (Color)ColorConverter.ConvertFromString("#FF7700");
                CloseBtnColor.Color = (Color)ColorConverter.ConvertFromString("White");
            }
            else // 充值状态
            {
                IsRechargeSelected = Visibility.Visible;
                IsDeductSelected = Visibility.Collapsed;
                BGColor.Color = (Color)ColorConverter.ConvertFromString("LightSlateGray");
                CloseBtnColor.Color = (Color)ColorConverter.ConvertFromString("OrangeRed");
            }
        }


        #region 绑定的数据
        private CustomerModel _customerModelSelected;
        private bool _isChecked = false;
        private Visibility _isRechargeSelected = Visibility.Visible;
        private Visibility _isDeductSelected = Visibility.Collapsed;
        private int _money = 0;
        private string _tableIndex;


        private SolidColorBrush _bGColor = new SolidColorBrush()
        {
            Color = (Color)ColorConverter.ConvertFromString("LightSlateGray")
        };
        private SolidColorBrush _closeBtnColor = new SolidColorBrush()
        {
            Color = (Color)ColorConverter.ConvertFromString("OrangeRed")
        };

        public CustomerModel CustomerModelSelected
        {
            get { return _customerModelSelected; }
            set
            {
                _customerModelSelected = value;
                onPropertyChanged(nameof(CustomerModelSelected));
            }
        }
        public bool IsChecked
        {
            get { return _isChecked; }
            set
            {
                _isChecked = value;
                onPropertyChanged(nameof(IsChecked));
            }
        }
        public Visibility IsRechargeSelected
        {
            get { return _isRechargeSelected; }
            set
            {
                _isRechargeSelected = value;
                onPropertyChanged(nameof(IsRechargeSelected));
            }
        }
        public Visibility IsDeductSelected
        {
            get { return _isDeductSelected; }
            set
            {
                _isDeductSelected = value;
                onPropertyChanged(nameof(IsDeductSelected));
            }
        }
        public int Money
        {
            get { return _money; }
            set
            {
                _money = value;
                onPropertyChanged(nameof(Money));
            }
        }
        public SolidColorBrush BGColor
        {
            get { return _bGColor; }
            set
            {
                _bGColor = value;
                onPropertyChanged(nameof(BGColor));
            }
        }
        public SolidColorBrush CloseBtnColor
        {
            get { return _closeBtnColor; }
            set
            {
                _closeBtnColor = value;
                onPropertyChanged(nameof(CloseBtnColor));
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
