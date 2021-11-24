using System;
using System.ComponentModel.DataAnnotations;

namespace Architecture.Domain
{
    public class Vakantie
    {
        [Key]
        public int ID { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Start { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Einde { get; set; }

        public String Omschrijving { get; set; }
    }
}
