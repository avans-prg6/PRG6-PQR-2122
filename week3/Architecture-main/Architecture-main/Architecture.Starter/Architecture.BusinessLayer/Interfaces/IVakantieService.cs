using Architecture.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture.BusinessLayer.Interfaces
{
    public interface IVakantieService
    {
        Vakantie PlanVakantie(DateTime start, DateTime einde, String omschrijving);
    }
}
