using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessDatabase;

namespace FitnessDatabase.DatabaseStructure
{
    class UpdateDataInfo: ITable
    {
        [Column("id")]
        public Int32 Id { get; set; }

        [Column("table_name"), StringLength(255)]
        public String TableName { get; set; }

        [Column("last_update_id")]
        public Int32 LastID { get; set; }

        [Column("last_update_datetime")]
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime LastUpdateDateTime { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}
