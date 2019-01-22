using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessDesktop.Models
{
    public enum LevelAccess
    {
        SuperAdmin,
        Admin,
        Barmen
    }
    public static class GlobalVar
    {
        public static String GymName { get; private set; }
        public static Int32 GymID { get; private set; }
        public static LevelAccess LevelAccess2 { get; private set; }

        static GlobalVar()
        {
            //Тут мы должны получить из базы название зала и тогдалее
            GymName = "Test";
            GymID = 18;
            LevelAccess2 = LevelAccess.SuperAdmin;

        }
    }
}
