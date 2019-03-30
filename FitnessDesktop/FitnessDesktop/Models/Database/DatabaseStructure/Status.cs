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
    [Table("statuses")]
    public class Status:ITable
    {
        [Column("id")]
        public Int32 Id { get; set; }

        [Column("name"), StringLength(255)]
        public String Name { get; set; }

        [Column("code")]
        public Int32 Code { get; set; }

        [Column("table_name"), StringLength(255)]
        public String TableName { get; set; }

        [NotMapped] public DateTime CreatedAt { get; set; }//Пропускаем
        [NotMapped] public DateTime UpdatedAt { get; set; } //Пропускаем
    }
}
