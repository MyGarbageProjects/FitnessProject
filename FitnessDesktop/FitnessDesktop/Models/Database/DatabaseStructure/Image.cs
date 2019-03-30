using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace FitnessDatabase.DatabaseStructure
{
    [Table("images")]
    public class Image:ITable
    {
        //Поля для обратной связи(Они не создаются)
        //public Status status { get; set; }
        //

        [Column("id")]
        public int Id { get; set; }

        [Column("path"), MaxLength(255)]
        public String Path { get; set; }

        [Column("status_id")]
        public Int32 StatusID { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}
