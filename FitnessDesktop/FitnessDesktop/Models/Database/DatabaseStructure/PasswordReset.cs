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
    [Table("password_resets")]
    class PasswordReset:ITable
    {
        [Column("id")]
        public Int32 Id { get; set; }

        [Column("email"),StringLength(255)]
        public String Email { get; set; }

        [Column("token"), StringLength(255)]
        public String Token { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [NotMapped]//Т.к. это интерфейс, я не могу не реализовывать его,но я могу пометить его как не нужный.
        public DateTime UpdatedAt { get; set; }
    }
}
