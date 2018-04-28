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
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private IUnitOfWorkFactory _unitOfWorkFactory;
        public UserService(IUserRepository userRepository, IUnitOfWorkFactory unitOfWorkFactory)
        {
            _userRepository = userRepository;
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public void AddUser(User user)
        {
            try
            {
                using (var db = _unitOfWorkFactory.GetUnitOfWork())
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        

        public void DeleteUserByID(int id)
        {
            using (var db = _unitOfWorkFactory.GetUnitOfWork())
            {
                var user = db.Users.FindById(id);
                db.Users.Delete(user);
                db.SaveChanges();
            }
        }

        public User GetUserByID(int id)
        {
            return _userRepository.FindById(id);
        }

        public User GetUserByUsername(string username)
        {
            User user;//= new User();
            using (var db = _unitOfWorkFactory.GetUnitOfWork())
            {
                user = db.Users.FindBy(u=>u.Username ==username).FirstOrDefault();                
            }
            return user;
        }

        public void UpdateUser(User user)
        {
            using (var db = _unitOfWorkFactory.GetUnitOfWork())
            {
                db.Users.Update(user);
                db.SaveChanges();
            }
        }
    }
}
