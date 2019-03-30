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
    [Table("order_product")]
    public class OrderProduct:ITable
    {
        //Поля для обратной связи(Они не создаются)
        //public Order order { get; set; }
        //public Product product { get; set; }
        //public Status status { get; set; }
        //
        [Column("id")]
        public Int32 Id { get; set; }

        [Column("order_id")]
        public Int32 OrderID { get; set; }

        [Column("product_id")]
        public Int32 ProductID { get; set; }

        [Column("price")]
        public Int32 Price { get; set; }

        [Column("count")]
        public Int32 Count { get; set; }

        [Column("status_id")]
        public Int32 StatusID { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}
