using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using FitnessDatabase;

namespace FitnessDatabase.DatabaseStructure
{
    [Table("trainings")]
    class Training:ITable
    {
        [Column("id")]
        public Int32 Id { get; set; }

        [Column("name"), StringLength(255)]
        public String Name { get; set; }

        [Column("description")]
        public String Description { get; set; }

        [Column("gym_id")]
        public Int32 GymID { get; set; }

        [Column("price")]
        public Int32 Price { get; set; }

        [Column("status_id")]
        public Int32 StatusID { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}
