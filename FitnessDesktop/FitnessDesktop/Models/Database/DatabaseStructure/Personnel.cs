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
    [Table("personnel")]
    public class Personnel:ITable
    {
        //Поля для обратной связи(Они не создаются)
        public ICollection<PersonnelSalary> psalary { get; set; }
        //public Gym gym { get; set; }
        //public User user { get; set; }
        //public Status status { get; set; }
        //
        [Column("id")]
        public Int32 Id { get; set; }

        [Column("gym_id")]
        public Int32 GymID { get; set; }

        [Column("name"), StringLength(100)]
        public String Name { get; set; }

        [Column("surname"), StringLength(100)]
        public String Surname { get; set; }

        [Column("patronymic"), StringLength(100)]
        public String Patronymic { get; set; }

        [Column("birthday")]
        public DateTime? BDay { get; set; }

        [Column("user_id")]
        public Int32? UserID { get; set; }

        [Column("status_id")]
        public Int32 StatusID { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}
