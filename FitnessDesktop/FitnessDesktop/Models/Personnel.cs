using System;
using System.Collections.ObjectModel;
using System.Linq;
using FitnessDesktop.Models;

namespace FitnessDesktop.ViewModels
{
    public class Personnel: NotificationObject
    {
        public String Name { get; set; }
        public String Surname { get; set; }
        public String SecondName { get; set; }
        public DateTime BDay { get; set; }
        public String AttachMail { get; set; }
        public ObservableCollection<TypeSalary> SalaryTypeItems { get; set; }

        public DateTime PayrollDate { get; set; }
        public Int32 AmountOfPayment { get; set; }

        public Personnel()
        {
            //BDay = new DateTime(1994, 11,4);
            BDay            = DateTime.Now;
            SalaryTypeItems = new ObservableCollection<TypeSalary>();

            PayrollDate     = DateTime.Now;

        }

        #region Удаление пунтка о зарплате
        private RelayCommand _removeSalaryTypeItem;
        public RelayCommand RemoveSalaryTypeItem
        {
            get
            {
                return _removeSalaryTypeItem ?? (_removeSalaryTypeItem = new RelayCommand(ExecuteRemoveSalaryTypeItem));
            }
        }
        public void ExecuteRemoveSalaryTypeItem(object sender)
        {
            TypeSalary _ts = sender as TypeSalary;
            if (_ts != null)
            {
                SalaryTypeItems.Remove(_ts);
            }
        }
        #endregion
        #region Добавления пунтка о зарплате
        private RelayCommand _addTypeSalaryItem;
        public RelayCommand AddSalaryTypeItem
        {
            get { return _addTypeSalaryItem ?? (_addTypeSalaryItem = new RelayCommand(ExecuteAddSalaryTypeItem)); }
        }
        public void ExecuteAddSalaryTypeItem(object sender)
        {
            if (SalaryTypeItems.Count > 0)
                SalaryTypeItems.Add(new TypeSalary(SalaryTypeItems.Last().Index + 1));
            else
                SalaryTypeItems.Add(new TypeSalary(0));
        }
        #endregion
    }
}