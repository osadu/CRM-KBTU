using System.Collections.Generic;
//using System.Linq;
using System.Data.Entity;
using System.Threading.Tasks;
using NLayerApp.DAL.Entities;


namespace NLayerApp.DAL.EF
{
    public class CRMContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Cours> Courses { get; set; }
        public DbSet<Event> Events { get; set; }

        static CRMContext()
        {
            Database.SetInitializer<CRMContext>(new StoreDbInitializer());
        }
        public CRMContext(string connectionString)
            : base(connectionString)
        {
        }
    }

    public class StoreDbInitializer : DropCreateDatabaseIfModelChanges<CRMContext>
    {
        protected override void Seed(CRMContext db)
        {
            db.Clients.Add(new Client { name = "Олжас", sname = "Садуахас", email = "oljas.saduakhas@gmail.com" });
            db.Clients.Add(new Client { name = "Айбек", sname = "Куралбаев", email = "aibek.kuralbaev@gmail.com" });
            db.Clients.Add(new Client { name = "Ерболат", sname = "Канатбек", email = "erbolat.kanatbek@gmail.com" });
            db.Clients.Add(new Client { name = "Аскар", sname = "Смагулов", email = "askar.smagulov@gmail.com" });


            db.Courses.Add(new Cours { cname = "Управление проектами", duration = "1 месяц" });
            db.Courses.Add(new Cours { cname = "Компьютерная моделирование", duration = "1 месяц" });
            db.Courses.Add(new Cours { cname = "Разработка роботов", duration = "1 месяц" });
            db.Courses.Add(new Cours { cname = "Разработка на андройд", duration = "1 месяц" });

            db.Events.Add(new Event { client_id = 1, client_name = "Олжас", client_sname = "Садуахас", cours_id = 1, cours_name = "Управление проектами", date = "22.08.2016", time = "13:00" });
            db.Events.Add(new Event { client_id = 2, client_name = "Айбек", client_sname = "Куралбаев", cours_id = 2, cours_name = "Компьютерная моделирование", date = "22.08.2016", time = "15:00" });
            db.Events.Add(new Event { client_id = 3, client_name = "Ерболат", client_sname = "Канатбек", cours_id = 3, cours_name = "Разработка роботов", date = "22.08.2016", time = "17:00" });
            db.Events.Add(new Event { client_id = 4, client_name = "Аскар", client_sname = "Смагулов", cours_id = 4, cours_name = "Разработка на андройд", date = "22.08.2016", time = "19:00" });

            db.SaveChanges();
        }
    }
}
