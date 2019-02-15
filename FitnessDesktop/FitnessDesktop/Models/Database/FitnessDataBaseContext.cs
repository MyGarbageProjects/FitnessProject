using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  System.Data.Entity;
using System.IO;
using System.Reflection;
using FitnessDatabase.DatabaseStructure;
using Attribute = FitnessDatabase.DatabaseStructure.Attribute;
using File = FitnessDatabase.DatabaseStructure.File;

namespace FitnessDatabase
{
    public class FitnessDataBaseContext: DbContext
    {
        public readonly DateTime DateTimeMinValue = new DateTime(1753, 01, 01, 0, 00, 00);
        public static readonly String DBConnection = $"Data Source = {Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\Fitness.sdf";
        public FitnessDataBaseContext() : base(DBConnection)
        {
            
        }

        public DbSet<UpdateDataInfo> UpdateDataInfo { get; set; }
        public DbSet<AccountAmo> AccountsAmo { get; set; }
        public DbSet<Attribute> Attributes { get; set; }
        public DbSet<Client> Clients { get; set; }
        //public DbSet<ClientSubscription> ClientsSubscription { get; set; }
        //public DbSet<File> Files { get; set; }
        //public DbSet<Gym> Gyms { get; set; }
        //public DbSet<Image> Images { get; set; }
        //public DbSet<Img> Imgs { get; set; }
        //public DbSet<ImgGroup> ImgGroups { get; set; }
        //public DbSet<Metrical> Metricals { get; set; }
        //public DbSet<Order> Orders { get; set; }
        //public DbSet<OrderProduct> OrderProducts { get; set; }
        //public DbSet<PasswordReset> PasswordResets { get; set; }
        public DbSet<Personnel> Personnels { get; set; }
        //public DbSet<PersonnelClient> PersonnelClients { get; set; }
        //public DbSet<PersonnelRate> PersonnelRates { get; set; }
        //public DbSet<PersonnelSalary> PersonnelSalaries { get; set; }
        //public DbSet<Product> Products { get; set; }
        //public DbSet<ProductImage> ProductsImage { get; set; }
        //public DbSet<Productjoinproduct> Productsjoinproduct { get; set; }
        //public DbSet<Purchase> Purchases { get; set; }
        //public DbSet<PurchaseProduct> PurchasesProducts { get; set; }
        //public DbSet<Status> Statuses { get; set; }
        //public DbSet<Subscription> Subscriptions { get; set; }
        //public DbSet<Training> Trainings { get; set; }
        //public DbSet<MyType> Types { get; set; }
        //public DbSet<User> Users { get; set; }
        //public DbSet<ValueAttribute> ValueAttributes { get; set; }
    }
}
