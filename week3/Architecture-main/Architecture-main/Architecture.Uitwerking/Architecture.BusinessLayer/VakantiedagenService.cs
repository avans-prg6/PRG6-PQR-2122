using Architecture.BusinessLayer.Interfaces;
using Architecture.Domain;
using System;
using System.Linq;

namespace Architecture.BusinessLayer
{
    public class VakantiedagenService : IVakantieService
    {
        private MyContext _context;
        public VakantiedagenService(MyContext context)
        {
            _context = context;
        }
        public Vakantie PlanVakantie(DateTime start, DateTime einde, string omschrijving)
        {
            //zoek naar vakantie met overlap
            var overlap = _context.VakantieDagen.Where(v => (start.Date <= v.Einde.Date && start.Date >= v.Einde.Date)
                || (einde.Date <= v.Einde.Date && einde.Date >= v.Einde.Date)).FirstOrDefault();

            if (overlap != null)
                return null;

            var vakantie = new Vakantie()
            {
                Start = start,
                Einde = einde,
                Omschrijving = omschrijving
            };

            _context.VakantieDagen.Add(vakantie);

            _context.SaveChanges();
            return vakantie;
        }
    }
}
