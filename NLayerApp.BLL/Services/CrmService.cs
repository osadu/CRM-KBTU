using AutoMapper;
using NLayerApp.BLL.DTO;
using NLayerApp.BLL.Interfaces;
using NLayerApp.DAL.Entities;
using NLayerApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApp.BLL.Services
{
    public class CrmService : ICrmService
    {
        IUnitOfWork Database { get; set; }
 
        public CrmService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void AddClient(ClientDTO clientDto)
        {  
            Client client = new Client
            {
                name = clientDto.name,
                sname = clientDto.sname,
                email = clientDto.email
            };
            Database.Clients.Create(client);
            Database.Save();
        }

        public void UpdateClient(ClientDTO clientDto)
        {
            Client client = new Client
            {
                Id = clientDto.Id,
                name = clientDto.name,
                sname = clientDto.sname,
                email = clientDto.email
            };
            Database.Clients.Update(client);
            Database.Save();
        }

        public void DeleteClient(int id) {
           
               Database.Clients.Delete(id);
               Database.Save();
            
        }
        public ClientDTO GetClient(int? id) {

            var client = Database.Clients.Get(id.Value);
            Mapper.CreateMap<Client, ClientDTO>();
            return Mapper.Map<Client, ClientDTO>(client);

        }

        public IEnumerable<ClientDTO> GetClients() {
            Mapper.CreateMap<Client, ClientDTO>();
            return Mapper.Map<IEnumerable<Client>, List<ClientDTO>>(Database.Clients.GetAll());
        }



        public void AddCours(CoursDTO coursDto)
        {
            Cours cours = new Cours
            {
                cname = coursDto.cname,
                duration = coursDto.duration
            };
            Database.Courses.Create(cours);
            Database.Save();
        }

        public void UpdateCours(CoursDTO coursDto)
        {
            Cours cours = new Cours
            {
                Id = coursDto.Id,
                cname = coursDto.cname,
                duration = coursDto.duration
            };
            Database.Courses.Update(cours);
            Database.Save();
        }

        public void DeleteCours(int id)
        {
            Database.Courses.Delete(id);
            Database.Save();

        }
        public CoursDTO GetCours(int? id)
        {

            var cours = Database.Courses.Get(id.Value);
            Mapper.CreateMap<Cours, CoursDTO>();
            return Mapper.Map<Cours, CoursDTO>(cours);

        }

        public IEnumerable<CoursDTO> GetCourses()
        {
            Mapper.CreateMap<Cours, CoursDTO>();
            return Mapper.Map<IEnumerable<Cours>, List<CoursDTO>>(Database.Courses.GetAll());
        }


        public void AddEvent(EventDTO eventDto)
        {
            Event events = new Event
            {
                client_id = eventDto.client_id,
                client_name = eventDto.client_name,
                client_sname = eventDto.client_sname,
                cours_id = eventDto.cours_id,
                cours_name = eventDto.cours_name,
                date = eventDto.date,
                time = eventDto.time
            };
            Database.Events.Create(events);
            Database.Save();
        }

        public void UpdateEvent(EventDTO eventDto)
        {
            Event events = new Event
            {
                Id = eventDto.Id,
                client_id = eventDto.client_id,
                client_name = eventDto.client_name,
                client_sname = eventDto.client_sname,
                cours_id = eventDto.cours_id,
                cours_name = eventDto.cours_name,
                date = eventDto.date,
                time = eventDto.time
            };
            Database.Events.Update(events);
            Database.Save();
        }

        public void DeleteEvent(int id)
        {
            Database.Events.Delete(id);
            Database.Save();

        }
        public EventDTO GetEvent(int? id)
        {

            var events = Database.Events.Get(id.Value);
            Mapper.CreateMap<Event, EventDTO>();
            return Mapper.Map<Event, EventDTO>(events);

        }

        public IEnumerable<EventDTO> GetEvents()
        {
            Mapper.CreateMap<Event, EventDTO>();
            return Mapper.Map<IEnumerable<Event>, List<EventDTO>>(Database.Events.GetAll());
        }


        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
