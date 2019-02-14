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
    [Table("purchase_product")]
    class PurchaseProduct:ITable
    {
        [Column("id")]
        public Int32 Id { get; set; }

        [Column("purchase_id")]
        public Int32 PurchaseID { get; set; }

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
