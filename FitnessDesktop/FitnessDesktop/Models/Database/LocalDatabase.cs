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
        private static FitnessDataBaseContext LDatabase;
        static LocalDatabase()
        {
            LDatabase = new FitnessDataBaseContext();
        }

        private static async void InitDB()
        {
            String[] tableNames =
            {
                "accountamo", "attributes", "clients", "client_subscription", "files", "	gyms", "images", "img",
                "img_groups", "metrical", "migrations", "orders", "order_product", "password_resets", "personnel",
                "personnel_client", "personnel_rate", "personnel_salary", "productjoinproducts", "products",
                "product_image", "purchase", "purchase_product", "statuses", "subscriptions", "trainings", "types",
                "users", "valueattribute"
            };

            //FitnessDataBaseContext.

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
        }

    }
}
