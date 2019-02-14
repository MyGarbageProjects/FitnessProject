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
    [Table("files")]
    class File:ITable
    {
        [Column("id")]
        public int Id { get; set; }
            
        [Column("path"), StringLength(255)]
        public String Path { get; set; }

        [Column("name"), StringLength(255)]
        public String Name { get; set; }

        [Column("description")]
        public String Description { get; set; }

        [Column("table"), StringLength(255)]
        public String Table { get; set; }

        [Column("record_id")]
        public int RecordID { get; set; }

        [Column("status")]
        public int Status { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}
