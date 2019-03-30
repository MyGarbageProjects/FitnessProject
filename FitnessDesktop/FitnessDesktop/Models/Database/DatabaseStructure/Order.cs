using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using FitnessDatabase;

namespace FitnessDatabase.DatabaseStructure
{
    [Table("orders")]
    public class Order:ITable
    {
        //Поля для обратной связи(Они не создаются)
        //public Gym gym { get; set; }
        //public Client client { get; set; }
        //public Personnel person { get; set; }
        //public AccountAmo amocmr { get; set; }
        //public Status status { get; set; }
        //
        [Column("id")]
        public Int32 Id { get; set; }

        [Column("gym_id")]
        public Int32 GymID { get; set; }

        [Column("client_id")]
        public Int32 ClientID { get; set; }

        [Column("price")]
        public Double Price { get; set; }

        [Column("money_client")]
        public Double MoneyClient { get; set; }

        [Column("change_to_user")]
        public Double ChangeToUser { get; set; }

        [Column("person_id")]
        public Int32 PersonID { get; set; }

        [Column("amocrm_id")]
        public Int32 AmocrmID { get; set; }

        [Column("status_id")]
        public Int32 StatusID { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}
