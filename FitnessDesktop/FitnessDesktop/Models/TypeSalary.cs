using System;
using System.Collections.Generic;
using System.Windows;
using FitnessDesktop.Models;

namespace FitnessDesktop.ViewModels
{
    public class TypeSalary : NotificationObject
    {
        public Int32 Index { get; set; }
        public Visibility Flag { get; set; }
        public List<String> ComboBoxItemsTypeSalary { get; set; }
        public List<String> ComboBoxItemsTypeSubscription { get; set; }

        /// <summary>
        /// Инициализация Класса типа зарплаты сотруднику.Процентная ставка или фиксированная, или и то и то.
        /// </summary>
        /// <param name="value"></param>
        public TypeSalary(Int32 value)
        {
            Index                   = value;
            Flag                    = Visibility.Collapsed;
            ComboBoxItemsTypeSalary = new List<String>(new String[] { "Фиксированная зарплата", "Процентная ставка" });
            ComboBoxItemsTypeSubscription =
                new List<String>(new String[]
                {
                    "Обычный абонемент", "Групповые занятия", "Йога"
                }); //В дальнейшем они будут подгружаться автоматически с базы
        }

        #region Изменение типа зарплаты
        private String _selectedSalaryTypeItem;
        public String SelectedSalaryTypeItem
        {
            get { return _selectedSalaryTypeItem; }
            set
            {
                _selectedSalaryTypeItem = value;
                Flag = _selectedSalaryTypeItem.Equals("Процентная ставка")
                    ? Visibility.Visible
                    : Visibility.Collapsed;
                base.RaisePropertyChanged(nameof(Flag));
            }
        }
        #endregion

        /// <summary>
        /// Возвращает уникальный хешкод элемента
        /// </summary>
        /// <returns>Возвращает уникальное число хешкода экземпляра класса</returns>
        public override int GetHashCode()
        {
            return Index ^ DateTime.Now.Millisecond;
        }

        /// <summary>
        /// Сравнивание объектов по интексу(Метод переопределен)
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (this.GetType() != obj.GetType()) return false;

            TypeSalary item = obj as TypeSalary;

            return this.Index.Equals(item.Index);
        }
    }
}