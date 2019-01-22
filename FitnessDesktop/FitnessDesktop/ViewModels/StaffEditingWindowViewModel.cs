using System;
using System.Collections;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using FitnessDesktop.Models;

namespace FitnessDesktop.ViewModels
{
    class StaffEditingWindowViewModel : Personnel
    {

        public DelegateCommand WindowLoadedCommand { get; private set; }
        public String NameGym { get; set; }

        #region Кнопка закрытия окна
        private RelayCommand _closeWindow;
        public RelayCommand CloseWindow
        {
            get
            {
                return _closeWindow ?? (_closeWindow = new RelayCommand(ExecuteCloseWindow));
            }
        }
        public void ExecuteCloseWindow(object sender)
        {
            (Application.Current as App).displayRootRegistry.CloseWindow(GetHashCode());
        }
        #endregion

        #region Кнопка сохранения изменений
        private RelayCommand _savingСhanges;
        public RelayCommand SavingСhanges
        {
            get
            {
                return _savingСhanges ?? (_savingСhanges = new RelayCommand(ExecuteSavingСhanges));
            }
        }
        public void ExecuteSavingСhanges(object sender)
        {
            //Тут мы сохраняем все дерьмо что изменили

            Notifications.MessageInformation("Изменения сохранены");
            ExecuteCloseWindow(null); //И закрываем
        }
        #endregion

        private void ExecuteWindowLoaded(object obj)
        {
            Notifications.MessageBox("Окно загрузилось, просто тест");
        }

        public StaffEditingWindowViewModel()
        {
            WindowLoadedCommand = new DelegateCommand(ExecuteWindowLoaded);
            NameGym = $"Персонал финтес центра {GlobalVar.GymName}";
        }
    }
}
