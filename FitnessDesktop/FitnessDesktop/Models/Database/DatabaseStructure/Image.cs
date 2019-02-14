using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace FitnessDatabase.DatabaseStructure
{
    [Table("images")]
    class Image
    {
        public int Id { get; set; }
    }
}
