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
    public class PersonnelSalary:ITable
    {
        //Поля для обратной связи(Они не создаются)
        //public Personnel person { get; set; }
        //public Status status { get; set; }
        public Int32 Id { get; set; }

        public Personnel Person { get; set; }
        //public Int32 PersonID { get; set; }

        public Int32 Salary { get; set; }

        public DateTime SalaryDate { get; set; }

        public Int32 Remainder { get; set; }

        public Int32 StatusID { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
