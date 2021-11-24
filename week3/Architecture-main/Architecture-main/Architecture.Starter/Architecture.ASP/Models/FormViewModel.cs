using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Architecture.ASP.Models
{
    public class FormViewModel
    {
        public string Omschrijving { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy HH:mm}")]
        public DateTime Start { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy HH:mm}")]
        public DateTime Einde { get; set; }

        public Boolean IsRepeat { get; set; }

        public int? AantalKeer { get; set; }

        [Required]
        public Boolean IsHoliday { get; set; }

        public FormViewModel()
        {
            this.Start = DateTime.Now;
            this.Einde = DateTime.Now.AddHours(3);
        }
    }
}
