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
    [Table("users")]
    class User:ITable
    {
        [Column("id")]
        public Int32 Id { get; set; }

        [Column("name"), StringLength(255)]
        public String Name { get; set; }

        [Column("email"), StringLength(255)]
        public String Email { get; set; }

        [Column("email_verified_at")]
        public DateTime EmailVerifiedAt { get; set; }

        [Column("password"), StringLength(255)]
        public String Password { get; set; }

        [Column("remember_token"), StringLength(100)]
        public String RememberToken { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}
