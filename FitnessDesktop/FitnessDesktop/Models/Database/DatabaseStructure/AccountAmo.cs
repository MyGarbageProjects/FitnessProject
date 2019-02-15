using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessDatabase;

namespace FitnessDatabase.DatabaseStructure
{
    [Table("accountAmo")]
    public class AccountAmo : ITable
    {
        [Column("id")]
        public Int32 Id { get; set; }

        [Column("gym_id")]
        public Int32 GymID { get; set; }

        [Column("host"), StringLength(255)]
        public String Host { get; set; }

        [Column("login"), StringLength(255)]
        public String Login { get; set; }

        [Column("api_key"), StringLength(255)]
        public String APIkey { get; set; }

        [Column("status_id")]
        public Int32 StatusID { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}
