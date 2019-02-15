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
    [Table("attributes")]
    public class Attribute:ITable
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name"), StringLength(255)]
        public String Name { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}
