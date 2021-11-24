using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Architecture.Domain
{
    public class Beschikbaarheid
    {
        [Key]
        public int ID { get; set; }

        [DataType(DataType.Date)]
        public DateTime Start { get; set; }

        [DataType(DataType.Date)]
        public DateTime Einde { get; set; }

        public String Omschrijving { get; set; }
    }
}
