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
    [Table("personnel_rate")]
    class PersonnelRate:ITable
    {
        [Column("id")]
        public Int32 Id { get; set; }

        [Column("person_id")]
        public Int32 PersonID { get; set; }

        [Column("type_id")]
        public Int32 TypeID { get; set; }

        [Column("percent_type")]
        public Int32 percentType { get; set; }

        [Column("value")]
        public Int32 Value { get; set; }

        [Column("status_id")]
        public Int32 StatusID { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}
