using Architecture.BusinessLayer.Interfaces;
using System;

namespace Architecture.ASP
{
    internal class DummyBeschikbaarheidService : IBeschikbaarheidService
    {
        public void ZetBeschikbaarheid(DateTime start, DateTime eind, string omschrijving = null)
        {
            //haha gelukt!
        }
    }
}