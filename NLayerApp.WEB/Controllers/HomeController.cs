using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NLayerApp.BLL.Interfaces;
using NLayerApp.BLL.DTO;
using NLayerApp.WEB.Models;
using AutoMapper;
using NLayerApp.BLL.Infrastructure;
using System.Diagnostics;

namespace NLayerApp.WEB.Controllers
{
    public class HomeController : Controller
    {
        ICrmService crmService;

        public HomeController(ICrmService serv)
        {
            crmService = serv;
        }

        public ActionResult Index()
        {
            //Mapper.CreateMap<ClientDTO, ClientViewModel>();
            //var clients = Mapper.Map<IEnumerable<ClientDTO>, List<ClientViewModel>>(crmService.GetClients());
            return View();
        }

        public JsonResult GetClients() {
            Mapper.CreateMap<ClientDTO, ClientViewModel>();
            var clients = Mapper.Map<IEnumerable<ClientDTO>, List<ClientViewModel>>(crmService.GetClients());
            return Json(clients,JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetClient(int id)
        {
            Mapper.CreateMap<ClientDTO, ClientViewModel>();
            var client = Mapper.Map<ClientDTO, ClientViewModel>(crmService.GetClient(id));
            return Json(client, JsonRequestBehavior.AllowGet);
        }
        
        public JsonResult GetCourses()
        {
            Mapper.CreateMap<CoursDTO, CoursViewModel>();
            var courses = Mapper.Map<IEnumerable<CoursDTO>, List<CoursViewModel>>(crmService.GetCourses());
            return Json(courses, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCours(int id)
        {
            Mapper.CreateMap<CoursDTO, CoursViewModel>();
            var cours = Mapper.Map<CoursDTO, CoursViewModel>(crmService.GetCours(id));
            return Json(cours, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetEvents()
        {
            Mapper.CreateMap<EventDTO, EventViewModel>();
            var events = Mapper.Map<IEnumerable<EventDTO>, List<EventViewModel>>(crmService.GetEvents());
            return Json(events, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetEvent(int id)
        {
            Mapper.CreateMap<EventDTO, EventViewModel>();
            var events = Mapper.Map<EventDTO, EventViewModel>(crmService.GetEvent(id));
            return Json(events, JsonRequestBehavior.AllowGet);
        }


        public void DeleteClient(int id)
        {
            crmService.DeleteClient(id);
        }
        public void DeleteCours(int id)
        {
            crmService.DeleteCours(id);
        }
        public void DeleteEvent(int id)
        {
            crmService.DeleteEvent(id);
        }

        [HttpPost]
        public void CreateClient(ClientViewModel client) {
            Mapper.CreateMap<ClientViewModel, ClientDTO>();
            var clientDto = Mapper.Map<ClientViewModel, ClientDTO>(client);
            crmService.AddClient(clientDto);
        }
        [HttpPost]
        public void CreateCours(CoursViewModel cours)
        {
            Mapper.CreateMap<CoursViewModel, CoursDTO>();
            var coursDto = Mapper.Map<CoursViewModel, CoursDTO>(cours);
            crmService.AddCours(coursDto);
        }

        [HttpGet]
        public void CreateEvent(int client_id,int cours_id,string date,string time)
        {
            Mapper.CreateMap<ClientDTO, ClientViewModel>();
            var client = Mapper.Map<ClientDTO, ClientViewModel>(crmService.GetClient(client_id));

            Mapper.CreateMap<CoursDTO, CoursViewModel>();
            var cours = Mapper.Map<CoursDTO, CoursViewModel>(crmService.GetCours(cours_id));
            
            EventViewModel events = new EventViewModel();
            events.client_id = client_id;
            events.client_name = client.name;
            events.client_sname = client.sname;
            events.cours_id = cours_id;
            events.cours_name = cours.cname;
            events.date = date;
            events.time = time;

            Mapper.CreateMap<EventViewModel, EventDTO>();
            var eventDto = Mapper.Map<EventViewModel, EventDTO>(events);
            crmService.AddEvent(eventDto);
        }

        [HttpPost]
        public void UpdateClient(ClientViewModel client)
        {
            Mapper.CreateMap<ClientViewModel, ClientDTO>();
            var clientDto = Mapper.Map<ClientViewModel, ClientDTO>(client);
            crmService.UpdateClient(clientDto);
        }
        [HttpPost]
        public void UpdateCours(CoursViewModel cours)
        {
            Mapper.CreateMap<CoursViewModel, CoursDTO>();
            var coursDto = Mapper.Map<CoursViewModel, CoursDTO>(cours);
            crmService.UpdateCours(coursDto);
        }
        [HttpGet]
        public void UpdateEvent(int Id, int client_id, int cours_id, string date, string time)
        {
            Mapper.CreateMap<ClientDTO, ClientViewModel>();
            var client = Mapper.Map<ClientDTO, ClientViewModel>(crmService.GetClient(client_id));

            Mapper.CreateMap<CoursDTO, CoursViewModel>();
            var cours = Mapper.Map<CoursDTO, CoursViewModel>(crmService.GetCours(cours_id));

            EventViewModel events = new EventViewModel();
            events.Id = Id;
            events.client_id = client_id;
            events.client_name = client.name;
            events.client_sname = client.sname;
            events.cours_id = cours_id;
            events.cours_name = cours.cname;
            events.date = date;
            events.time = time;

            Mapper.CreateMap<EventViewModel, EventDTO>();
            var eventDto = Mapper.Map<EventViewModel, EventDTO>(events);
            crmService.UpdateEvent(eventDto);
        }
        protected override void Dispose(bool disposing)
        {
            crmService.Dispose();
            base.Dispose(disposing);
        }
    }
}