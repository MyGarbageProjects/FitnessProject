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
    [Table("metrical")]
    public class Metrical:ITable
    {
        //Поля для обратной связи(Они не создаются)
        //public Status status { get; set; }
        //
        [Column("id")]
        public Int32 Id { get; set; }

        [Column("name"), StringLength(1000)]
        public String Name { get; set; }

        [Column("small_name"), StringLength(255)]
        public String SmallName { get; set; }

        [Column("code")]
        public Int32 Code { get; set; }

        [Column("status_id")]
        public Int32 StatusID { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}
