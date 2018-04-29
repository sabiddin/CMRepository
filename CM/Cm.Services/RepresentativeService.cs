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
    public class RepresentativeService: IRepresentativeService
    {
        private IRepresentativeRepository _RepresentativeRepository;
        private IUnitOfWorkFactory _unitOfWorkFactory;
        public RepresentativeService(IRepresentativeRepository RepresentativeRepository, IUnitOfWorkFactory unitOfWorkFactory)
        {
            _RepresentativeRepository = RepresentativeRepository;
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public void AddRepresentative(Representative Representative)
        {
            try
            {
                using (var db = _unitOfWorkFactory.GetUnitOfWork())
                {
                    db.Representatives.Add(Representative);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public void DeleteRepresentativeByID(int id)
        {
            using (var db = _unitOfWorkFactory.GetUnitOfWork())
            {
                var Representative = db.Representatives.FindById(id);
                db.Representatives.Delete(Representative);
                db.SaveChanges();
            }
        }

        public List<Representative> GetAll()
        {
            return _RepresentativeRepository.FindAll();
        }

        public Representative GetRepresentativeByID(int id)
        {
            return _RepresentativeRepository.FindById(id);
        }

        public Representative GetRepresentativeByLastName(string Lastame)
        {
            Representative Representative;//= new Representative();
            using (var db = _unitOfWorkFactory.GetUnitOfWork())
            {
                Representative = db.Representatives.FindBy(u => u.LastName == Lastame).FirstOrDefault();
            }
            return Representative;
        }

        public void UpdateRepresentative(Representative Representative)
        {
            using (var db = _unitOfWorkFactory.GetUnitOfWork())
            {
                db.Representatives.Update(Representative);
                db.SaveChanges();
            }
        }
    }
}

