using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FitnessDesktop.Models
{
    static class Notifications
    {
        public static void MessageBox(string msg)
        {
            System.Windows.MessageBox.Show(msg);//Это нарушает MVVM, переделать на свой класс!!!!.
        }

        public static void MessageError(string msg)
        {
            System.Windows.MessageBox.Show(msg,"Ошибка", MessageBoxButton.OK, MessageBoxImage.Error); //Это нарушает MVVM, переделать на свой класс!!!!.
        }

        public static bool MessageQuestion(string question, string caption)
        {
            if (System.Windows.MessageBox.Show(question, caption, MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                return true;
            return false;
        }

        public static void MessageInformation(string text, string caption="")
        {
            System.Windows.MessageBox.Show(text, caption, MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
