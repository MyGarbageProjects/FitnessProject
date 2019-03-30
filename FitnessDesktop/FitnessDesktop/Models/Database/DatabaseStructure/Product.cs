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
    [Table("products")]
    public class Product:ITable
    {
        //Поля для обратной связи(Они не создаются)
        //public Personnel person { get; set; }
        //public Status status { get; set; }
        //
        [Column("id")]
        public Int32 Id { get; set; }

        [Column("gym_id")]
        public Int32 GymID { get; set; }

        [Column("type_id")]
        public Int32 TypeID { get; set; }

        [Column("img"), StringLength(255)]
        public String Img { get; set; }

        [Column("count")]
        public Double Count { get; set; }

        [Column("name"), StringLength(255)]
        public String Name { get; set; }

        [Column("qr_code_path"), StringLength(255)]
        public String QRcodePath { get; set; }

        [Column("price")]
        public Int32 Price { get; set; }

        [Column("volume")]
        public Double Volume { get; set; }

        [Column("metrical_id")]
        public Int32 MetricalID { get; set; }

        [Column("sum_volume")]
        public Double SumVolume { get; set; }

        [Column("ingredient_type")]
        public Int32 IngredientType { get; set; }

        [Column("status_id")]
        public Int32 StatusID { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}
