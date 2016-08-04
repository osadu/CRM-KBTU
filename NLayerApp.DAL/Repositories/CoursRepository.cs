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
    public class CoursRepository : IRepository<Cours>
    {
        private CRMContext db;

        public CoursRepository(CRMContext context)
        {
            this.db = context;
        }

        public IEnumerable<Cours> GetAll()
        {
            return db.Courses;
        }

        public Cours Get(int id)
        {
            return db.Courses.Find(id);
        }

        public void Create(Cours cours)
        {
            db.Courses.Add(cours);
        }

        public void Update(Cours cours)
        {
            db.Entry(cours).State = EntityState.Modified;
        }

        public IEnumerable<Cours> Find(Func<Cours, Boolean> predicate)
        {
            return db.Courses.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Cours cours = db.Courses.Find(id);
            if (cours != null)
                db.Courses.Remove(cours);
        }
    }
}
