using NLayerApp.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApp.BLL.Interfaces
{
    public interface ICrmService
    {
        void AddClient(ClientDTO clientDto);
        void UpdateClient(ClientDTO clientDto);
        void DeleteClient(int id);
        ClientDTO GetClient(int? id);
        IEnumerable<ClientDTO> GetClients();

        void AddCours(CoursDTO coursDto);
        void UpdateCours(CoursDTO coursDto);
        void DeleteCours(int id);
        CoursDTO GetCours(int? id);
        IEnumerable<CoursDTO> GetCourses();

        void AddEvent(EventDTO eventDto);
        void UpdateEvent(EventDTO eventDto);
        void DeleteEvent(int id);
        EventDTO GetEvent(int? id);
        IEnumerable<EventDTO> GetEvents();

        void Dispose();
    }
}
