using FitnessDesktop.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using FitnessDesktop.Views;

namespace FitnessDesktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public DisplayRootRegistry displayRootRegistry = new DisplayRootRegistry();
        private MainWindowViewModel mainWindowViewModel;
        public App()//Тут инициализируем окна которые есть в программе
        {
            displayRootRegistry.RegisterWindowType<MainWindowViewModel, MainWindow>();//Главное окно
            displayRootRegistry.RegisterWindowType<StaffEditingWindowViewModel, StaffEditingWindow>();
            //displayRootRegistry.RegisterWindowType<RemoteControlWindowViewModel, RemoteControlWindow>();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            mainWindowViewModel = new MainWindowViewModel();

            await displayRootRegistry.ShowModalPresentation(mainWindowViewModel);

            Shutdown();
        }
    }
}
