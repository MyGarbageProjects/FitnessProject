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
    [Table("client_subscription")]
    class ClientSubscription:ITable
    {
        [Column("id")]
        public Int32 Id { get; set; }

        [Column("client_id")]
        public Int32 ClientID { get; set; }

        [Column("person_id")]
        public Int32? PersonID { get; set; }

        [Column("sub_id")]
        public Int32 SubID { get; set; }

        [Column("sub_type")]
        public Int32? SubType { get; set; }

        [Column("start_date")]
        public DateTime StartDate { get; set; }

        [Column("end_date")]
        public DateTime EndDate { get; set; }

        [Column("price")]
        public Int32 Price { get; set; }

        [Column("status_id")]
        public Int32 StatusID { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}
