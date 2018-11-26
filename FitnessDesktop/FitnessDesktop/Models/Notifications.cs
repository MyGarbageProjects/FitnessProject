using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessDesktop.Models
{
    static class Notifications
    {
        public static void MessageBox(string msg)
        {
            System.Windows.MessageBox.Show(msg);//Это нарушает MVVM, переделать на свой класс!!!!.
        }
    }
}
