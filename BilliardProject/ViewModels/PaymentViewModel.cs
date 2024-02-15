namespace BilliardProject.ViewModels
{
    public class PaymentViewModel : ViewModelBase
    {
        public PaymentViewModel()
        {

        }

        #region 绑定的数据
        private int _feihuiyuan = 0;
        private int _huiyuan = 0;
        private string _tableIndex = "";

        public int Feihuiyuan
        {
            get { return _feihuiyuan; }
            set
            {
                _feihuiyuan = value;
                onPropertyChanged(nameof(Feihuiyuan));
            }
        }
        public int Huiyuan
        {
            get { return _huiyuan; }
            set
            {
                _huiyuan = value;
                onPropertyChanged(nameof(Huiyuan));
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
