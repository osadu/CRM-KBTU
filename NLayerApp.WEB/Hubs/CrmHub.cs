using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace NLayerApp.WEB.Hubs
{
    public class CrmHub : Hub
    {

        public void DeleteClient()
        {   
            Clients.All.UpdateClient();
        }

        public void DeleteCours()
        {
            Clients.All.UpdateCours();
        }

        public void DeleteEvent()
        {
            Clients.All.UpdateEvent();
        }

        
        public override System.Threading.Tasks.Task OnDisconnected(bool stopCalled)
        {
           
            return base.OnDisconnected(stopCalled);
        }
    }
}