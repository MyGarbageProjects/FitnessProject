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
    [Table("img")]
    class Img:ITable
    {
        [Column("id")]
        public Int32 Id { get; set; }

        [Column("group_id"), Required]
        public Int32 GroupID { get; set; }

        [Column("path"), StringLength(255)]
        public String Path { get; set; }

        [Column("size_x")]
        public Int32? SizeX { get; set; }

        [Column("size_y")]
        public Int32? SizeY { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}
