using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessDatabase;

namespace FitnessDatabase.DatabaseStructure
{
    [Table("gyms")]
    class Gym:ITable
    {
        [Column("id")]
        public Int32 Id { get; set; }

        [Column("user_id")]
        public Int32 UserID { get; set; }

        [Column("name"), StringLength(255)]
        public String Name { get; set; }

        [Column("address"), StringLength(255)]
        public String Address { get; set; }

        [Column("status_id")]
        public Int32 StatudID { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}
