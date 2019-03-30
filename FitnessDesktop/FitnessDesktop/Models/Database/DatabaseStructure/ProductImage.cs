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
    [Table("product_image")]
    public class ProductImage:ITable
    {
        //Поля для обратной связи(Они не создаются)
        //public Product product { get; set; }
        //public Status status { get; set; }
        //
        [Column("id")]
        public Int32 Id { get; set; }

        [Column("product_id")]
        public Int32 ProductID { get; set; }

        [Column("image_id")]
        public Int32 ImageID { get; set; }

        [Column("res_code")]
        public Int32 ResCode { get; set; }

        [Column("status_id")]
        public Int32 StatusID { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}
