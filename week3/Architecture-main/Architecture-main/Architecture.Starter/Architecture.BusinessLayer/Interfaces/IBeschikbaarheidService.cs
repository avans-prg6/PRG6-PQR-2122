using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture.BusinessLayer.Interfaces
{
    public interface IBeschikbaarheidService
    {
        void ZetBeschikbaarheid(DateTime start, DateTime eind, String omschrijving = null);
    }
}
