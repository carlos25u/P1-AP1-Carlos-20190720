using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1_AP1_Carlos_20190720.Entidades
{
    class Aportes
    {
        [Key]
        public int aporteID { get; set; }
        public DateTime fechaAporte { get; set; }
        public String persona { get; set; }
        public String concepto { get; set; }
        public int monto { get; set; }
    }
}
