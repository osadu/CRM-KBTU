using NLayerApp.DAL.EF;
using NLayerApp.DAL.Entities;
using NLayerApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApp.DAL.Repositories
{
    public class EventRepository : IRepository<Event>
    {
        private CRMContext db;

        public EventRepository(CRMContext context)
        {
            this.db = context;
        }

        public IEnumerable<Event> GetAll()
        {
            return db.Events;
        }

        public Event Get(int id)
        {
            return db.Events.Find(id);
        }

        public void Create(Event events)
        {
            db.Events.Add(events);
        }

        public void Update(Event events)
        {
            db.Entry(events).State = EntityState.Modified;
        }

        public IEnumerable<Event> Find(Func<Event, Boolean> predicate)
        {
            return db.Events.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Event events = db.Events.Find(id);
            if (events != null)
                db.Events.Remove(events);
        }
    }
}
