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
    [Table("personnel_client")]
    public class PersonnelClient:ITable
    {
        //Поля для обратной связи(Они не создаются)
        //public Gym gym { get; set; }
        //public Personnel person { get; set; }
        //public Client client { get; set; }
        //public MyType type { get; set; }
        //public Status status { get; set; }
        //
        [Column("id")]
        public Int32 Id { get; set; }

        [Column("gym_id")]
        public Int32 GymID { get; set; }

        [Column("person_id")]
        public Int32 PersonID { get; set; }

        [Column("client_id")]
        public Int32 ClientID { get; set; }

        [Column("price")]
        public Int32 Price { get; set; }

        [Column("type_id")]
        public Int32 TypeID { get; set; }

        [Column("start_date")]
        public DateTime StartDate { get; set; }

        [Column("end_date")]
        public DateTime EndDate { get; set; }

        [Column("status_id")]
        public Int32 StatusID { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}
