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
    [Table("personnel_salary")]
    class PersonnelSalary:ITable
    {
        [Column("id")]
        public Int32 Id { get; set; }

        [Column("person_id")]
        public Int32 PersonID { get; set; }

        [Column("salary")]
        public Int32 Salary { get; set; }

        [Column("salary_date")]
        public DateTime SalaryDate { get; set; }

        [Column("remainder")]
        public Int32 Remainder { get; set; }

        [Column("status_id")]
        public Int32 StatusID { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}
