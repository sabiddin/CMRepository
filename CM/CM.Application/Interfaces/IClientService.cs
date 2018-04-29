using CM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.Application.Interfaces
{
    public interface IClientService
    {
        Client GetClientByID(int id);
        Client GetClientByLastName(string LastName);
        List<Client> GetClients();
        List<Client> GetClientsBySSN(string SSN);
        void AddClient(Client client);
        void UpdateClient(Client client);
        void DeleteClientByID(int id);
    }
}
