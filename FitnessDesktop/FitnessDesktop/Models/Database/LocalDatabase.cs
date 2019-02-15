using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessDatabase.DatabaseStructure;

namespace FitnessDatabase
{
    public static class LocalDatabase
    {
        public static FitnessDataBaseContext LDatabase;
        static LocalDatabase()
        {
            LDatabase = new FitnessDataBaseContext();
        }

        /// <summary>
        /// Инициализируем базу данных, и заполняем таблицу UpdateDataInfo данными, и последними обновлениями
        /// </summary>
        public static async void InitDB()
        {
            if (!System.IO.File.Exists(FitnessDataBaseContext.DBConnection.Remove(0,14)))
            {
                String[] tableNames =
                {
                    "accountamo", "attributes", "clients", "client_subscription", "files", "	gyms", "images", "img",
                    "img_groups", "metrical", "migrations", "orders", "order_product", "password_resets", "personnel",
                    "personnel_client", "personnel_rate", "personnel_salary", "productjoinproducts", "products",
                    "product_image", "purchase", "purchase_product", "statuses", "subscriptions", "trainings", "types",
                    "users", "valueattribute"
                };

                //Заполняем список таблиц
                using (FitnessDataBaseContext fdbc = new FitnessDataBaseContext())
                {
                    for (int i = 0; i < tableNames.Length; i++)
                    {
                        UpdateDataInfo udi = new UpdateDataInfo
                        {
                            TableName          = tableNames[i],
                            LastID             = -1,
                            LastUpdateDateTime = fdbc.DateTimeMinValue,
                            CreatedAt          = DateTime.Now,
                            UpdatedAt          = DateTime.Now,
                        };

                        fdbc.UpdateDataInfo.Add(udi);
                    }

                    await fdbc.SaveChangesAsync();
                }

                //Тут пишем код синхранизации с основной базой уот так уот бля
            }
        }

        public async static Task<List<Personnel>> getAllPersonnelAsync()
        {
            await Task.Run(() =>
            {
                List<Personnel> personnels = new List<Personnel>();
                using (FitnessDataBaseContext fdbc = new FitnessDataBaseContext())
                {
                    personnels = fdbc.Personnels.Local;
                    fdbc.SaveChanges();
                }
                return personnels;
            });
        }
    }
}
