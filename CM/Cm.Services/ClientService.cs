using CM.Application.DataAccess;
using CM.Application.Interfaces;
using CM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.Services
{
    public class ClientService : IClientService
    {
        private IClientRepository _clientRepository;
        private IUnitOfWorkFactory _unitOfWorkFactory;
        public ClientService(IClientRepository clientRepository, IUnitOfWorkFactory unitOfWorkFactory)
        {
            _clientRepository = clientRepository;
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public void AddClient(Client client)
        {
            try
            {
                using (var db = _unitOfWorkFactory.GetUnitOfWork())
                {
                    db.Clients.Add(client);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public void DeleteClientByID(int id)
        {
            using (var db = _unitOfWorkFactory.GetUnitOfWork())
            {
                var client = db.Clients.FindById(id);
                db.Clients.Delete(client);
                db.SaveChanges();
            }
        }

        public Client GetClientByID(int id)
        {
            return _clientRepository.FindById(id);
        }

        public Client GetClientByLastName(string Lastame)
        {
            Client client;//= new Representative();
            using (var db = _unitOfWorkFactory.GetUnitOfWork())
            {
                client = db.Clients.FindBy(u => u.ClientLastName == Lastame).FirstOrDefault();
            }
            return client;
        }

        public List<Client> GetClientsBySSN(string SSN)
        {
            List<Client> clients;//= new Representative();
            using (var db = _unitOfWorkFactory.GetUnitOfWork())
            {
                clients = db.Clients.FindBy(u => u.ClientSSN.Contains(SSN)).ToList();
            }
            return clients;
        }

        public List<Client> GetClients()
        {
            return _clientRepository.FindAll();
        }

        public void UpdateClient(Client client)
        {
            using (var db = _unitOfWorkFactory.GetUnitOfWork())
            {
                db.Clients.Update(client);
                db.SaveChanges();
            }
        }
    }
}
