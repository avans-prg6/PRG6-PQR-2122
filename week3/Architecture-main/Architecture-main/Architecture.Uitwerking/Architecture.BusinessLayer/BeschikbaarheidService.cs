using Architecture.BusinessLayer.Interfaces;
using Architecture.Domain;
using System;
using System.Linq;

namespace Architecture.BusinessLayer
{
    public class BeschikbaarheidService : IBeschikbaarheidService
    {
        private MyContext _context;
        public BeschikbaarheidService(MyContext context)
        {
            _context = context;
        }

        public void ZetBeschikbaarheid(DateTime start, DateTime einde, string omschrijving = null)
        {
            var beschikbaarheid = _context.Beschikbaarheid.FirstOrDefault(b => b.Start.Date == start.Date);

            if(beschikbaarheid == null)
            {
                _context.Beschikbaarheid.Add(new Beschikbaarheid()
                {
                    Omschrijving = omschrijving,
                    Start = start,
                    Einde = einde
                });
            }
            else
            {
                beschikbaarheid.Start = start;
                beschikbaarheid.Einde = einde;
                beschikbaarheid.Omschrijving = omschrijving;
            }

            _context.SaveChanges();
        }
    }
}
